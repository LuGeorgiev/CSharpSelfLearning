using System;
using System.Diagnostics;
using System.IO;

namespace EstateManagment.Services.Implementation
{
    public class HtmlToPdfConverter:IHtmlToPdfConverter
    {
        public byte[] Convert(string htmlCode)
        {
            var inputFileName = $"input_{Guid.NewGuid()}.html";
            var outputFileName = $"output_{Guid.NewGuid()}.pdf";
            File.WriteAllText(inputFileName, htmlCode);
            var startInfo = new ProcessStartInfo("phantomjs.exe")
            {
                WorkingDirectory = Environment.CurrentDirectory,
                Arguments = $"rasterize.js \"{inputFileName}\" \"{outputFileName}\" \"A4\"",
                UseShellExecute = true,
            };

            var process = new Process { StartInfo = startInfo };
            process.Start();

            process.WaitForExit();

            var bytes = File.ReadAllBytes(outputFileName);

            File.Delete(inputFileName);
            File.Delete(outputFileName);

            return bytes;
        }
    }
}
