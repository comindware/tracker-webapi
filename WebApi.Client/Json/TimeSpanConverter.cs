using System;
using Newtonsoft.Json;
namespace Comindware.Platform.WebApi.Client
{
    public class TimeSpanConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var nTs = value as TimeSpan?;
            TimeSpan ts;
            if (nTs != null)
            {
                ts = nTs.Value;
            }
            else
            {
                ts = (TimeSpan)value;
            }
            //round to nearest second
            ts = new TimeSpan(ts.Days, ts.Hours, ts.Minutes, ts.Seconds);
            writer.WriteValue(System.Xml.XmlConvert.ToString(ts));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
             if (reader.ValueType == typeof(string))
            {
                var value = (string)reader.Value;
                return System.Xml.XmlConvert.ToTimeSpan(value);
            }
            return null;        
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TimeSpan) || objectType == typeof(TimeSpan?);
        }

        public override bool CanRead
        {
            get { return true; }
        }
    }
}
