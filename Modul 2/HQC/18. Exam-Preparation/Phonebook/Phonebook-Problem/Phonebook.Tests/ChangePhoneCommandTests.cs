namespace Phonebook.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ChangePhoneCommandTests
    {
        [TestMethod]
        public void ChangingPhoneNumberWithItselfShouldReturnOneChange()
        {
            var repository = new PhonebookRepository();
            var contactName = "Pesho";
            string[] phoneNumbers = { "0899 777 235", "02 / 981 11 11" };
            var numberToChange = "0899 777 235";

            repository.AddPhone(contactName, phoneNumbers);
            var actual = repository.ChangePhone(numberToChange, numberToChange);

            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void ChangingExistingPhoneNumberWithAnotherPhoneNumberShouldReturnOneChange()
        {
            var repository = new PhonebookRepository();
            var contactName = "Pesho";
            string[] phoneNumbers = { "0899 777 235", "02 / 981 11 11" };
            var numberToChange = "911";

            repository.AddPhone(contactName, phoneNumbers);
            var actual = repository.ChangePhone(phoneNumbers[0], numberToChange);

            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void ChangingNonExistingPhoneNumberWithAnotherPhoneNumberShouldReturnZeroChanges()
        {
            var repository = new PhonebookRepository();
            var contactName = "Pesho";
            string[] phoneNumbers = { "0899 777 235", "02 / 981 11 11" };
            var numberToChange = "911";

            repository.AddPhone(contactName, phoneNumbers);
            var actual = repository.ChangePhone("02/1000", numberToChange);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void ChangingAlreadyChangedPhoneNumberWithAnotherPhoneNumberShouldReturnZeroChanges()
        {
            var repository = new PhonebookRepository();
            var contactName = "Pesho";
            string[] phoneNumbers = { "0899 777 235", "02 / 981 11 11" };
            var numberToChange = "911";
            var anotherNumberToChange = "111";

            repository.AddPhone(contactName, phoneNumbers);
            repository.ChangePhone(phoneNumbers[0], numberToChange);
            var actual = repository.ChangePhone(phoneNumbers[0], anotherNumberToChange);

            Assert.AreEqual(0, actual);
        }
    }
}