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

        public string constructLengthenUrl(string key){
            var request = this.HttpContext.Request;
            var hostPath = $"{Request.Host}";
            var protocol = request.IsHttps ? "https" : "http";
            var controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string path = $"{protocol}://{hostPath}/{controllerName}/Lengthen/{key}";

            return path;
        }

        public void ValidateUrl(string url){
            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute)){
                throw new Exception($"{url} is a malformed url");
            }
        }

        [HttpGet]
        [Route("Shorten")]
        public async Task<IActionResult> Shorten(string url)
        {
            ValidateUrl( url );

            string shorteningKey = await _shorteningService.Shorten(url);

            var path = constructLengthenUrl(shorteningKey);

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
