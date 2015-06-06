namespace Trex.Framework.Core.Serializer
{
    using System;
    public interface IJsonSerializer
    {
        string Serialize<T>(T obj);
        T Deserialize<T>(string data);
    }
}
