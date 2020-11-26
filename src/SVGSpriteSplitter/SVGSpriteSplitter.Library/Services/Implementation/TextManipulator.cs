using SVGSpriteSplitter.Library.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SVGSpriteSplitter.Library.Services.Implementation
{
    internal class TextManipulator : ITextManipulator
    {
        public TextManipulator()
        {
             this.CreatingFileNameCounter = 0;
        }

        public string RemoveSVGTags(string content)
        {
            return content.Replace("<svg>", string.Empty).Replace("</svg>", string.Empty).Trim();
        }

        public IEnumerable<string> SplitSVGSpriteToElements(string svgSpriteContent)
        {
            string endtagOfSpriteElement = "</symbol>";

            var splittedSpriteElements = svgSpriteContent.Split(endtagOfSpriteElement, StringSplitOptions.RemoveEmptyEntries).ToList();
            splittedSpriteElements = splittedSpriteElements.Select(element => string.Concat(element, endtagOfSpriteElement)).ToList();
            
            return splittedSpriteElements;
        }

        public string FormatSymbolTagElementToSVGTagElement(string symbolTagElement)
        {
            return symbolTagElement.Replace("<symbol>", "<svg>").Replace("</symbol>", "</svg>");
        }

        public string CreateFileName(string svgElement) 
        {
            string newFileName = GetTitleTagValue(svgElement);

            if (String.IsNullOrEmpty(newFileName))
            {
                CreatingFileNameCounter += 1;
                return $"svg_file_{CreatingFileNameCounter}.svg";
            }

            return newFileName;
        }

        private string GetTitleTagValue(string element)
        {
            string titleStartTag = "<title>";
            string titleEndTag = "</title>";

            string elementContentToLower = element.ToLower();
            if (element.Contains(titleStartTag) && element.Contains(titleEndTag))
            {
                // remove all chars in the string before title value (left part)
                var textContentStartswithTitleValue = element
                        .Split(titleStartTag, StringSplitOptions.RemoveEmptyEntries)[1];

                if (textContentStartswithTitleValue.StartsWith(titleEndTag))
                {
                    return null;
                }

                // remove all chars in the string after title value (right part)
                var titleValue = textContentStartswithTitleValue.Split(titleEndTag, StringSplitOptions.RemoveEmptyEntries)[0];

                return titleValue;
            }
            else
            {
                return null;
            }
        }

        public string EnsureFileNameFormat(string filename)
        {
            string[] unAllowedFileNameChars = { "\\", "/", ":", "*", "?", "\"", "<", ">", "|" };

                foreach (var character in unAllowedFileNameChars)
            {
                if (filename.Contains(character))
                {
                    filename = filename.Replace(character, string.Empty);
                }
            }

            return filename;
        }

        private int CreatingFileNameCounter  { get; set; }
    }
}
