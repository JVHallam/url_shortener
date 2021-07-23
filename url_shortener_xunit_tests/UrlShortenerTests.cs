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
            using (var client = new HttpClient())
            {

                var expectedUrl = "https://www.google.com";
                var response = await _client.GetAsync($"{_controllerName}/shorten?url={expectedUrl}");
                var responseString = await response.Content.ReadAsStringAsync();
                Assert.Equal( (int)response.StatusCode, (int)HttpStatusCode.OK );

                //Call the response
                var redirectResponse = await _client.GetAsync( responseString );
                
                //Assert that it's a redirect
                Assert.Equal( (int)HttpStatusCode.Found, (int)redirectResponse.StatusCode );

                //Assert the redirect url header
                string relocationUrl = redirectResponse.Headers.Location.ToString();
                Assert.Equal( new Uri(expectedUrl), new Uri(relocationUrl) );
            }
        }

        //Test trying to store a bad url
        [Fact]
        public async Task ShorteningShorten_InvalidUri_BadResponse()
        {
            using (var client = new HttpClient())
            {

                var expectedUrl = "INVALID";
                var response = await _client.GetAsync($"{_controllerName}/shorten?url={expectedUrl}");
                var responseString = await response.Content.ReadAsStringAsync();

                Assert.Contains("malformed", responseString);

                Assert.Equal( (int)response.StatusCode, (int)HttpStatusCode.InternalServerError );
            }
        }

        //Test fetching something that doesn't exist
        [Fact]
        public async Task ShorteningLengthen_InvalidKey_BadResponse()
        {
            Console.WriteLine("TEST!");
            using (var client = new HttpClient())
            {
                var response = await _client.GetAsync($"{_controllerName}/lengthen/invalid");
                var responseString = await response.Content.ReadAsStringAsync();

                //I want a bad request, 400
                Assert.Equal( (int)response.StatusCode, (int)HttpStatusCode.BadRequest );

                Console.WriteLine( responseString );
            }
        }
    }
}
