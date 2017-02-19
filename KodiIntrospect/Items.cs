using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace KodiIntrospect
{
    public class Items
    {
        [JsonProperty(PropertyName = "$ref")]
        public string ReferenceType { get; set; }

        [JsonProperty(PropertyName = "properties")]
        public object Properties { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string itemsType { get; set; }
    }
}
