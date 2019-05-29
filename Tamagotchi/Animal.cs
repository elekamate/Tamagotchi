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

        public sbyte GetSatiationEat()
        {
            return satiationEat;
        }

        public sbyte GetSatiationDrink()
        {
            return satiationDrink;
        }

        public sbyte GetSatiationPlay()
        {
            return satiationPlay;
        }

        public sbyte GetSatiationEarScratch()
        {
            return satiationEarScratch;
        }

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

        public void SatiationEatModify(sbyte delta)
        {
            satiationEat += delta;
        }

        public void SatiationDrinkModify(sbyte delta)
        {
            satiationDrink += delta;
        }

        public void SatiationPlayModify(sbyte delta)
        {
            satiationPlay += delta;
        }

        public void SatiationEarScratchModify(sbyte delta)
        {
            satiationEarScratch += delta;
        }

        public virtual void TimePass()
        {
            SatiationEatModify(-3);
            SatiationDrinkModify(-10);
            SatiationPlayModify(-5);
            SatiationEarScratchModify(-1);
            Console.WriteLine($"Satiations - eat: {satiationEat}, drink: {satiationDrink}" +
                $", play: {satiationPlay}, earScratch: {satiationEarScratch} ");
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
