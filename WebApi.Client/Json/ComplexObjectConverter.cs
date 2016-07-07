using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Comindware.Platform.WebApi.Client
{
    public class ComplexObjectConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(object[]) || objectType == typeof(object);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.StartArray:
                    return this.ReadArray(reader);

                case JsonToken.StartObject:
                    return this.ReadObject(reader);

                default:
                    return null;
            }
        }

        private object[] ReadArray(JsonReader reader)
        {
            var output = new ArrayList();
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonToken.EndArray:
                        return output.ToArray();

                    case JsonToken.StartArray:
                        output.Add(this.ReadArray(reader));
                        break;

                    case JsonToken.StartObject:
                        output.Add(this.ReadObject(reader));
                        break;

                    default:
                        output.Add(reader.Value);
                        break;
                }
            }

            throw new JsonReaderException();
        }

        private object ReadObject(JsonReader reader)
        {
            var subobject = new Dictionary<string, object>();
            string currentKey = null;

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.EndObject)
                {
                    return subobject;
                }
                if (currentKey == null)
                {
                    currentKey = reader.Value.ToString();
                }
                else
                {
                    switch (reader.TokenType)
                    {
                        case JsonToken.StartArray:
                            subobject.Add(currentKey, this.ReadArray(reader));
                            break;

                        case JsonToken.StartObject:
                            subobject.Add(currentKey, this.ReadObject(reader));
                            break;

                        default:
                            subobject.Add(currentKey, reader.Value);
                            break;
                    }
                    currentKey = null;
                }
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}