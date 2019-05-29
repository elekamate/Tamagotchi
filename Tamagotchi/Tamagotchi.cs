using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Tamagotchi
{
    class Tamagotchi
    {
        public static int timePassIntervall = 3000;
        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine("Press 'C' key to create a cat tamagotchi.");
            Console.WriteLine("Press 'D' key to create a dog tamagotchi.");
            Console.WriteLine("Press 'Escape' key to quit.");
        }
    }
}
