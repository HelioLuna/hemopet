using hemopet.Core.Validations.Rules;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace hemopet.Core.Validations.Objects
{
    public class CredencialValidation : ObservableObject
    {
        private List<string> _errors;

        private ValidatableObject<string> _login = new ValidatableObject<string>();
        private ValidatableObject<string> _senha = new ValidatableObject<string>();

        public CredencialValidation()
        {
            Errors = new List<string>();

            InitValidation();
        }


        #region Properties

        public ValidatableObject<string> Login { get => _login; set => SetProperty(ref _login, value); }
        public ValidatableObject<string> Senha { get => _senha; set => SetProperty(ref _senha, value); }
        public List<string> Errors { get => _errors; set => SetProperty(ref _errors, value); }

        #endregion

        private void InitValidation()
        {
            IsNotNullOrEmptyRule<string> isNotNullOrEmptyLoginRule = new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "Necessário preencher o campo LOGIN."
            };

            IsNotNullOrEmptyRule<string> isNotNullOrEmptySenhaRule = new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "Necessário preencher o campo SENHA."
            };

            Login.Validations.Add(isNotNullOrEmptyLoginRule);
            Senha.Validations.Add(isNotNullOrEmptySenhaRule);
        }

        public bool Validate()
        {
            bool validation = true;
            Errors.Clear();

            validation = Login.Validate() && Senha.Validate();

            Errors.AddRange(Login.Errors);
            Errors.AddRange(Senha.Errors);

            return validation;
        }
    }
}
