using hemopet.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System.Collections.Generic;

using static Newtonsoft.Json.JsonConvert;

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

        private static IList<JsonConverter> JsonConverters = new List<JsonConverter> { new StringEnumConverter() };
        private static JsonSerializerSettings _serializerSettings = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            NullValueHandling = NullValueHandling.Ignore,
            Converters = JsonConverters
        };

        #region Settings Constants

        private const string USUARIO_LOGADO = "usuario_logado";
        private const string IS_PRIMEIRO_ACESSO = "is_primeiro_acesso";

        #endregion

        public static Usuario Usuario
        {
            get
            {
                string json = Current.GetValueOrDefault(USUARIO_LOGADO, string.Empty);
                return DeserializeObject<Usuario>(json, _serializerSettings);
            }
            set
            {
                string json = value != null ? SerializeObject(value, _serializerSettings) : "";
                Current.AddOrUpdateValue(USUARIO_LOGADO, json);
            }
        }

        public static bool IsPrimeiroAcesso
        {
            get => Current.GetValueOrDefault(IS_PRIMEIRO_ACESSO, true);
            set => Current.AddOrUpdateValue(IS_PRIMEIRO_ACESSO, value);
        }

    }
}
