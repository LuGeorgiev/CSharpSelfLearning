using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom
{
    class SkypeClient
    {
        public string User { get; private set; }

        public SkypeClient(string user)
        {
            this.User = user;
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
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($@"{this.User} just received the message: {args.Autor} - 
{args.SentOn}:{args.Content}");
            Console.ForegroundColor = ConsoleColor.Black;

        }
    }
}
