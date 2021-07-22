using System;
using System.Threading.Tasks;

namespace url_shortener.Interfaces{
    public interface IShorteningRepository{
        Task<bool> SaveAsync(string key, string url);
        Task<string> FetchAsync(string key);
    }
}
