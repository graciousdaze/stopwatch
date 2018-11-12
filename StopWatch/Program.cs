using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopWatch
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new StopWatch();

            Console.WriteLine("Enter (s) to start the stop watch or (e) to exit: ");
            var input = Console.ReadLine();
            bool notStarted = true;

            while (notStarted)
            {
                if (input.ToLower() == "s")
                {
                    watch.Start();
                    break;
                }
                else if (input.ToLower() == "e")
                {
                    Console.WriteLine("Ending the program, bye now. (Press enter to close window)");
                    break;
                }

                Console.WriteLine("Invalid entry, try again. Press (s) to start or (e) to exit");
                input = Console.ReadLine();
            }

            Console.ReadLine();
        }
    }
}
