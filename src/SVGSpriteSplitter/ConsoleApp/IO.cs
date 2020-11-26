using System;
using System.Text;

namespace ConsoleApp
{
    public class IO
    {
        private const string ApplicationTitle = "SVG SPRITE SPLITTER"; 
        private const string ApplicationURL = "https://Radohub.com/IT/UsefulTools/SvgSpriteSplitter";
        private const string ApplicationInfo = "This console app takes SVG sprite file and split it to separated single SVG files";
        private const string ApplicationUsage = "You need to specify correct full path of some SVG sprite file at your machine as 'source file' and to specify correct full path of some 'destination folder' where the app will extracts the new separated SVG files. Follow next instructions one by one.";
        private const string SourceInputInstruction = "1. Type source file full path:";
        private const string DestinationInputInstruction = "2. Type destination folder full path:";
        private const string LoadingMessage = "Process started! Please wait... ";
        private const string EndTaskMessage = "Task finished!";
        private const string SuccessfullResultMessage = "Task Succeeded!";
        private const string UnSuccessfullResultMessage = "Task Failed! Possible reasons: invalid or incorrect file/folder path or invalid source file content";
        private const string QuitApplicationInstrution = "Press enter to exit.";

        private const string InvalidInputParamsMessage = "ERROR: invalid source or destination path!";

        private string AsterixTextDecorator = new string('*', 20);
        private string AsterixLine = new string('*', 100);
        private string LineSeparatorSmall = new string('=', 25);

        public void ConsolePrint(string text)
        {
            Console.WriteLine(text);
        }

        public void ConsolePrintFreeLine()
        {
            Console.WriteLine();
        }

        public string ConsoleReadParameter()
        {
            return Console.ReadLine();
        }

        public void ConsolePrintWelcomeMesssage()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(AsterixLine);
            stringBuilder.AppendLine($"{AsterixTextDecorator} {ApplicationTitle} {AsterixTextDecorator}");
            stringBuilder.AppendLine($"{AsterixTextDecorator} {ApplicationURL} {AsterixTextDecorator}");
            stringBuilder.AppendLine(AsterixLine);
            stringBuilder.AppendLine(ApplicationInfo);
            stringBuilder.AppendLine(ApplicationUsage);
            stringBuilder.AppendLine(AsterixLine);

            this.ConsolePrint(stringBuilder.ToString());

        }

        public void ConsolePrintSourceInputInstruction()
        {
            this.ConsolePrint(SourceInputInstruction);
            this.ConsolePrintFreeLine();
        }

        public void ConsolePrintDestinationInputInstruction()
        {
            this.ConsolePrint(DestinationInputInstruction);
            this.ConsolePrintFreeLine();
        }

        public void ConsolePrintSmallSeparationLine()
        {
            this.ConsolePrint(LineSeparatorSmall);
        }

        public void ConsolePrintLoadingMessage()
        {
            this.ConsolePrint(LoadingMessage);
        }

        public void ConsolePrintEndTaskMessage()
        {
            this.ConsolePrint(EndTaskMessage);
        }

        public void ConsolePrintQuitAppInstruction()
        {
            this.ConsolePrintFreeLine();
            this.ConsolePrint(QuitApplicationInstrution);
        }

        public void ConsolePrintInvalidInputParamsMessage()
        {
            this.ConsolePrint(InvalidInputParamsMessage);
        }

        public void ConsolePrintSuccessfullResultMessage()
        {
            this.ConsolePrint(SuccessfullResultMessage);
        }

        public void ConsolePrintUnSuccessfullResultMessage()
        {
            this.ConsolePrint(UnSuccessfullResultMessage);
        }
    }
}
