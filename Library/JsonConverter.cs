using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Library
{
    public static class JsonConverter
    {
        
        private static JsonSerializerSettings options = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy { OverrideSpecifiedNames = false }
            }
        };
        public static T Deserialize<T>(string json)
        {
            var deserializaedObject = JsonConvert.DeserializeObject<T>(json, options);
            return deserializaedObject;
        } 

        public static string Serialize(object value)
        {
            var json = JsonConvert.SerializeObject(value, options);
            return json;
        } 
    }
}
