using System.ComponentModel.DataAnnotations;

namespace BookStore.Helpers
{
    public class MyCustomValidationAttribute : ValidationAttribute
    {
        public MyCustomValidationAttribute(string text)
        {
            Text = text;
        }

        public string Text { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
                if (value.ToString().Contains(Text))
                {
                    return ValidationResult.Success;
                }

            return new ValidationResult(ErrorMessage ?? "BookName doesn't contain the desired value");
        }
    }
}
