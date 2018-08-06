using System.Text.RegularExpressions;

namespace hemopet.Core.Validations.Rules
{
    public class IsNotSpecialCharactersRule : IValidationRule<string>
    {
        public string ValidationMessage { get; set; }

        public bool Check(string value)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            return regexItem.IsMatch(value);
        }
    }
}
