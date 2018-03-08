using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom
{
    class TheChtaRoomItself
    {
        //deledate void Handle<T> (object sender, T eventArgs)
        public event EventHandler<ChatMessageEventArgs> MessageSend;

        // those properties are not really mandatory
        public List<string> Participants { get; private set; }
        public string Name { get; private set; }

        public TheChtaRoomItself(string name)
        {
            this.Name = name;
        }

        public void PublishMessage(string username, string content)
        {
            var messageArgs = new ChatMessageEventArgs(content, username);
            this.MessageSend(this, messageArgs);
        }
    }
}
