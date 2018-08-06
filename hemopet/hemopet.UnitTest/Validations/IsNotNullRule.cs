using Microsoft.VisualStudio.TestTools.UnitTesting;
using hemopet.Core.Models;
using hemopet.Core.Validations;
using hemopet.Core.Validations.Rules;
using System;

namespace hemopet.UnitTest.Validations
{
    [TestClass]
    public class IsNotNullRuleTest
    {
        [TestMethod]
        [TestCategory("Rules")]
        public void IsNotNull_Valid()
        {
            ValidatableObject<Object> newObject = new ValidatableObject<Object>() { Value = new Object() };
            IsNotNullRule<Object> rule = new IsNotNullRule<Object>();

            string errorMessage = "O objeto não pode ser nullo";
            rule.ValidationMessage = errorMessage;

            newObject.Validations.Add(rule);

            CollectionAssert.Contains(newObject.Validations, rule, "Esta lista de validações deve conter a regra 'IsNotNull'");
            Assert.IsTrue(newObject.Validate(), "Este objeto não pode ser nullo");
        }

        [TestMethod]
        [TestCategory("Rules")]
        public void IsNotNull_Invalid()
        {
            ValidatableObject<Object> newObject = new ValidatableObject<Object>() { Value = null };
            IsNotNullRule<Object> rule = new IsNotNullRule<Object>();

            string errorMessage = "O objeto não pode ser nullo";
            rule.ValidationMessage = errorMessage;

            newObject.Validations.Add(rule);

            CollectionAssert.Contains(newObject.Validations, rule, "Esta lista de validações deveria conter uma regra do tipo 'IsNotNull'");
            Assert.IsFalse(newObject.Validate(), "O objeto deve ser nullo");
            CollectionAssert.Contains(newObject.Errors, errorMessage, "Está lista de erros não pode estar vazia");
        }
    }
}
