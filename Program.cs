using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

				// TODO: This sucks
                int numSequences = int.Parse(args[0]);
                int sequenceLength = int.Parse(args[1]);
				bool excludeYZ = bool.Parse(args[2]);
				bool excludePairs = bool.Parse(args[3]);

				var sequences = new char[numSequences, sequenceLength];

                var r = new Random();
                for (int i = 0; i < numSequences; i++)
                {
					char lastChar = '\0';
                    for (int j = 0; j < sequenceLength; j++)
                    {
						char c;
						do
						{
							c = (char)('A' + r.Next(excludeYZ ? 24 : 26));
						} while (excludePairs && c == lastChar);
                        sequences[i, j] = lastChar = c;
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
							Thread.Sleep(1000);
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

                Console.WriteLine("Memo time: " + execStartTime.Subtract(memoStartTime).TotalSeconds + "s");
                Console.WriteLine("Exec time: " + DateTime.Now.Subtract(execStartTime).TotalSeconds + "s");
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e);
            }
        }
    }
}
