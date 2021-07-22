using System;
using System.Threading.Tasks;
using url_shortener.Interfaces;

namespace url_shortener.Repositories{
    public class ShorteningRepository : IShorteningRepository
    {
        public ShorteningRepository(){
            
        }

        public async Task<bool> SaveAsync(string key, string url){
            return true;
        }

        public async Task<string> FetchAsync(string key){
            return "Long Url!";
        }
    }
}
