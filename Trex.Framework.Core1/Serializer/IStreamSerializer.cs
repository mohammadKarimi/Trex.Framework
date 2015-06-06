namespace Trex.Framework.Core.Serializer
{
    using System;
    using System.IO;
    public interface IStreamSerializer
    {
        T Deserialize<T>(Stream stream);
    }
}
