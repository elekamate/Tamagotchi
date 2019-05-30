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
            ConsoleKeyInfo consoleKeyInput;
            string consoleLineInput;
            Animal tamagotchi;
            Tamagotchi.WelcomeMessage();
            do
            {
                consoleKeyInput = Console.ReadKey();
                if (consoleKeyInput.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
            } while (consoleKeyInput.Key != ConsoleKey.C && consoleKeyInput.Key != ConsoleKey.D);

            Tamagotchi.ClearConsoleLine();
            tamagotchi = AnimalFactory.Create(consoleKeyInput);
            tamagotchi.PrintCreatedMessage();
            
            Tamagotchi.timeIntervallProvider = new Timer();
            Tamagotchi.timeIntervallProvider.Elapsed += (sender, e) => FreqCycleCount(sender, e, tamagotchi);
            Tamagotchi.timeIntervallProvider.Interval = Tamagotchi.timeIntervall;
            Tamagotchi.timeIntervallProvider.Enabled = true;

            do
            {
                consoleLineInput = Console.ReadLine();
                tamagotchi.DoAction(consoleLineInput);
            } while (consoleLineInput != Tamagotchi.codeToStopApp);
        }

        private static void FreqCycleCount(object source, ElapsedEventArgs e, Animal tamagotchi)
        {
            tamagotchi.TimePass();
        }
    }
}
