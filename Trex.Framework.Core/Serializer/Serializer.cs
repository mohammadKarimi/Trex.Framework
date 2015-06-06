namespace Trex.Framework.Core.Serializer
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    public class Serializer : ISerializer
    {
        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public T Deserialize<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        public T Deserialize<T>(Stream stream)
        {
            var serializer = new DataContractSerializer(typeof(T));
            return (T)serializer.ReadObject(stream);
        }
    }
}
