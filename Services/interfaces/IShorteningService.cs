using System;
using System.Threading.Tasks;

namespace url_shortener.Interfaces
{
    public interface IShorteningService
    {
        Task<string> Shorten(string url);
        Task<string> Lengthen(string key);
    }
}
