namespace Phonebook.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ContactNameComparator : IComparable<ContactNameComparator>
    {
        private string contactName;
        private string contactNameForComparison;

        public SortedSet<string> PhoneNumbers { get; set; }

        public string ContactName
        {
            private get
            {
                return this.contactName;
            }

            set
            {
                this.contactName = value;
                this.contactNameForComparison = value.ToLowerInvariant();
            }
        }

        public int CompareTo(ContactNameComparator other)
        {
            return string.Compare(this.contactNameForComparison, other.contactNameForComparison, StringComparison.Ordinal);
        }

        public override string ToString()
        {
            var outputContact = new StringBuilder();
            outputContact.Append('[');
            outputContact.Append(this.ContactName);

            var isFirstPhoneNumber = true;
            foreach (var phoneNumber in this.PhoneNumbers)
            {
                if (isFirstPhoneNumber)
                {
                    outputContact.Append(": ");
                    isFirstPhoneNumber = false;
                }
                else
                {
                    outputContact.Append(", ");
                }

                outputContact.Append(phoneNumber);
            }

            outputContact.Append(']');
            return outputContact.ToString();
        }
    }
}