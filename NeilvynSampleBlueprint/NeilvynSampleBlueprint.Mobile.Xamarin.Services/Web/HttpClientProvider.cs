using NeilvynSampleBlueprint.Mobile.Common.Constants;
using Newtonsoft.Json;
using Refit;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Services.Web
{
    [ExcludeFromCodeCoverage]
    public class HttpClientProvider
    {
        public static HttpClientProvider Instance { get; } = new HttpClientProvider();

        private readonly HttpClient _httpClient;

        private readonly JsonSerializerSettings _jsonSerializerSettings;

        private HttpClientProvider()
        {
            _httpClient = new HttpClient(new HttpLoggingHandler())
            {
                BaseAddress = new Uri(Server.ApiBaseAddress)
            };

            _jsonSerializerSettings = new JsonSerializerSettings()
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Unspecified
            };
        }

        public T GetApi<T>()
        {
            return RestService.For<T>(_httpClient, new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(_jsonSerializerSettings)
            });
        }
    }
}
