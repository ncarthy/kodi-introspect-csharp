using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace KodiIntrospect
{
    /// <summary>
    /// Custom JsonConverter to handle cases where JsonConvert is expecting "[x,y,z]" but instead
    /// receives "x"
    /// </summary>
    /// <typeparam name="T">Any object or value type</typeparam>
    public class SingleValueArrayConverter<T> : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            T[] retVal = null;

            switch (reader.TokenType)
            {
                case JsonToken.StartArray:
                    retVal = (T[])serializer.Deserialize(reader, objectType);
                    break;
                case JsonToken.StartObject:
                case JsonToken.Boolean:
                case JsonToken.Float:
                case JsonToken.Integer:
                    T instance = (T)serializer.Deserialize(reader, typeof(T));
                    retVal = new T[] { instance };
                    break;
                case JsonToken.String:
                    T str = (T)serializer.Deserialize(reader, typeof(T));
                    if (!string.IsNullOrEmpty(str.ToString()))
                    {
                        retVal = new T[] { str };
                    }
                    break;
            }
            return retVal;
        }

        public override bool CanConvert(Type objectType)
        {
            return (objectType.IsArray);
        }
    }
}
