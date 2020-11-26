using SVGSpriteSplitter.Library.Services.Contracts;
using SVGSpriteSplitter.Library.Services.Implementation;
using System.Collections.Generic;
using System.Linq;

namespace SVGSpriteSplitter.Library
{
    public class SVGSpriteSplitter
    {
        private readonly IFileService fileService;
        private readonly ITextManipulator textManipulator;

        public SVGSpriteSplitter()
        {
            this.fileService = new FileService();
            this.textManipulator = new TextManipulator();
        }

        /// <summary>
        /// Returns whether operation was successfull
        /// </summary>
        /// <param name="spriteFileFullPath">Source file full path</param>
        /// <param name="destinationFolderPath">Destination folder full path</param>
        /// <returns></returns>
        public bool Split(string spriteFileFullPath, string destinationFolderPath)
        {
            try
            {
                string spriteFileContent = fileService.GetSVGSpriteFileContent(spriteFileFullPath);



                spriteFileContent = textManipulator.RemoveSVGTags(spriteFileContent);

                IEnumerable<string> spriteElements = textManipulator.SplitSVGSpriteToElements(spriteFileContent);

                IEnumerable<string> separateSVGElements = spriteElements
                    .Select(element => textManipulator.FormatSymbolTagElementToSVGTagElement(element))
                    .ToList();

                foreach (var element in separateSVGElements)
                {
                    string fileName = textManipulator.CreateFileName(element);

                    fileName = textManipulator.EnsureFileNameFormat(fileName);

                    string fileFullPath = $@"{destinationFolderPath}\{fileName}.svg";

                    fileService.SaveAsSVGFile(fileFullPath, element);
                }

            }
            catch (System.Exception ex)
            {
                var exceptionMessage = ex.Message;

                return false;
            }

            return true;
        }
    }
}
