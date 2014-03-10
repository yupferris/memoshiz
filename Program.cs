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
                Console.WriteLine("Press any key to start...");
                Console.ReadKey();
                Console.Clear();

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
                Console.WriteLine("Press any key to continue...");

                var memoStartTime = DateTime.Now;

                Console.ReadKey();
                Console.Clear();

                var execStartTime = DateTime.Now;

                for (int i = 0; i < numSequences; i++)
                {
                    bool win = true;
                    for (int j = 0; j < sequenceLength; j++)
                    {
                        char c;
                        do
                        {
                            c = Char.ToUpper(Console.ReadKey().KeyChar);
                        }
                        while (c == ' ');
                        var expected = sequences[i, j];
                        if (c != expected)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Wrong :( Should have been: " + expected);
                            win = false;
                            break;
                        }
                    }
                    if (!win)
                        continue;

                    Console.WriteLine();
                    Console.WriteLine("Correct :D:D:D");
                    Console.WriteLine();
                }

                var stoppedTime = DateTime.Now;
                Console.WriteLine("Memo time: " + stoppedTime.Subtract(memoStartTime).TotalSeconds + "s");
                Console.WriteLine("Exec time: " + stoppedTime.Subtract(execStartTime).TotalSeconds + "s");
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e);
            }
        }
    }
}
