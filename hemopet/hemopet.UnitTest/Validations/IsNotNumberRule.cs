using Microsoft.VisualStudio.TestTools.UnitTesting;
using hemopet.Core.Validations;
using hemopet.Core.Validations.Rules;
using System.Collections.Generic;

namespace hemopet.UnitTest.Validations
{
    [TestClass]
    public class IsNotNumberRuleTest
    {
        [TestMethod]
        [TestCategory("Rules")]
        public void IsNotNumber_Valid()
        {
            ValidatableObject<string> texto = new ValidatableObject<string>() { Value = "Texto Sem Número" };
            IsNotNumberRule rule = new IsNotNumberRule();

            string errorMessage = "O Campo texto não contém digitos";
            rule.ValidationMessage = errorMessage;

            texto.Validations.Add(rule);

            CollectionAssert.Contains(texto.Validations, rule, "Está lista de validações deve conter a regra 'IsNotNumberRule'");
            Assert.IsTrue(texto.Validate(), "Este texto não deve conter digitos");
        }

        [TestMethod]
        [TestCategory("Rules")]
        public void IsNotNumber_Invalid()
        {
            List<ValidatableObject<string>> textos = new List<ValidatableObject<string>>();

            textos.Add(new ValidatableObject<string>() { Value = "123456 - Texto Com Número" });
            textos.Add(new ValidatableObject<string>() { });

            IsNotNumberRule rule = new IsNotNumberRule();

            string errorMessage = "O Campo texto precisa conter digitos";
            rule.ValidationMessage = errorMessage;

            foreach (ValidatableObject<string> texto in textos)
            {
                texto.Validations.Add(rule);

                CollectionAssert.Contains(texto.Validations, rule, "Esta lista de validações deveria conter uma regra do tipo 'IsNotNumberRule'");
                Assert.IsFalse(texto.Validate(), "Este texto ter números ou o valor deve ser null");
                CollectionAssert.Contains(texto.Errors, errorMessage, "Esta lista de erros não pode estar vazia");
            }
        }
    }
}
