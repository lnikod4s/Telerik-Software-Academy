// ***********************************************************************
// Assembly         : Phonebook
// Author           : Lyudmil
// Created          : 10-12-2015
//
// Last Modified By : Lyudmil
// Last Modified On : 10-13-2015
// ***********************************************************************
// <copyright file="PhonebookRepository.cs" company="PhonebookCompany">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Helpers;
    using Wintellect.PowerCollections;

    /// <summary>
    /// Class PhonebookRepository.
    /// </summary>
    public class PhonebookRepository : IRemovablePhonebookRepository
    {
        /// <summary>
        /// The dictionary
        /// </summary>
        private readonly Dictionary<string, ContactNameComparator> dictionary =
            new Dictionary<string, ContactNameComparator>();

        /// <summary>
        /// The multi dictionary
        /// </summary>
        private readonly MultiDictionary<string, ContactNameComparator> multiDictionary =
            new MultiDictionary<string, ContactNameComparator>(false);

        /// <summary>
        /// The sorted
        /// </summary>
        private readonly OrderedSet<ContactNameComparator> sorted =
            new OrderedSet<ContactNameComparator>();

        /// <summary>
        /// Adds a new contact to phonebook.
        /// </summary>
        /// <param name="contactName">Name of the contact.</param>
        /// <param name="phoneNumbers">The phone numbers.</param>
        /// <returns><c>true</c> if the specified key is found, <c>false</c> otherwise.</returns>
        public bool AddPhone(string contactName, IEnumerable<string> phoneNumbers)
        {
            var nameToLower = contactName.ToLowerInvariant();
            ContactNameComparator contactNameComparator;
            var hasSpecifiedKey = !this.dictionary.TryGetValue(nameToLower, out contactNameComparator);
            if (hasSpecifiedKey)
            {
                contactNameComparator = new ContactNameComparator
                {
                    ContactName = contactName,
                    PhoneNumbers = new SortedSet<string>()
                };

                this.dictionary.Add(nameToLower, contactNameComparator);
                this.sorted.Add(contactNameComparator);
            }

            foreach (var num in phoneNumbers)
            {
                this.multiDictionary.Add(num, contactNameComparator);
            }

            contactNameComparator.PhoneNumbers.UnionWith(phoneNumbers);
            return hasSpecifiedKey;
        }

        /// <summary>
        /// Changes the specified old phone number in all phonebook entries with a new one.
        /// </summary>
        /// <param name="oldNumber">The old number.</param>
        /// <param name="newNumber">The new number.</param>
        /// <returns>System.Int32.</returns>
        public int ChangePhone(string oldNumber, string newNumber)
        {
            var found = this.multiDictionary[oldNumber].ToList();
            foreach (var entry in found)
            {
                entry.PhoneNumbers.Remove(oldNumber);
                this.multiDictionary.Remove(oldNumber, entry);

                entry.PhoneNumbers.Add(newNumber);
                this.multiDictionary.Add(newNumber, entry);
            }

            return found.Count;
        }

        /// <summary>
        /// Lists the phonebook entries with paging.
        /// </summary>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The count.</param>
        /// <returns>IEnumerable&lt;ContactNameComparator&gt;.</returns>
        public IEnumerable<ContactNameComparator> ListEntries(int startIndex, int count)
        {
            if (startIndex < 0 || startIndex + count > this.dictionary.Count)
            {
                Console.WriteLine("Invalid start index or count.");
                return null;
            }

            var list = new ContactNameComparator[count];
            for (var i = startIndex; i <= startIndex + count - 1; i++)
            {
                var entry = this.sorted[i];
                list[i - startIndex] = entry;
            }

            return list;
        }

        public void Remove(string phoneNumber)
        {
            var dictionaryCopy = new Dictionary<string, ContactNameComparator>(this.dictionary);
            foreach (var entry in dictionaryCopy)
            {
                entry.Value.PhoneNumbers.Remove(phoneNumber);
                if (entry.Value.PhoneNumbers.Count == 0)
                {
                    this.dictionary.Remove(entry.Key);
                }
            }

            var multiDictionaryClone = this.multiDictionary.Clone();
            foreach (var entry in multiDictionaryClone)
            {
                foreach (var number in entry.Value)
                {
                    number.PhoneNumbers.Remove(phoneNumber);
                    if (number.PhoneNumbers.Count == 0)
                    {
                        this.multiDictionary.Remove(entry.Key);
                    }
                }
            }

            var orderedSetClone = this.sorted.Clone();
            foreach (var entry in orderedSetClone)
            {
                entry.PhoneNumbers.Remove(phoneNumber);
                if (entry.PhoneNumbers.Count == 0)
                {
                    this.sorted.Remove(entry);
                }
            }
        }
    }
}