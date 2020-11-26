namespace SVGSpriteSplitter.Library.Services.Contracts
{
    public interface IFileService
    {
        public string GetSVGSpriteFileContent(string spriteFileFullPath);

        void SaveAsSVGFile(string fileFullPath, string fileContent);
    }
}
