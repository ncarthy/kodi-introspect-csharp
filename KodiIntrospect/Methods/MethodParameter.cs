using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KodiIntrospect
{
    public class MethodParameter : Parameter
    {
        [JsonProperty(PropertyName = "default")]
        public string Default { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "items")]
        public Items Items { get; set; }

        /// <summary>
        /// This can be v complicated object. Look at ExecuteAddon:params: 
        /// It can be a dictionary&lt;string,string&gt;, a string[] or a string
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public object Type { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (!this.Required) sb.Append("[ ");
            
            sb.Append("''");
            sb.Append(ParametersTypeToString());
            sb.Append("''");
            if (this.Type != null && this.Type.ToString() == "array" && ParametersTypeToString() != "object") sb.Append("[]");

            sb.Append(" ");
            sb.Append(this.Name);

            if (!string.IsNullOrEmpty(Default))
            {
                sb.Append(" = ");
                if(this.Default != "true" && this.Default != "false") sb.Append("\"");
                sb.Append(this.Default);
                if (this.Default != "true" && this.Default != "false") sb.Append("\"");
            }

            if (!this.Required)
            {
                sb.Append(" ]");
            }


            if (!string.IsNullOrEmpty(Description))
            {
                sb.AppendFormat(" ''{0}''", Description);
            }

            return sb.ToString();
        }

        private string ParametersTypeToString()
        {
            if (string.IsNullOrEmpty(this.ReferenceType))
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
                    else if (this.Type.ToString() == "array")
                    {
                        if (string.IsNullOrEmpty(this.Items.ReferenceType))
                        {
                            if (this.Items != null && this.Items.Properties != null)
                                return "object";
                            else if (this.Items != null && !string.IsNullOrEmpty(this.Items.itemsType))
                                return this.Items.itemsType;
                            else
                                return "object";
                        }
                        else
                            return string.Format("[[#{0}|{0}]]", this.Items.ReferenceType);
                    }
                }

                if (this.Type != null && this.Type.GetType().ToString().Contains("JArray"))
                {
                    var ja = this.Type as JArray;
                    if (ja != null)
                    {
                        try
                        {
                            // Try to deserialize as an array of objects with 'type' property
                            var Serializer = new JsonSerializer();
                            var s = new StringBuilder();
                            s.Append("mixed: ");
                            var resultArray = new TypeArrayType[ja.Count];
                            for (int i = 0; i < ja.Count; i++)
                            {
                                var thing = (TypeArrayType)Serializer.Deserialize(new JTokenReader(ja[i]), typeof(TypeArrayType));
                                if (thing == null)
                                {
                                    return "mixed";
                                }
                                s.Append(thing.type);
                                if (i < (ja.Count - 1))
                                {
                                    s.Append("|");
                                }
                            }
                            return s.ToString();
                        }
                        catch 
                        {
                            return "mixed";
                        }
                    }
                    else
                        return "mixed";
                }
                else
                    return "mixed";
            }
            else
            {
                return string.Format("[[#{0}|{0}]]", this.ReferenceType);
            }


        }

        private class TypeArrayType
        {
            public string type { get; set; }
        }
    }
}
