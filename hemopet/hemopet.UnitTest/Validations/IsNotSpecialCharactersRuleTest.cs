using Microsoft.VisualStudio.TestTools.UnitTesting;
using hemopet.Core.Validations;
using hemopet.Core.Validations.Rules;
using System.Collections.Generic;

namespace hemopet.UnitTest.Validations
{
    [TestClass]
    public class IsNotSpecialCharactersRuleTest
    {

        [TestMethod]
        [TestCategory("Rules")]
        public void IsNotSpecialCharactersRule_Valid()
        {
            ValidatableObject<string> value = new ValidatableObject<string>() { Value = "50" };
            IsNotSpecialCharactersRule rule = new IsNotSpecialCharactersRule();

            string errorMessage = "A string não pode conter caracteres especiais";
            rule.ValidationMessage = errorMessage;

            value.Validations.Add(rule);

            CollectionAssert.Contains(value.Validations, rule, "Esta lista de validações deve conter a regra 'IsNotSpecialCharacters'");
            Assert.IsTrue(value.Validate(), "Esta string não pode conter caracteres especiais");
        }

        [TestMethod]
        [TestCategory("Rules")]
        public void IsNotSpecialCharactersRule_Invalid()
        {
            List<ValidatableObject<string>> caracteresEspeciais = new List<ValidatableObject<string>>() {

                new ValidatableObject<string>() { Value = "asterisco*" },
                new ValidatableObject<string>() { Value = "barra/" },
                new ValidatableObject<string>() { Value = "contrabarr\a" },
                new ValidatableObject<string>() { Value = "hifen-" },
                new ValidatableObject<string>() { Value = "adicao+" },
                new ValidatableObject<string>() { Value = "virgula," },
                new ValidatableObject<string>() { Value = "ponto." },
                new ValidatableObject<string>() { Value = "pontoevirgula;" },
                new ValidatableObject<string>() { Value = "exclamacao!" },
                new ValidatableObject<string>() { Value = "interrogacao?" },
                new ValidatableObject<string>() { Value = "arroba@" },
                new ValidatableObject<string>() { Value = "hashtag#" },
                new ValidatableObject<string>() { Value = "porcetagem%" },
                new ValidatableObject<string>() { Value = "Ecomercial&" },
                new ValidatableObject<string>() { Value = "cifrao$" },
                new ValidatableObject<string>() { Value = "parentese(" },
                new ValidatableObject<string>() { Value = "parentese)" },
                new ValidatableObject<string>() { Value = "chaves[" },
                new ValidatableObject<string>() { Value = "chaves]" },
                new ValidatableObject<string>() { Value = "colchetes{" },
                new ValidatableObject<string>() { Value = "colchetes}" },
                new ValidatableObject<string>() { Value = "circunflexo^" },
                new ValidatableObject<string>() { Value = "til~" },
                new ValidatableObject<string>() { Value = "agudo´" },
                new ValidatableObject<string>() { Value = "crase`" },
                new ValidatableObject<string>() { Value = "aspa_simples'" },
                new ValidatableObject<string>() { Value = "aspas_duplas\"" }

            };

            IsNotSpecialCharactersRule rule = new IsNotSpecialCharactersRule();
            string errorMessage = "A string deve conter caracteres especiais";
            rule.ValidationMessage = errorMessage;

            foreach (ValidatableObject<string> caracterEspecial in caracteresEspeciais)
            {
                caracterEspecial.Validations.Add(rule);
                CollectionAssert.Contains(caracterEspecial.Validations, rule, "Esta lista de validações deve conter a regra 'IsNotSpecialCharacters'");
                Assert.IsFalse(caracterEspecial.Validate(), "Esta string deve conter caracteres especiais");
                CollectionAssert.Contains(caracterEspecial.Errors, errorMessage, "A string deve conter caracteres especiais");
            }

        }
    }
}
