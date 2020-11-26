namespace ConsoleApp
{
    public class Startup
    {
        static void Main(string[] args)
        {
            string sourceFile;
            string destinationFolder;
            bool resultIsSuccessfull = false;

            var inputOutput = new IO();
            var splitter = new SVGSpriteSplitter.Library.SVGSpriteSplitter();

            inputOutput.ConsolePrintWelcomeMesssage();

            inputOutput.ConsolePrintSourceInputInstruction();
            sourceFile = inputOutput.ConsoleReadParameter();
            inputOutput.ConsolePrintFreeLine();

            inputOutput.ConsolePrintDestinationInputInstruction();
            destinationFolder = inputOutput.ConsoleReadParameter();
            inputOutput.ConsolePrintFreeLine();

            if (!string.IsNullOrEmpty(sourceFile) && !string.IsNullOrEmpty(destinationFolder))
            {
                inputOutput.ConsolePrintLoadingMessage();
                resultIsSuccessfull = splitter.Split(sourceFile, destinationFolder);
            }

            inputOutput.ConsolePrintSmallSeparationLine();
            inputOutput.ConsolePrintSmallSeparationLine();

            inputOutput.ConsolePrintEndTaskMessage();

            if (resultIsSuccessfull)
            {
                inputOutput.ConsolePrintSuccessfullResultMessage();
            }
            else
            {
                inputOutput.ConsolePrintUnSuccessfullResultMessage();
            }

            inputOutput.ConsolePrintQuitAppInstruction();
            inputOutput.ConsoleReadParameter();
        }
    }
}
