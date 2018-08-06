using Microsoft.VisualStudio.TestTools.UnitTesting;
using hemopet.Core.Validations;
using hemopet.Core.Validations.Rules;
using System;
using System.Collections.Generic;

namespace hemopet.UnitTest.Validations
{
    [TestClass]
    public class IsNotValidTelephoneTest
    {
        [TestMethod]
        [TestCategory("Rules")]
        public void IsNotValidTelephone_Valid()
        {
            List<ValidatableObject<string>> telefonesValidos = new List<ValidatableObject<string>>();
            IsNotValidTelephoneRule<string> rule = new IsNotValidTelephoneRule<string>();

            telefonesValidos.Add(new ValidatableObject<string>() { Value = "(82)98223-6814" });
            telefonesValidos.Add(new ValidatableObject<string>() { Value = "(33)98191-3349" });

            string errorMessage = "Existem telefones inválidos";
            rule.ValidationMessage = errorMessage;

            foreach (ValidatableObject<string> telefone in telefonesValidos)
            {
                telefone.Validations.Add(rule);
                CollectionAssert.Contains(telefone.Validations, rule, "Esta lista de validações deve conter a regra 'IsNotValidTelephone'");
                Assert.IsTrue(telefone.Validate(), "Este telefone deve ser válido");
            }
        }

        [TestMethod]
        [TestCategory("Rules")]
        public void IsNotValidTelephone_Invalid()
        {
            List<ValidatableObject<string>> telefonesInvalidos = new List<ValidatableObject<string>>();
            IsNotValidTelephoneRule<string> rule = new IsNotValidTelephoneRule<string>();

            telefonesInvalidos.Add(new ValidatableObject<string>() { Value = "+55(82)98289-0445" });
            telefonesInvalidos.Add(new ValidatableObject<string>() { Value = "123456789" });

            string errorMessage = "Existem telefones válidos";
            rule.ValidationMessage = errorMessage;

            foreach (ValidatableObject<string> telefone in telefonesInvalidos)
            {
                telefone.Validations.Add(rule);
                CollectionAssert.Contains(telefone.Validations, rule, "Esta lista de validações deveria conter uma regra do tipo 'IsNotValidTelephone'");
                Assert.IsFalse(telefone.Validate(), "Este telefone deve ser inválido");
                CollectionAssert.Contains(telefone.Errors, errorMessage, "Esta lista de erros não pode estar vazia");
            }
        }
    }
}
