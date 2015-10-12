namespace ATM.Models.Validation
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class CardPinAttribute : ValidationAttribute
    {
        private const int CardPinMaxLength = 4;

        public override bool IsValid(object value)
        {
            if (value == null || value.ToString().Trim().Length == 0)
            {
                return false;
            }

            if (value.ToString().Trim().Length > CardPinMaxLength)
            {
                return false;
            }

            return true;
        }
    }
}