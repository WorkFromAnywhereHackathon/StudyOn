using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace StudyOn.Server.Controllers
{
    public class ChunkMetadata
    {
        public int Index { get; set; }
        public int TotalCount { get; set; }
        public int FileSize { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileGuid { get; set; }
    }

    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UploadController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost("[action]")]
        public ActionResult UploadChunkFile(IFormFile myFile, string chunkMetadata)
        {
            var tempPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            // Removes temporary files
            RemoveTempFilesAfterDelay(tempPath, new TimeSpan(0, 5, 0));

            try
            {
                if (!string.IsNullOrEmpty(chunkMetadata))
                {
                    var metaDataObject = JsonConvert.DeserializeObject<ChunkMetadata>(chunkMetadata);

                    var tempFilePath = Path.Combine(tempPath, metaDataObject.FileGuid + ".tmp");
                    if (!Directory.Exists(tempPath))
                        Directory.CreateDirectory(tempPath);

                    AppendChunkToFile(tempFilePath, myFile);

                    if (metaDataObject.Index == (metaDataObject.TotalCount - 1))
                        SaveUploadedFile(tempFilePath, metaDataObject.FileName);
                }
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }

        void AppendChunkToFile(string path, IFormFile content)
        {
            using (var stream = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
                content.CopyTo(stream);
            }
        }

        void SaveUploadedFile(string tempFilePath, string fileName)
        {
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            System.IO.File.Copy(tempFilePath, Path.Combine(path, fileName));
        }

        void RemoveTempFilesAfterDelay(string path, TimeSpan delay)
        {
            var dir = new DirectoryInfo(path);
            if (dir.Exists)
                foreach (var file in dir.GetFiles("*.tmp").Where(f => f.LastWriteTimeUtc.Add(delay) < DateTime.UtcNow))
                    file.Delete();
        }
    }
}
