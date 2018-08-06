using System.Text.RegularExpressions;

namespace hemopet.Core.Validations.Rules
{
    public class IsNotValidTelephoneRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;
            var regex = @"^\([1-9]{2}\)[2-9][0-9]{3,4}\-[0-9]{4}$";
            var match = Regex.Match(str, regex, RegexOptions.IgnoreCase);

            return match.Success;
        }
    }
}
