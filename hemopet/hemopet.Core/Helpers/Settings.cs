using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace hemopet.Core.Helpers
{
    public class Settings
    {
        private static ISettings Current
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Settings Constants

        private const string IS_PRIMEIRO_ACESSO = "is_primeiro_acesso";

        #endregion

        public static bool IsPrimeiroAcesso
        {
            get => Current.GetValueOrDefault(IS_PRIMEIRO_ACESSO, true);
            set => Current.AddOrUpdateValue(IS_PRIMEIRO_ACESSO, value);
        }

    }
}
