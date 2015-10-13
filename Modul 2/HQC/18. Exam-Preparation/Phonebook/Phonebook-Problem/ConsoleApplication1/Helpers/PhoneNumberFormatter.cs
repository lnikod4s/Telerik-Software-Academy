namespace Phonebook.Helpers
{
    using System.Text;
    using Contracts;

    public class PhoneNumberFormatter : IPhonebookNumberFormatter
    {
        public string Format(string phoneNumber)
        {
            const string CountryCode = "+359";
            var phoneNumberFormatter = new StringBuilder();
            foreach (var ch in phoneNumber)
            {
                if (char.IsDigit(ch) || (ch == '+'))
                {
                    phoneNumberFormatter.Append(ch);
                }
            }

            if (phoneNumberFormatter.Length >= 2 &&
                phoneNumberFormatter[0] == '0' &&
                phoneNumberFormatter[1] == '0')
            {
                phoneNumberFormatter.Remove(0, 1);
                phoneNumberFormatter[0] = '+';
            }

            while (phoneNumberFormatter.Length > 0 && phoneNumberFormatter[0] == '0')
            {
                phoneNumberFormatter.Remove(0, 1);
            }

            if (phoneNumberFormatter.Length > 0 && phoneNumberFormatter[0] != '+')
            {
                phoneNumberFormatter.Insert(0, CountryCode);
            }

            phoneNumberFormatter.Clear();
            foreach (var ch in phoneNumber)
            {
                if (char.IsDigit(ch) || (ch == '+'))
                {
                    phoneNumberFormatter.Append(ch);
                }
            }

            if (phoneNumberFormatter.Length >= 2 && phoneNumberFormatter[0] == '0' && phoneNumberFormatter[1] == '0')
            {
                phoneNumberFormatter.Remove(0, 1);
                phoneNumberFormatter[0] = '+';
            }

            while (phoneNumberFormatter.Length > 0 && phoneNumberFormatter[0] == '0')
            {
                phoneNumberFormatter.Remove(0, 1);
            }

            if (phoneNumberFormatter.Length > 0 && phoneNumberFormatter[0] != '+')
            {
                phoneNumberFormatter.Insert(0, CountryCode);
            }

            phoneNumberFormatter.Clear();
            foreach (var ch in phoneNumber)
            {
                if (char.IsDigit(ch) || (ch == '+'))
                {
                    phoneNumberFormatter.Append(ch);
                }
            }

            if (phoneNumberFormatter.Length >= 2 &&
                phoneNumberFormatter[0] == '0' &&
                phoneNumberFormatter[1] == '0')
            {
                phoneNumberFormatter.Remove(0, 1);
                phoneNumberFormatter[0] = '+';
            }

            while (phoneNumberFormatter.Length > 0 && phoneNumberFormatter[0] == '0')
            {
                phoneNumberFormatter.Remove(0, 1);
            }

            if (phoneNumberFormatter.Length > 0 && phoneNumberFormatter[0] != '+')
            {
                phoneNumberFormatter.Insert(0, CountryCode);
            }

            return phoneNumberFormatter.ToString();
        }
    }
}