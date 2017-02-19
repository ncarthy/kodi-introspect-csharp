using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace KodiIntrospect
{
    public class Notification
    {
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "params")]
        public NotificationParameter[] Parameters { get; set; }

        [JsonProperty(PropertyName = "returns")]
        public string Returns { get; set; }

        [JsonIgnore]
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.Description);

            sb.AppendLine("'''Parameters:''' ");
            sb.Append("<div style=\"margin-left: 20px; width: 60%; padding: 0px 5px 0px");
            sb.AppendLine(" 5px; border-width: 1px; border-style: solid; border-color: #AAAAAA\">");
            sb.Append(ParametersToString());
            sb.AppendLine("</div>");

            sb.Append("{{hidden|style = width: 60%;|headerstyle = background: #cccccc;|contentstyle = text-align: ");
            sb.Append("left; border: 0px solid #AAAAAA;|JSON Schema Description|<syntaxhighlight ");
            sb.Append("lang=\"javascript\" enclose=\"div\">");
            sb.Append(JsonConvert.SerializeObject(this, Formatting.Indented
                    , new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            sb.AppendLine("</syntaxhighlight>}}");
            sb.AppendLine();

            return sb.ToString();
        }

        private string ParametersToString()
        {
            if (Parameters == null || Parameters.Length == 0)
            {
                return String.Empty;
            }

            StringBuilder sb = new StringBuilder();
            foreach (var item in Parameters)
            {
                if (item.Type != "null")
                {
                    sb.Append("# ");
                    sb.AppendLine(item.ToString());
                    if (item.Properties != null)
                    {
                        sb.AppendLine("'''Properties:'''");
                        foreach (var kvp in item.Properties)
                        {
                            sb.Append("* ");
                            kvp.Value.Name = kvp.Key;
                            sb.AppendLine(kvp.Value.ToString());

                        }
                    }
                }
            }
            return sb.ToString();
        }
    }
}
