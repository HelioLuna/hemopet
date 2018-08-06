using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hemopet.Core.Validations.Rules
{
    public class IsNotNumberRule : IValidationRule<string>
    {
        public string ValidationMessage { get; set; }

        public bool Check(string value)
        {
            if (value == null)
            {
                return false;
            }
            return !value.Any(char.IsDigit);
        }
    }
}
