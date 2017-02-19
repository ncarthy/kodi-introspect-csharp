using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace KodiIntrospect
{
    public class Method
    {
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "permission")]
        public string Permission { get; set; }

        [JsonProperty(PropertyName = "type")]        
        public string Type { get; set; }

        [JsonProperty(PropertyName = "params")]
        public MethodParameter[] Parameters { get; set; }

        [JsonProperty(PropertyName = "returns")]
        public ReturnsObject Returns { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Description);
            sb.AppendLine("<br />");
            sb.AppendLine("'''Permissions:'''");
            sb.AppendLine("* "+Permission);
            if (Parameters != null && Parameters.Length > 0)
            {
                sb.AppendLine("'''Parameters:''' ");
                sb.Append("<div style=\"margin-left: 20px; width: 60%; padding: 0px 5px 0px");
                sb.AppendLine(" 5px; border-width: 1px; border-style: solid; border-color: #AAAAAA\">");
                sb.Append(ParametersToString());
                sb.AppendLine("</div>"); 
            }
            sb.AppendLine("'''Returns:''' ");
            sb.Append("<div style=\"margin-left: 20px; width: 60%; padding: 0px 5px 0px");
            sb.AppendLine(" 5px; border-width: 1px; border-style: solid; border-color: #AAAAAA\">");
            sb.Append(Returns.ToString()); 
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
                sb.Append("# ");
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
    }
}
