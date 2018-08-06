
using Microsoft.VisualStudio.TestTools.UnitTesting;
using hemopet.Core.Validations;
using hemopet.Core.Validations.Rules;

namespace hemopet.UnitTest.Validations
{
    [TestClass]
    public class IsNotTextRuleTest
    {


        [TestMethod]
        [TestCategory("Rules")]
        public void IsNotTextRule_Valid()
        {
            ValidatableObject<string> value = new ValidatableObject<string>() { Value = "20" };
            IsNotTextRule rule = new IsNotTextRule();

            string errorMessage = "Este campo só pode conter numero";
            rule.ValidationMessage = errorMessage;

            value.Validations.Add(rule);

            CollectionAssert.Contains(value.Validations, rule, "Esta lista de validações deve conter a regra 'IsNotTextRule'");
            Assert.IsTrue(value.Validate(), "Este campo só pode conter numero");
        }

        [TestMethod]
        [TestCategory("Rules")]
        public void IsNotTextRule_Invalid()
        {
            ValidatableObject<string> value = new ValidatableObject<string>() { Value = "téste" };
            IsNotTextRule rule = new IsNotTextRule();

            string errorMessage = "Este campo só pode conter numero";
            rule.ValidationMessage = errorMessage;

            value.Validations.Add(rule);

            CollectionAssert.Contains(value.Validations, rule, "Esta lista de validações deve conter a regra 'IsNotTextRule'");
            Assert.IsFalse(value.Validate(), "Este campo só pode conter numero");
        }
    }
}
