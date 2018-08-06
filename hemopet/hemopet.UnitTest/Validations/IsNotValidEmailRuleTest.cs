using Microsoft.VisualStudio.TestTools.UnitTesting;
using hemopet.Core.Validations;
using hemopet.Core.Validations.Rules;
using System.Collections.Generic;
using System.Linq;

namespace hemopet.UnitTest.Validations
{
    [TestClass]
    public class IsNotValidEmailRuleTest
    {
        [TestMethod]
        [TestCategory("Rules")]
        public void IsNotValidEmail_Valid()
        {
            List<ValidatableObject<string>> emailsValidos = new List<ValidatableObject<string>>();
            IsNotValidEmailRule<string> rule = new IsNotValidEmailRule<string>();

            emailsValidos.Add(new ValidatableObject<string>() { Value = "email@domain.com" });//REASON: "Valid email
            emailsValidos.Add(new ValidatableObject<string>() { Value = "firstname.lastname@domain.com" });//REASON: "Email contains dot in the address field
            emailsValidos.Add(new ValidatableObject<string>() { Value = "email@subdomain.domain.com" });//REASON: "Email contains dot with subdomain
            emailsValidos.Add(new ValidatableObject<string>() { Value = "1234567890@domain.com" });//REASON: "Digits in address are valid
            emailsValidos.Add(new ValidatableObject<string>() { Value = "email@domain-one.com" });//REASON: "Dash in domain name is valid
            emailsValidos.Add(new ValidatableObject<string>() { Value = "email@domain.name" });//REASON: ".name is valid Top Level Domain name
            emailsValidos.Add(new ValidatableObject<string>() { Value = "email@domain.co.jp" });//REASON: "Dot in Top Level Domain name also considered valid (use co.jp as example here)
            emailsValidos.Add(new ValidatableObject<string>() { Value = "firstname-lastname@domain.com" });//REASON: "Dash in address field is valid

            string errorMessage = "Existem emails inválidos";
            rule.ValidationMessage = errorMessage;

            foreach (ValidatableObject<string> email in emailsValidos)
            {
                email.Validations.Add(rule);
                CollectionAssert.Contains(email.Validations, rule, "Esta lista de validações deve conter a regra 'IsNotValidEmail'");
                Assert.IsTrue(email.Validate(), "Este email deve ser válido");
            }
        }

        [TestMethod]
        [TestCategory("Rules")]
        public void IsNotValidEmail_Invalid()
        {
            List<ValidatableObject<string>> emailsInvalidos = new List<ValidatableObject<string>>();
            IsNotValidEmailRule<string> rule = new IsNotValidEmailRule<string>();

            emailsInvalidos.Add(new ValidatableObject<string>() { Value = "plainaddress" });//REASON: Missing @ sign and domain
            emailsInvalidos.Add(new ValidatableObject<string>() { Value = "#@%^%#$@#$@#.com" });//REASON: Garbage
            emailsInvalidos.Add(new ValidatableObject<string>() { Value = "@domain.com" });//REASON: Missing username
            emailsInvalidos.Add(new ValidatableObject<string>() { Value = "Joe Smith <email@domain.com>" });//REASON: Encoded html within email is invalid
            emailsInvalidos.Add(new ValidatableObject<string>() { Value = "email.domain.com" });//REASON: Missing @
            emailsInvalidos.Add(new ValidatableObject<string>() { Value = "email@domain@domain.com" });//REASON: Two @ sign
            emailsInvalidos.Add(new ValidatableObject<string>() { Value = "?????@domain.com" });//REASON: Unicode char as address
            emailsInvalidos.Add(new ValidatableObject<string>() { Value = "email@domain.com (Joe Smith)" });// REASON: Text followed email is not allowed
            emailsInvalidos.Add(new ValidatableObject<string>() { Value = "email@domain" });//REASON: Missing top level domain (.com/.net/.org/etc)
            emailsInvalidos.Add(new ValidatableObject<string>() { Value = "email@111.222.333.44444" });//REASON: Invalid IP format
            emailsInvalidos.Add(new ValidatableObject<string>() { Value = "email@domain..com" });//REASON: Multiple dot in the domain portion is invalid
            emailsInvalidos.Add(new ValidatableObject<string>() { Value = "email@-domain.com" });//REASON: Leading dash in front of domain is invalid
            emailsInvalidos.Add(new ValidatableObject<string>() { Value = ".email@domain.com" });//REASON: Leading dot in address is not allowed
            emailsInvalidos.Add(new ValidatableObject<string>() { Value = "email.@domain.com" }); //REASON: Trailing dot in address is not allowed
            emailsInvalidos.Add(new ValidatableObject<string>() { Value = "email..email@domain.com" });//REASON: Multiple dots

            string errorMessage = "Existem emails válidos";
            rule.ValidationMessage = errorMessage;

            foreach (ValidatableObject<string> email in emailsInvalidos)
            {
                email.Validations.Add(rule);
                CollectionAssert.Contains(email.Validations, rule, "Esta lista de validações deveria conter uma regra do tipo 'IsNotValidEmail'");
                Assert.IsFalse(email.Validate(), "Este email deve ser inválido");
                CollectionAssert.Contains(email.Errors, errorMessage, "Esta lista de erros não pode estar vazia");
            }
        }
    }
}
