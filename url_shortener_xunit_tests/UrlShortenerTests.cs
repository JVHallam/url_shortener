using System;
using Xunit;
using Xunit.Abstractions;
using System.Threading.Tasks;
using System.Net; 
using System.Net.Http; 

namespace url_shortener_xunit_tests
{
    public class UrlShortenerTests
    {
        private readonly string _baseUrl;
        private readonly string _controllerName;
        private readonly HttpClient _client;

        public UrlShortenerTests(){
            _baseUrl = "https://localhost:5001";

            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            httpClientHandler.AllowAutoRedirect = false;

            _client = new HttpClient(httpClientHandler) { BaseAddress = new Uri(_baseUrl) };
            _controllerName = "shortening";
        }

        [Fact]
        public async Task ShorteningShorten_SendValidUrl_Success()
        {

            using (var client = new HttpClient())
            {
                var response = await _client.GetAsync($"{_controllerName}/shorten?url=https://www.google.com");
                var responseString = await response.Content.ReadAsStringAsync();
                Assert.Equal( (int)response.StatusCode, (int)HttpStatusCode.OK );
                //Assert the returned value is indeed, a valid url
            }
        }

        [Fact]
        public async Task ShorteningLengthen_RetrieveValidKey_Success()
        {
            Console.WriteLine("TEST!");
            using (var client = new HttpClient())
            {

                var expectedUrl = "https://www.google.com";
                var response = await _client.GetAsync($"{_controllerName}/shorten?url={expectedUrl}");
                var responseString = await response.Content.ReadAsStringAsync();
                Assert.Equal( (int)response.StatusCode, (int)HttpStatusCode.OK );

                //Call the response
                Console.WriteLine( responseString );
                var redirectResponse = await _client.GetAsync( responseString );
                
                //Assert that it's a redirect
                Assert.Equal( (int)HttpStatusCode.Found, (int)redirectResponse.StatusCode );

                //Assert the redirect url header
                string relocationUrl = redirectResponse.Headers.Location.ToString();
                Console.WriteLine( relocationUrl );
                Assert.Equal( new Uri(expectedUrl), new Uri(relocationUrl) );
            }
        }
    }
}
