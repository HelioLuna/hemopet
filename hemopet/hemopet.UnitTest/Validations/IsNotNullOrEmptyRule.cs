using Microsoft.VisualStudio.TestTools.UnitTesting;

using hemopet.Core.Validations;
using hemopet.Core.Validations.Rules;
using System.Collections.Generic;

namespace hemopet.UnitTest.Validations
{
    [TestClass]
    public class IsNotNullOrEmptyRuleTest
    {

        [TestMethod]
        [TestCategory("Rules")]
        public void IsNotNullOrEmptyRule_Valid()
        {
            ValidatableObject<string> nome = new ValidatableObject<string>() { Value = "João Dias" };
            IsNotNullOrEmptyRule<string> rule = new IsNotNullOrEmptyRule<string>();

            string errorMessage = "O Campo nome precisa ser preenchido";
            rule.ValidationMessage = errorMessage;

            nome.Validations.Add(rule);

            CollectionAssert.Contains(nome.Validations, rule, "Está lista de validações deve conter a regra 'IsNotNullOrEmptyRule'");
            Assert.IsTrue(nome.Validate(), "Este nome deve ser válido");
        }

        [TestMethod]
        [TestCategory("Rules")]
        public void IsNotNullOrEmptyRule_Invalid()
        {
            List<ValidatableObject<string>> nomes = new List<ValidatableObject<string>>
            {
                new ValidatableObject<string>() {Value = ""},
                new ValidatableObject<string>()
            };

            IsNotNullOrEmptyRule<string> rule = new IsNotNullOrEmptyRule<string>();

            string errorMessage = "O Campo nome precisa ser preenchido";
            rule.ValidationMessage = errorMessage;

            foreach (ValidatableObject<string> nome in nomes)
            {
                nome.Validations.Add(rule);

                CollectionAssert.Contains(nome.Validations, rule, "Está lista de validações deveria conter uma regra do tipo 'IsNotNullOrEmptyRule'");
                Assert.IsFalse(nome.Validate(), "Este nome deve ser inválido");
                CollectionAssert.Contains(nome.Errors, errorMessage, "Está lista de erros não pode estar vazia");
            }
        }
    }
}
