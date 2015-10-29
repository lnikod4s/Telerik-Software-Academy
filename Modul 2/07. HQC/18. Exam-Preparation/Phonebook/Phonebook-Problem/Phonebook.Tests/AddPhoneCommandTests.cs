namespace Phonebook.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AddPhoneCommandTests
    {
        [TestMethod]
        public void AddingNonExistingPhoneEntryShouldReturnTrue()
        {
            var repository = new PhonebookRepository();
            var firstContactName = "Pesho";
            string[] phoneNumbers = { "0899 777 235", "02 / 981 11 11" };

            var actual = repository.AddPhone(firstContactName, phoneNumbers);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void AddingExistingPhoneEntryShouldReturnFalse()
        {
            var repository = new PhonebookRepository();
            var firstContactName = "Pesho";
            var secondContactName = "PeShO";
            string[] phoneNumbers = { "0899 777 235", "02 / 981 11 11" };

            repository.AddPhone(firstContactName, phoneNumbers);
            var actual = repository.AddPhone(secondContactName, phoneNumbers);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void AddingExistingPhoneNumberShouldMergePhoneNumbers()
        {
            var repository = new PhonebookRepository();
            var firstContactName = "Pesho";
            var secondContactName = "PeShO";
            string[] phoneNumbers = { "0899 777 235", "02 / 981 11 11", "112" };

            repository.AddPhone(firstContactName, phoneNumbers);
            var actual = repository.AddPhone(secondContactName, new List<string> { "112" });

            Assert.AreEqual(3, repository.ListEntries(0, 1).First().PhoneNumbers.Count);
        }

        [TestMethod]
        public void AddingNewPhoneNumberShouldMergePhoneNumbers()
        {
            var repository = new PhonebookRepository();
            var firstContactName = "Pesho";
            var secondContactName = "PeShO";
            string[] phoneNumbers = { "0899 777 235", "02 / 981 11 11", "112" };

            repository.AddPhone(firstContactName, phoneNumbers);
            var actual = repository.AddPhone(secondContactName, new List<string> { "112", "911" });

            Assert.AreEqual(4, repository.ListEntries(0, 1).First().PhoneNumbers.Count);
        }
    }
}