using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MonstersApp
{
    public class Monster
    {
        [JsonPropertyName("Name")]
        public String Name { get; set; }
        
        [JsonPropertyName("Type")]
        public String Type { get; set; }

        [JsonPropertyName("Age")]
        public double Age { get; set; }

        [JsonPropertyName("Gender")]
        public String Gender { get; set; }

        [JsonPropertyName("Image")]
        public String Image { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Monster>(this);
    }
}
