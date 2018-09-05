using hemopet.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static Newtonsoft.Json.JsonConvert;

namespace hemopet.Core.Services.Remote.RequestProvider
{
    public class RequestProvider : IRequestProvider
    {
        public static JsonSerializerSettings _serializerSettings;

        public RequestProvider()
        {
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };
            _serializerSettings.Converters.Add(new StringEnumConverter());
        }

        public async Task<TResult> AuthAsync<TResult>(Endpoint endpoint, Credencial credencial)
        {
            HttpClient client = CreateHttpClient();
            Debug.WriteLine("Endpoint: " + endpoint.Value);
            HttpContent content = new StringContent(SerializeObject(credencial, _serializerSettings));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await client.PostAsync(endpoint.Value, content);

            await HandleResponse(response, endpoint, HttpMethod.Post);
            string serialized = await response.Content.ReadAsStringAsync();

            Debug.WriteLine("RequestProvider + AuthAsync: " + serialized);

            return await Task.Run(() => DeserializeObject<TResult>(serialized, _serializerSettings));
        }

        public async Task<TResult> GetAsync<TResult>(Endpoint endpoint, string token = "")
        {
            HttpClient client = CreateHttpClient(token);
            Debug.WriteLine("Endpoint: " + endpoint.Value);
            HttpResponseMessage response = await client.GetAsync(endpoint.Value);

            await HandleResponse(response, endpoint, HttpMethod.Get);
            string serialized = await response.Content.ReadAsStringAsync();

            Debug.WriteLine("RequestProvider + GetAsync: " + serialized);

            return await Task.Run(() => DeserializeObject<TResult>(serialized, _serializerSettings));
        }

        public async Task<TResult> PostAsync<TResult>(Endpoint endpoint, TResult data, string token = "")
        {
            HttpClient client = CreateHttpClient(token);
            Debug.WriteLine("Endpoint: " + endpoint.Value);
            HttpContent content = new StringContent(SerializeObject(data, _serializerSettings));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await client.PostAsync(endpoint.Value, content);

            await HandleResponse(response, endpoint, HttpMethod.Post);
            string serialized = await response.Content.ReadAsStringAsync();

            Debug.WriteLine("RequestProvider + PostAsync: " + serialized);

            return await Task.Run(() => DeserializeObject<TResult>(serialized, _serializerSettings));
        }

        public async Task<TResult> PutAsync<TResult>(Endpoint endpoint, TResult data, string token = "")
        {
            HttpClient client = CreateHttpClient(token);
            Debug.WriteLine("Endpoint: " + endpoint.Value);
            HttpContent content = new StringContent(SerializeObject(data, _serializerSettings));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await client.PutAsync(endpoint.Value, content);

            await HandleResponse(response, endpoint, HttpMethod.Put);
            string serialized = await response.Content.ReadAsStringAsync();

            Debug.WriteLine("RequestProvider + PutAsync: " + serialized);

            return await Task.Run(() => DeserializeObject<TResult>(serialized, _serializerSettings));
        }

        public async Task<TResult> PatchAsync<TResult>(Endpoint endpoint, TResult data, string token = "")
        {
            HttpClient client = CreateHttpClient(token);
            Debug.WriteLine("Endpoint: " + endpoint.Value);
            HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("PATCH"), endpoint.Value);
            request.Content = new StringContent(SerializeObject(data, _serializerSettings));
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await client.SendAsync(request);

            await HandleResponse(response, endpoint, new HttpMethod("PATCH"));
            string serialized = await response.Content.ReadAsStringAsync();

            Debug.WriteLine("RequestProvider + PatchAsync: " + serialized);

            return await Task.Run(() => DeserializeObject<TResult>(serialized, _serializerSettings));
        }

        public async Task<TResult> DeleteAsync<TResult>(Endpoint endpoint, string token = "")
        {
            HttpClient client = CreateHttpClient(token);
            Debug.WriteLine("Endpoint: " + endpoint.Value);
            HttpResponseMessage response = await client.DeleteAsync(endpoint.Value);

            await HandleResponse(response, endpoint, HttpMethod.Delete);
            string serialized = await response.Content.ReadAsStringAsync();

            Debug.WriteLine("RequestProvider + DeleteAsync: " + serialized);

            return await Task.Run(() => DeserializeObject<TResult>(serialized, _serializerSettings));
        }

        private HttpClient CreateHttpClient(string token = "")
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback =
                new System.Net.Security.RemoteCertificateValidationCallback(delegate { return true; });

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.Timeout = new TimeSpan(0, 0, 20);

            if (!string.IsNullOrEmpty(token)) httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return httpClient;
        }

        private async Task HandleResponse(HttpResponseMessage response, Endpoint endpoint, HttpMethod httpMethod)
        {
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                throw new HttpRequestExceptionEx(response.StatusCode, content, endpoint, httpMethod);
            }
        }
    }
}
