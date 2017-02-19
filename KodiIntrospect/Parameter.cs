using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace KodiIntrospect
{
    public class Parameter
    {
        [JsonProperty(PropertyName = "$ref")]
        public string ReferenceType { get; set; }
        
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "required")]
        public bool Required { get; set; }

        // JSON.Net clever-ness!
        // http://www.newtonsoft.com/json/help/html/ConditionalProperties.htm
        public bool ShouldSerializeRequired()
        {
            //dont serialize Required if it is false
            return (Required);
        }
    }
}
