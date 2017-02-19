using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace KodiIntrospect
{
    public class ReturnsObject
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "properties")]
        public Dictionary<string, MethodParameter> Properties { get; set; }

        [JsonProperty(PropertyName = "$ref")]
        public string ReferenceType { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "additionalProperties")]
        public object AdditionalProperties { get; set; }


        [JsonIgnore]
        [JsonProperty(PropertyName = "uniqueItems")]
        public bool UniqueItems { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.Type != null)
                sb.Append(string.Format("'''Type:''' ''{0}''", this.Type));
            else if (this.ReferenceType != null)
                sb.Append(string.Format("'''Type:''' ''[[#{0}|{0}]]''", this.ReferenceType));
            else
                sb.Append(string.Format("'''Type:''' ''{0}''", "object"));
            sb.AppendLine("<br />");
            if (!string.IsNullOrEmpty(Description))
            {
                sb.AppendFormat("\n'''Description:''' ''{0}''", Description);
                sb.AppendLine("<br />");
            }
            if (Properties != null && Properties.Count > 0)
            {
                sb.AppendLine("'''Properties:'''");
                foreach (var item in Properties)
                {
                    sb.Append("* ");
                    if (!item.Value.Required) sb.Append("[ ");
                    sb.Append(item.Value.ToString().Replace("[ ","").Replace(" ]",""));
                    sb.Append(item.Key);
                    if (!item.Value.Required) sb.Append(" ]");

                    sb.AppendLine();
                }
            }
            return sb.ToString();
        }
    }
}
