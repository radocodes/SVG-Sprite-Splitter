using System.Collections.Generic;

namespace SVGSpriteSplitter.Library.Services.Contracts
{
    public interface ITextManipulator
    {
        string RemoveSVGTags(string content);

        IEnumerable<string> SplitSVGSpriteToElements(string svgSpriteContent);

        string FormatSymbolTagElementToSVGTagElement(string symbolTagElement);

        string CreateFileName(string svgElement);

        string EnsureFileNameFormat(string filename);
    }
}
