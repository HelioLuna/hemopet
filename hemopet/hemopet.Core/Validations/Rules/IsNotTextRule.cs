using System.Linq;

namespace hemopet.Core.Validations.Rules
{
    public class IsNotTextRule : IValidationRule<string>
    {
        public string ValidationMessage { get; set; }

        public bool Check(string value)
        {
            return value.Any(char.IsDigit);
        }
    }
}
