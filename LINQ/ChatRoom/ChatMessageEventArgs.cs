using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom
{
    class ChatMessageEventArgs : EventArgs
    {
        public string Content { get; private set; }

        public string Autor { get; private set; }

        public DateTime SentOn { get; private set; }

        public ChatMessageEventArgs(string content, string autor)
        {
            this.Content = content;
            this.Autor = autor;
            this.SentOn = DateTime.Now;
        }
    }
}
