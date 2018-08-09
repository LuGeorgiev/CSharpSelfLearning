using CustomLinkedList;
using System;

namespace P08_CustomLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new DynamicList<String>();
            
            linkedList.Add("Ivan");
            linkedList.Add("Petar");
            linkedList.Add("Marin");

            Console.WriteLine(linkedList[2]);
            for (int i = 0; i < linkedList.Count; i++)
            {                
                Console.WriteLine(linkedList[i]);                    
            }
        }
    }
}
