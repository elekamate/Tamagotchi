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
                if (consoleInput.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
            } while (consoleInput.Key != ConsoleKey.C && consoleInput.Key != ConsoleKey.D);

            tamagotchi = AnimalFactory.Create(consoleInput);
            Tamagotchi.timeIntervallProvider = new Timer();
            Tamagotchi.timeIntervallProvider.Elapsed += (sender, e) => FreqCycleCount(sender, e, tamagotchi);
            Tamagotchi.timeIntervallProvider.Interval = Tamagotchi.timeIntervall;
            Tamagotchi.timeIntervallProvider.Enabled = true;

            do
            {
                consoleInput = Console.ReadKey();
                if (consoleInput.Key == ConsoleKey.Spacebar)
                {
                    Tamagotchi.timeIntervallProvider.Enabled = false;
                }
            } while (consoleInput.Key != ConsoleKey.C && consoleInput.Key != ConsoleKey.D);
        }

        private static void FreqCycleCount(object source, ElapsedEventArgs e, Animal tamagotchi)
        {
            tamagotchi.TimePass();
        }
    }
}
