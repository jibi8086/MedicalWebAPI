using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.External.Helpers
{
    class MedialDataClient
    {
    }
     public class IvoaiDataClient : IIvoaiDataClient
    {
        private readonly HttpClient _httpClient;
        public IvoaiDataClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<T> GetAsync<T>(string uri)
        {
            using (var response = await _httpClient.GetAsync(uri))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    throw new ExternalApiException($"ivoai api failed with statuscode : {response.StatusCode }");
                }

                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(content))
                {
                    return JsonConvert.DeserializeObject<T>(content);
                }
                throw new ExternalApiException($"ivoai api failed with statuscode : {response.StatusCode }");

            }
        }

        public async Task<T> PostAsync<T>(string relativeUrl, object payload)
        {
            using (var response = await _httpClient.PostAsync(relativeUrl, new JsonContent(payload)))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    throw new ExternalApiException($"ivoai api call failed with statuscode : {response.StatusCode}");
                }

                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(content))
                {
                    return JsonConvert.DeserializeObject<T>(content);
                }

                throw new ExternalApiException($"ivoai api call failed with statuscode : {response.StatusCode}");
            }
        }
    }
    public class JsonContent : StringContent
    {
        public JsonContent(object obj) : base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")
        { }
    }
}
