namespace ATM.Models.Validation
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class CardNumberAttribute : ValidationAttribute
    {
        private const int CardNumberMaxLength = 10;

        public override bool IsValid(object value)
        {
            if (value == null || value.ToString().Trim().Length == 0)
            {
                return false;
            }

            if (value.ToString().Trim().Length > CardNumberMaxLength)
            {
                return false;
            }

            return true;
        }
    }
}