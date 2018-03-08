using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom
{
    class Startup
    {
        static void Main(string[] args)
        {
            var chatRoom = new TheChtaRoomItself("TelericAkademyChat");

            var gosho = new SkypeClient("gosho");
            var losho = new SkypeClient("losho");
            var tosho = new mIRcata("tosho");

            gosho.JoinChatRoom(chatRoom);
            losho.JoinChatRoom(chatRoom);
            tosho.JoinChatRoom(chatRoom);

            tosho.SentMessage(chatRoom,"haide an kuponnn");
            gosho.SentMessage(chatRoom, "zaeta sum duhai");
            losho.SentMessage(chatRoom, "haied v 33 da se nakovem");

            Console.WriteLine(tosho.Hystory);
            
        }
    }
}
