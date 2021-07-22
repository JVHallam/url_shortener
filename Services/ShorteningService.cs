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
            int repoResult = await _shorteningRepository.SaveAsync(url);
            return $"{repoResult}";
        }

        public async Task<string> Lengthen(string key){
            var repoResult = await _shorteningRepository.FetchAsync(key);
            return repoResult;
        }
    }
}
