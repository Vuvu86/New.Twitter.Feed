using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Common.Helper.Api
{
    public class ApiHelper
    {
        private HttpClient client;

        protected internal HttpClient Client
        {
            get
            {
                if (client == null)
                    client = InstantiateClient();
                return client;
            }
            set
            {
                client = value;
            }
        }

        protected internal string Url;

        public ApiHelper(string url)
        {
            Url = url;
            if (client == null)
                client = InstantiateClient();
            //client = _client
        }
        public ApiHelper(HttpClient _client,string url)
        {
            client = _client;
            Url = url;
        }

        private HttpClient InstantiateClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
        protected ByteArrayContent GetByteArrayContent<T>(T data) where T : class
        {
            var byteContent = new ByteArrayContent(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data)));
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return byteContent;
        }
        protected ByteArrayContent GetByteArrayContentAsXml<T>(T data) where T : class
        {
            var byteContent = new ByteArrayContent(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data)));
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("text/xml");
            return byteContent;
        }
        protected StringContent GetJsonObjectContent<T>(T data) where T : class
        {
            var jsonString = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            return content;


        }
    }
}

