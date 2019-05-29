using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Tamagotchi
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo consoleInput;
            Animal tamagotchi;
            Tamagotchi.WelcomeMessage();
            do
            {
                consoleInput = Console.ReadKey();
                tamagotchi = AnimalFactory.Create(consoleInput);
                if (consoleInput.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
            } while (consoleInput.Key != ConsoleKey.C && consoleInput.Key != ConsoleKey.D);

            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += (sender, e) => FreqCycleCount(sender, e, tamagotchi);
            aTimer.Interval = Tamagotchi.timePassIntervall;
            aTimer.Enabled = true;

            Console.ReadLine();
        }

        private static void FreqCycleCount(object source, ElapsedEventArgs e, Animal tamagotchi)
        {
            tamagotchi.TimePass();
        }
    }
}
