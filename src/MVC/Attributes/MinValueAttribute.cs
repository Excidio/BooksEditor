using System.ComponentModel.DataAnnotations;

namespace BooksEditor.MVC.Attributes
{
    public class MinValueAttribute : ValidationAttribute
    {
        private readonly int _minValue;

        public MinValueAttribute(int minValue)
        {
            _minValue = minValue;
        }

        public override bool IsValid(object value)
        {
            return _minValue <= (int)value;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, new object[] { name, _minValue });
        }
    }
}