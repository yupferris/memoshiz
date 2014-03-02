using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoShiz
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int numSequences = int.Parse(args[0]);
                int sequenceLength = int.Parse(args[1]);

                var sequences = new char[numSequences, sequenceLength];

                var r = new Random();
                for (int i = 0; i < numSequences; i++)
                {
                    for (int j = 0; j < sequenceLength; j++)
                    {
                        var c = (char)('A' + r.Next(26));
                        sequences[i, j] = c;
                        Console.Write(c);
                        if ((j & 1) != 0)
                            Console.Write(' ');
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();

                Console.ReadKey();

                Console.Clear();
                for (int i = 0; i < numSequences; i++)
                {
                    for (int j = 0; j < sequenceLength; j++)
                    {
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e);
            }
        }
    }
}
