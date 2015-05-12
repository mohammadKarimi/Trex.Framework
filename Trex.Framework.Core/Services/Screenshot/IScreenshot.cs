namespace Trex.Framework.Core.Services
{
    using System.Threading.Tasks;
    public interface IScreenshot
    {
        Task<byte[]> CaptureAsync();
    }
}
