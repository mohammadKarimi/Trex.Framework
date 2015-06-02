namespace Trex.Framework.Service
{
    using System.Threading.Tasks;
    public interface IScreenshot
    {
        Task<byte[]> CaptureAsync();
    }
}
