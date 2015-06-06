
namespace Trex.Framework.Core.Web
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public interface IRestClient
    {
        TimeSpan Timeout { get; set; }
        void AddHeader(string key, string value);
        void RemoveHeader(string key);
        Task<T> PostAsync<T>(string url, object dto);
        Task<T> GetAsync<T>(string url);
        Task<T> GetAsync<T>(string url, Dictionary<string, string> values);
        Task PostAsync(string url, object dto);
        Task<T> PostAsync<T>(string url);
        Task PostAsync(string url);
    }
}

