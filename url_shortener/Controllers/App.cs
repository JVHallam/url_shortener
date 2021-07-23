using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using url_shortener.Interfaces;
using System.Net; 
using System.Net.Http; 
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace url_shortener.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : ControllerBase
    {
        private IWebHostEnvironment _hostingEnvironment;

        public ApplicationController(IWebHostEnvironment environment){
            _hostingEnvironment = environment;
        }

        [HttpGet]
        public ContentResult Get()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Controllers", "Content", "root.html");
            var content = System.IO.File.ReadAllText(path);
            return new ContentResult { ContentType = "text/html", StatusCode = (int) HttpStatusCode.OK, Content = content };
        }
    }
}

