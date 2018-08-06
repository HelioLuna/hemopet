﻿using System;
using System.Collections.Generic;
using System.Text;

namespace hemopet.Core.Validations.Rules
{
    public class IsNotNullRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value) => value != null;
    }
}
