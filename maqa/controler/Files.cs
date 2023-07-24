using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
namespace maqa.controler
{
    public class Files
    {
        private readonly IWebHostEnvironment weebHost;

        public Files(IWebHostEnvironment webHost)
        {
            this.weebHost = webHost;
        }
              public string Uploadfile(IFormFile file, string Folder)
        {
            if(file!=null)
            {
                var fileDir = Path.Combine(weebHost.ContentRootPath, Folder);
                var filename = Guid.NewGuid() + "-" + file.FileName;
                var filepath = Path.Combine(fileDir, filename);

                using (FileStream fileStream = new FileStream(filepath, FileMode.Create))
                {
                    
                    file.CopyTo(fileStream);
                    return filename;
                }
            }
            else
            {
                return string.Empty;
            }

        }

    }
}
