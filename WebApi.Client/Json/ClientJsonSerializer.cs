using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Comindware.Platform.WebApi.Client
{
    public static class ClientJsonSerializer
    {
        private static readonly List<JsonConverter> converters = new List<JsonConverter>
        {
            new IsoDateTimeConverter(),
            new TimeSpanConverter(), 
            new StringEnumConverter(),
        };

        static ClientJsonSerializer()
        {
            Settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore,
                Converters = converters
            };
            Serializer = JsonSerializer.Create(Settings);
        }

        public static readonly JsonSerializerSettings Settings;

        private static readonly JsonSerializer Serializer ;

        public static string ToJson(object data)
        {
            using (var str = new StringWriter())
            {
                using (var writer = new JsonTextWriter(str))
                {
                    Serializer.Serialize(writer, data);
                    writer.Flush();
                    return str.ToString();
                }
            }
        }


        public static T ToObject<T>(string json)
        {
            using (var str = new StringReader(json))
            {
                using (var reader = new JsonTextReader(str))
                {
                    return Serializer.Deserialize<T>(reader);
                }
            }
        }
        public static T ToObject<T>(Stream stream)
        {
            using (var str = new StreamReader(stream))
            {
                using (var reader = new JsonTextReader(str))
                {
                    return Serializer.Deserialize<T>(reader);
                }
            }
        }
    }
}
