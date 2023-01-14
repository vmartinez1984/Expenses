using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Expenses.BusinessLayer.Dtos.Inputs
{
    public class LevelDto{
        public EnumLevel Level { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum EnumLevel{
        Simple = 0,
        Full = 1
    }
}