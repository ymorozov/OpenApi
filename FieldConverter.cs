using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OpenApiPoc
{
    public class FieldConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(BaseField));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            switch (jo["type"].Value<string>())
            {
                case "integer":
                    return jo.ToObject<IntegerField>(serializer);
                case "decimal":
                    return jo.ToObject<DecimalField>(serializer);
                case "location":
                    return jo.ToObject<LocationField>(serializer);
                default:
                    return jo.ToObject<StringField>(serializer);
            }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
