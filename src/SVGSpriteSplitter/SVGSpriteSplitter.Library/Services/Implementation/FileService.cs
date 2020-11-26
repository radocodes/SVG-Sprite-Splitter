using SVGSpriteSplitter.Library.Services.Contracts;
using System.Collections.Generic;
using System.IO;

namespace SVGSpriteSplitter.Library.Services.Implementation
{
    internal class FileService : IFileService
    {
        public string GetSVGSpriteFileContent(string spriteFileFullPath)
        {
            string content = null;

            if (File.Exists(spriteFileFullPath))
            {
                using (var stream = new StreamReader($"{spriteFileFullPath}"))
                {
                    content = stream.ReadToEnd();
                };
            }

            return content;
        }

        public void SaveAsSVGFile(string fileFullPath, string fileContent)
        {
            using (var stream = new StreamWriter(fileFullPath, false))
            {
                stream.WriteAsync(fileContent).GetAwaiter().GetResult();
            };
        }
    }
}
