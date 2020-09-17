using System;
using System.Reflection;

namespace StringCalculator.BLL
{
    public static class StringCalculatorBLL
    {
        [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false)]
        public sealed class EnumDescriptionAttribute : Attribute
        {
            public string Description { get; }

            public EnumDescriptionAttribute(string description) : base()
            {
                Description = description;
            }
        }

        public static class EnumHelper
        {
            public static string GetEnumDescription(Enum value)
            {
                if (value is null)
                {
                    throw new ArgumentNullException("value");
                }

                string description = value.ToString();
                FieldInfo fieldInfo = value.GetType().GetField(description);
                EnumDescriptionAttribute[] attributes = (EnumDescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0)
                {
                    description = attributes[0].Description;
                }
                return description;
            }
        }

        public static string[] Separates
        {
            get
            {
                string[] _separates = { ",", "\n" };
                return _separates;
            }
        }
        public static int Add(string numbers)
        {
            try
            {
                CalculatorService _calculatorService = new CalculatorService();
                return _calculatorService.Add(numbers);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
