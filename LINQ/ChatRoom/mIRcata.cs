using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom
{
    class mIRcata
    {
        private List<string> hystory;
        public string Hystory
        {
            get
            {
                return string.Join("\r\n", this.hystory);
            }
        }
        public string User { get; private set; }

        public mIRcata(string user)
        {
            this.User = user;
            this.hystory = new List<string>();
        }

        public void JoinChatRoom(TheChtaRoomItself room)
        {
            room.MessageSend += this.OnMessageReceived;
        }

        public void SentMessage(TheChtaRoomItself room, string content)
        {
            room.PublishMessage(this.User, content);
        }

        protected void OnMessageReceived(object sender, ChatMessageEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            var msgToPrint = $@"<---[{args.Autor}] 
{args.SentOn}====={args.Content}";
            Console.WriteLine(msgToPrint);
            this.hystory.Add(msgToPrint);
            Console.ForegroundColor = ConsoleColor.Black;

        }
    }
}
