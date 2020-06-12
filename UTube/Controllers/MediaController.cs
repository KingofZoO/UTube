using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UTube.Controllers {
    [Route("api")]
    public class MediaController : Controller {
        private const string mediaFolder = "mediaFolder";

        private readonly string mediaPath;
        private readonly DirectoryInfo mediaDirectory;

        public MediaController() {
            mediaPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, mediaFolder);
            mediaDirectory = new DirectoryInfo(mediaPath);

            if (!mediaDirectory.Exists)
                Directory.CreateDirectory(mediaPath);
        }

        [HttpGet]
        [Route("medialist")]
        public IEnumerable<string> GetMediaList() => mediaDirectory.EnumerateFiles().Select(file => file.Name);

        [HttpGet]
        [Route("mediafile")]
        public PhysicalFileResult GetMediaFile(string name) => new PhysicalFileResult(Path.Combine(mediaPath, name), "application/octet-stream");
    }
}
