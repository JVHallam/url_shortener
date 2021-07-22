using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using url_shortener.Interfaces;

namespace url_shortener.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShorteningController : ControllerBase
    {
        private readonly IShorteningService _shorteningService;
        public ShorteningController(IShorteningService shorteningService)
        {
            _shorteningService = shorteningService;
        }

        [HttpGet]
        [Route("Shorten")]
        public async Task<IActionResult> Shorten(string url)
        {
            string shorteningKey = await _shorteningService.Shorten(url);

            //TODO: Move to a middleware
            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute)){
                throw new Exception($"{url} is a malformed url");
            }

            //TODO: This needs to have the controller name hardcoding removed and i want the absolute url
            string path = $"/Shortening/Lengthen/{shorteningKey}";

            var result = new OkObjectResult(path);
            return result;
        }

        //TODO: This should probably be in another controller called "Lengthen"
        [HttpGet]
        [Route("Lengthen/{key}")]
        public async Task<IActionResult> Lengthen(string key)
        {
            string url = await _shorteningService.Lengthen(key);
            var result = new RedirectResult(url);
            return result;
        }
    }
}
