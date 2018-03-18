using System;
using System.Collections.Generic;

namespace CalculateSequence
{
    class CalculateSequence
    {
        static void Main()
        {
            var firstSequenceMember = long.Parse(Console.ReadLine());
            var sequence = new Queue<long>();
            sequence.Enqueue(firstSequenceMember);
            var counter = 0;
            while (true)
            {
                var currentSequencemember = sequence.Dequeue();
                Console.Write(currentSequencemember+" ");
                counter++;
                if (counter>17)
                {
                    break;
                }

                sequence.Enqueue(currentSequencemember+1);
                sequence.Enqueue(2*currentSequencemember+1);
                sequence.Enqueue(currentSequencemember+2);
            }
            while (counter<50)
            {                
                Console.Write(sequence.Dequeue()+" ");
                counter++;
            }
            Console.WriteLine();
        }
    }
}
