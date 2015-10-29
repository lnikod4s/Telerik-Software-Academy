namespace Phonebook.Tests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ListCommandTests
    {
        [TestMethod]
        public void ListingOneEntryShouldReturnFirstAddedContact()
        {
            var repository = new PhonebookRepository();
            var contactName = "Pesho";
            string[] phoneNumbers = { "0899 777 235", "02 / 981 11 11" };

            repository.AddPhone(contactName, phoneNumbers);
            var actual = repository.ListEntries(0, 1).First().ToString();
            var expected = "[Pesho: 02 / 981 11 11, 0899 777 235]";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ListingWithInvalidRangeParametersShouldReturnNull()
        {
            var repository = new PhonebookRepository();
            var contactName = "Pesho";
            string[] phoneNumbers = { "0899 777 235", "02 / 981 11 11" };

            repository.AddPhone(contactName, phoneNumbers);
            var actual = repository.ListEntries(10, 10);

            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void ListingWithNegativeStartingCountShouldReturnNull()
        {
            var repository = new PhonebookRepository();
            var contactName = "Pesho";
            string[] phoneNumbers = { "0899 777 235", "02 / 981 11 11" };

            repository.AddPhone(contactName, phoneNumbers);
            var actual = repository.ListEntries(-1, 10);

            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void ListingWithParametersSumGreatherThanPhoneNumbersCountShouldReturnNull()
        {
            var repository = new PhonebookRepository();
            var contactName = "Pesho";
            string[] phoneNumbers = { "0899 777 235", "02 / 981 11 11" };

            repository.AddPhone(contactName, phoneNumbers);
            var actual = repository.ListEntries(1, 2);

            Assert.AreEqual(null, actual);
        }
    }
}