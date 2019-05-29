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
        private sbyte satiationIncrement = 10;
        private sbyte satiationEat = 100;
        private sbyte satiationDrink = 100;
        private sbyte satiationPlay = 100;
        private sbyte satiationEarScratch = 100;

        private sbyte actionOver = -10;
        private sbyte actionOk = 30;
        private sbyte actionUnder = -20;

        private ConsoleKey keyToEat = ConsoleKey.E;
        private ConsoleKey keyToDrink = ConsoleKey.D;
        private ConsoleKey keyToPlay = ConsoleKey.P;
        private ConsoleKey keyToEarScratch = ConsoleKey.S;
        private string actualAction;
        private sbyte origWellBeing;
        private sbyte origMeasure;

        public void TimePass()
        {
            satiationEat -= 3;
            satiationDrink -= 10;
            satiationPlay -= 5;
            satiationEarScratch -= 1;
            Console.WriteLine($"Satiations - eat: {satiationEat}, drink: {satiationEat}_" +
                $", play: {satiationPlay}, earScratch: {satiationEarScratch} ");
        }

        public void ModifyWellBeing(sbyte delta)
        {
            origWellBeing = wellBeing;
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
            Console.WriteLine($"Wellbeing modified from {origWellBeing} to {wellBeing}.");
        }

        public void Eat()
        {
            Console.WriteLine($"Tamagotchi is eating.");
            actualAction = "Eat";
            satiationEat = AdjustSatiation(satiationEat);
        }

        public void Drink()
        {
            Console.WriteLine($"Tamagotchi is drinking.");
            satiationDrink = AdjustSatiation(satiationEat);
        }

        public void Play()
        {
            Console.WriteLine($"Tamagotchi is playing.");
            satiationPlay = AdjustSatiation(satiationEat);
        }

        public void EarScratch()
        {
            Console.WriteLine($"Tamagotchi's ear is being scratched right now.");
            satiationEarScratch = AdjustSatiation(satiationEat);
        }

        private sbyte AdjustSatiation(sbyte measure)
        {
            origMeasure = measure;            
            if (measure + satiationIncrement >= 0 && measure + satiationIncrement <= 100)
            {
                measure += satiationIncrement;
                ModifyWellBeing(actionOk);
            }
            else if (measure + satiationIncrement < 0)
            {
                measure = 0;
                ModifyWellBeing(actionUnder);
            }
            else if (measure + satiationIncrement > 100)
            {
                measure = 100;
                ModifyWellBeing(actionOver);
            }
            Console.WriteLine($"{actualAction} satiation modified from {origMeasure} to {measure}.");
            return measure;
        }
    }
}
