using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.App.ViewModels
{
    public class ContentViewModel
    {
        private const int lineLength = 37;

        public ContentViewModel(string conntent)
        {
            this.Content = this.GetLines(conntent);
        }

        public string[] Content { get; }

        private string[] GetLines(string content)
        {
            char[] contentChars = content.ToCharArray();
            ICollection<string> lines = new List<string>();

            for (int i = 0; i < content.Length; i+=lineLength)
            {
                char[] row = contentChars
                    .Skip(i)
                    .Take(lineLength)
                    .ToArray();
                string rowString = string.Join("", row);
                lines.Add(rowString);
            }
            return lines.ToArray();
        }
    }
}
