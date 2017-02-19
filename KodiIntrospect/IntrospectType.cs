using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace KodiIntrospect
{
    public class IntrospectType
    {
        [JsonConverter(typeof(SingleValueArrayConverter<string>))]
        [JsonProperty(PropertyName = "extends")]
        public string[] Extends { get; set; }

        [JsonProperty(PropertyName = "enums")]
        public string[] Enums { get; set; }

        /// <summary>
        /// The "id" keyword defines a URI for the schema, and the base URI that other URI references within 
        /// the schema are resolved against. In the case of thi s'id' it will always refer to other schema in the file 
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "type")]
        public object Type { get; set; }

        [JsonProperty(PropertyName = "properties")]
        public Dictionary<string, MethodParameter> Properties { get; set; }

        [JsonProperty(PropertyName = "items")]
        public object Items { get; set; }

        [JsonProperty(PropertyName = "default")]
        public object Default { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (Extends == null)
            {
                sb.Append("'''Type:''' ");
                sb.AppendFormat("''{0}''\n", TypeToString());
            }
            else
            {
                sb.AppendLine("'''Extends:'''");
                foreach (var item in Extends)
                {
                    sb.AppendFormat("* ''[[#{0}|{0}]]''\n", item);
                }
            }
            if (Properties != null)
            {
                sb.AppendLine("<br />");
                sb.AppendLine("'''Properties:'''");
                sb.Append("<div style=\"margin-left: 20px; width: 60%; padding: 0px 5px 0px");
                sb.AppendLine(" 5px; border-width: 1px; border-style: solid; border-color: #AAAAAA\">");
                sb.Append(PropertiesToString());
                sb.AppendLine("</div>");
            }
            sb.Append("{{hidden|style = width: 60%;|headerstyle = background: #cccccc;|contentstyle = text-align: ");
            sb.Append("left; border: 0px solid #AAAAAA;|JSON Schema Description|<syntaxhighlight ");
            sb.Append("lang=\"javascript\" enclose=\"div\">");
            sb.Append(JsonConvert.SerializeObject(this, Formatting.Indented
                    , new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            sb.AppendLine("</syntaxhighlight>}}");
            sb.AppendLine();
            return sb.ToString();
        }

        private string PropertiesToString()
        {
            if (Properties == null || Properties.Count == 0)
            {
                return String.Empty;
            }

            StringBuilder sb = new StringBuilder();
            foreach (var item in Properties)
            {
                sb.Append("* ");
                sb.AppendLine(item.Value.ToString());
            }
            return sb.ToString();
        }

        private string TypeToString()
        {
                if (this.Type != null)
                {
                    switch (this.Type.ToString())
                    {
                        case "string":
                            return "string";
                        case "number":
                            return "number";
                        case "boolean":
                            return "boolean";
                        case "integer":
                            return "integer";
                    }
                    if (this.Type.GetType().IsValueType)
                        return this.Type.ToString();
                }

                return "mixed";

        }
    }
}
