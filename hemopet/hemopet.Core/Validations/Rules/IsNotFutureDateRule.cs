using System;
using System.Collections.Generic;
using System.Text;

namespace hemopet.Core.Validations.Rules
{
    public class IsNotFutureDateRule : IValidationRule<DateTime>
    {
        public string ValidationMessage { get; set; }

        public bool Check(DateTime value) => value <= DateTime.Today;
    }
}
