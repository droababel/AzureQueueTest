using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net.Http.Json;

namespace InvoiceProcess.Infrasctructure.Core.Services.RequestHandler
{
    public class HttpRequestService
    {
        private readonly HttpClient _client;
        public HttpRequestService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<T>> PostAsyncGetList<T>(string operation, object dataToSend, CancellationToken cancellationToken)
        {            
            var response = await _client
                .PostAsJsonAsync($"{operation}", dataToSend, cancellationToken);

            return await ProcessJsonResponse<T>(response, true);
        }

        private static async Task<List<T>> ProcessJsonResponse<T>(HttpResponseMessage response, bool parseFromJson)
        {
            var result = await response.Content.ReadAsStringAsync();

            if (result == "[]")
            {
                var obj = (T)Activator.CreateInstance(typeof(T));
                return new List<T> { obj };
            }

            if (parseFromJson)
            {
                var token = JToken.Parse(result);

                switch (token)
                {
                    case JObject:
                        {
                            var returnObject = JsonConvert.DeserializeObject<T>(result);
                            return new List<T> { returnObject };
                        }
                    case JArray:
                        return JsonConvert.DeserializeObject<List<T>>(result);
                }
            }

            var model = JsonConvert.DeserializeObject<T>(result);
            Debug.Assert(model != null, nameof(model) + " != null");
            return new List<T> { model };
        }
    }
}
