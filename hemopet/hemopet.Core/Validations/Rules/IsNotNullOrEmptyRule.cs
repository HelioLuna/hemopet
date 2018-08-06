using System;
using System.Collections.Generic;
using System.Text;

namespace hemopet.Core.Validations.Rules
{
    public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var text = value as string;
            return !string.IsNullOrWhiteSpace(text);
        }
    }
}
