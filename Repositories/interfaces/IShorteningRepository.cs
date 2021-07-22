using System;
using System.Threading.Tasks;

namespace url_shortener.Interfaces{
    public interface IShorteningRepository{
        Task<int> SaveAsync(string url);
        Task<string> FetchAsync(string key);
    }
}
