using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace hemopet.Core.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TipoAnimalEnum
    {
        [EnumMember(Value = "1"), Description("Cachorro")]
        Cachorro,
        [EnumMember(Value = "2"), Description("Gato")]
        Gato
    }
}
