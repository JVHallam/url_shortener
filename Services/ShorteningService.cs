using System;
using System.Threading.Tasks;
using url_shortener.Interfaces;

namespace url_shortener.Services{
    public class ShorteningService : IShorteningService
    {
        private readonly IShorteningRepository _shorteningRepository;

        public ShorteningService(IShorteningRepository shorteningRepository)
        {
            _shorteningRepository = shorteningRepository;
        }

        public async Task<string> Shorten(string url){
            var key = "GENKEY";
            bool repoResult = await _shorteningRepository.SaveAsync(key, url);
            return $"Hello from the shortening Service. repoResult - {repoResult}, key - {key}, url - {url}";
        }

        public async Task<string> Lengthen(string key){
            var repoResult = await _shorteningRepository.FetchAsync(key);
            return $"https://postman-echo.com/get?repoResult={repoResult}&key={key}";
        }
    }
}
