using System.Collections.Generic;
using System.IO;

namespace SVGSpriteSplitter.Library.Services.Implementation
{
    internal class FileService
    {
        internal string GetSVGSpriteFileContent(string spriteFileFullPath)
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
    }
}
