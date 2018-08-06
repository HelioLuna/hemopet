using Microsoft.VisualStudio.TestTools.UnitTesting;
using hemopet.Core.Validations;
using hemopet.Core.Validations.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hemopet.UnitTest.Validations
{
    [TestClass]
    public class IsNotFutureDateRuleTest
    {
        [TestMethod]
        [TestCategory("Rules")]
        public void IsNotNullRule_Valid()
        {
            ValidatableObject<DateTime> dateTime = new ValidatableObject<DateTime>() { Value = DateTime.MinValue };
            IsNotFutureDateRule rule = new IsNotFutureDateRule();

            string errorMessage = "A data da denúncia não pode estar após a data atual.";
            rule.ValidationMessage = errorMessage;

            dateTime.Validations.Add(rule);

            CollectionAssert.Contains(dateTime.Validations, rule, "Esta lista de validações deve conter a regra 'IsNotFutureDateRule'");
            Assert.IsTrue(dateTime.Validate(), "Esta data precisa ser menor ou igual que a futura");
        }

        [TestMethod]
        [TestCategory("Rules")]
        public void IsNotNullRule_Invalid()
        {
            ValidatableObject<DateTime> dateTime = new ValidatableObject<DateTime>() { Value = DateTime.MaxValue };
            IsNotFutureDateRule rule = new IsNotFutureDateRule();

            string errorMessage = "A data da denúncia não pode estar após a data atual.";
            rule.ValidationMessage = errorMessage;

            dateTime.Validations.Add(rule);

            CollectionAssert.Contains(dateTime.Validations, rule, "Esta lista de validações deveria conter uma regra do tipo 'IsNotFutureDateRule'");
            Assert.IsFalse(dateTime.Validate(), "Este data deve ser inválida");
            CollectionAssert.Contains(dateTime.Errors, errorMessage, "Está lista de erros não pode estar vazia");
        }
    }
}
