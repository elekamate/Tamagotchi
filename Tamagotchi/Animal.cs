using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi
{
    abstract class Animal
    {
        private sbyte wellBeing = 100;
        private sbyte satiationEat = 100;
        private sbyte satiationDrink = 100;
        private sbyte satiationPlay = 100;
        private sbyte satiationEarScratch = 100;

        private sbyte actionOver = -10;
        private sbyte actionOk = 30;
        private sbyte actionUnder = -20;

        private sbyte needFreqCyclesEat = 10;
        private sbyte needFreqCyclesDrink = 2;
        private sbyte needFreqCyclesPlay = 5;
        private sbyte needFreqCyclesEarScratch = 7;
        private sbyte freqCycleCounter = 0;
        private sbyte freqCycleLastEat = 0;
        private sbyte freqCycleLastDrink = 0;
        private sbyte freqCycleLastPlay = 0;
        private sbyte freqCycleLastEarScratch = 0;

        private ConsoleKey keyToEat = ConsoleKey.E;
        private ConsoleKey keyToDrink = ConsoleKey.D;
        private ConsoleKey keyToPlay = ConsoleKey.P;
        private ConsoleKey keyToEarScratch = ConsoleKey.S;

        public void TimePass()
        {
            freqCycleCounter++;
            satiationEat -= 3;
            satiationDrink -= 10;
            satiationPlay -= 5;
            satiationEarScratch -= 1;
        }

        public void ModifyWellBeing(sbyte delta)
        {
            if (wellBeing + delta >= 0 && wellBeing + delta <= 100)
            {
                wellBeing += delta;
            }
            else if (wellBeing + delta < 0)
            {
                wellBeing = 0;
            }
            else if (wellBeing + delta > 100)
            {
                wellBeing = 100;
            }
        }


        public void Eat()
        {
            Console.WriteLine($"Tamagotchi is eating.");
            freqCycleLastEat = freqCycleCounter;
        }

        public void Drink()
        {
            Console.WriteLine($"Tamagotchi is drinking.");
            freqCycleLastDrink = freqCycleCounter;
        }

        public void Play()
        {
            Console.WriteLine($"Tamagotchi is playing.");
            freqCycleLastPlay = freqCycleCounter;
        }

        public void EarScratch()
        {
            Console.WriteLine($"Tamagotchi's ear is being scratched right now.");
            freqCycleLastEarScratch = freqCycleCounter;
        }

        public void CheckNeeds()
        {

        }
    }
}
