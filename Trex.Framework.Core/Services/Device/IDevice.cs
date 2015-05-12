namespace Trex.Framework.Core.Services
{
    using System;
    public interface IDevice
    {
        string DeviceId { get; }
        int ScreenWidth { get; }
        int ScreenHeight { get; }
        string OsVersion { get; }
        string OsName { get; }
        string FirmwareVersion { get; }
        string HardwareVersion { get; }
        string Manufacturer { get; }
        long TotalMemory { get; }
        string LanguageCode { get; }
    }
}
