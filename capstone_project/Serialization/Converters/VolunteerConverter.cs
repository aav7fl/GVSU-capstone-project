using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GVSU.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GVSU.Serialization.Converters
{
    public class JsonBaseConverter<I, TConcrete> : JsonConverter
        where TConcrete : I, new()
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(I);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (CanConvert(objectType))
            {
                return serializer.Deserialize<TConcrete>(reader);
            }
            else
            {
                return serializer.Deserialize(reader, objectType);
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRaw(JsonConvert.SerializeObject(value));
        }
    }

    public class UserConverter : JsonBaseConverter<IUser, User>
    {

    }

    public class VolunteerConverter : JsonBaseConverter<IVolunteer, Volunteer>
    {
    }

}