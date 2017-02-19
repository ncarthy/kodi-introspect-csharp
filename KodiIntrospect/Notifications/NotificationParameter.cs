using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace KodiIntrospect
{
    public class NotificationParameter : Parameter
    {

        [JsonProperty(PropertyName = "properties")]
        public Dictionary<string,MethodParameter> Properties { get; set; }


        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        public override string ToString()
        {
            // TODO add properties too
            return string.Format("''{0}'' {1}",this.Type, this.Name);
        }
    }
}
