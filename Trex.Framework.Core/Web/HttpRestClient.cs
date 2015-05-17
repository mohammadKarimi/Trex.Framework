namespace Trex.Framework.Core.Web
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Trex.Framework.Core.Serializer;
    public class HttpRestClient : IRestClient
    {
        protected readonly ISerializer Serializer;
        protected readonly HttpClient Client;
        public HttpRestClient(ISerializer serializer)
            : this(serializer, new HttpClient())
        {
        }
        public HttpRestClient(ISerializer serializer, HttpClient client)
        {
            this.Serializer = serializer;
            this.Client = client ?? new HttpClient();
        }
        public TimeSpan Timeout
        {
            get
            {
                return this.Client.Timeout;
            }

            set
            {
                this.Client.Timeout = value;
            }
        }
        protected string StringContentType { get; set; }
        public void AddHeader(string key, string value)
        {
            this.Client.DefaultRequestHeaders.Add(key, value);
        }
        public void RemoveHeader(string key)
        {
            this.Client.DefaultRequestHeaders.Remove(key);
        }

        public async Task<T> PostAsync<T>(string url, object dto)
        {
            var content = this.Serializer.Serialize(dto);

            var response = await this.Client.PostAsync(
                url,
                new StringContent(content, Encoding.UTF8, this.StringContentType));
            return await GetResponse<T>(response, this.Serializer);
        }
        public async Task PostAsync(string url, object dto)
        {
            var content = this.Serializer.Serialize(dto);
            var response = await this.Client.PostAsync(url, new StringContent(content, Encoding.UTF8, this.StringContentType));
            await CheckResponse(response);
        }
        public async Task<T> PostAsync<T>(string url)
        {
            var response = await this.Client.PostAsync(
                url,
                new StringContent("", Encoding.UTF8, this.StringContentType));

            return await GetResponse<T>(response, this.Serializer);
        }
        public async Task PostAsync(string url)
        {
            var response = await this.Client.PostAsync(url, new StringContent("", Encoding.UTF8, this.StringContentType));
            await CheckResponse(response);
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var response = await this.Client.GetAsync(url);
            return await GetResponse<T>(response, this.Serializer);
        }
        public async Task<T> GetAsync<T>(string url, Dictionary<string, string> values)
        {
            var builder = new StringBuilder(url);
            builder.Append("?");

            foreach (var pair in values)
            {
                builder.Append(string.Format("{0}={1}&", pair.Key, pair.Value));
            }
            var response = await this.Client.GetAsync(builder.ToString().TrimEnd('&'));
            return await GetResponse<T>(response, this.Serializer);
        }
      
        private async Task<T> GetResponse<T>(HttpResponseMessage response, ISerializer serializer)
        {
            response.EnsureSuccessStatusCode();
            var ret = serializer.Deserialize<T>(await response.Content.ReadAsStringAsync());
            response.Dispose();
            return ret;
        }
        private async Task CheckResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return;
            }
            var responseMessage = await response.Content.ReadAsStringAsync();
            WebResponseException exception;
            try
            {
                exception = new WebResponseException(response.StatusCode, response.ReasonPhrase, this.Serializer.Deserialize<Exception>(responseMessage));
            }
            catch
            {
                exception = new WebResponseException(response.StatusCode, response.ReasonPhrase, new Exception(responseMessage));
            }
            response.Dispose();
            throw exception;
        }
    }
}
