using System.ComponentModel.DataAnnotations;

namespace RentacarApi.Helpers.ValidationAttributes
{
    public class JmbgValidation : ValidationAttribute
    {
        public JmbgValidation()
        {
        }
        public override bool IsValid(object? value)
        {
            if(value != null){
                var count = value.ToString()!.Length;
                if(count >= 13)
                    return true;
            }
            ErrorMessage = "Email cant have less than 13 figures";
            return false;
        }
    }
}
