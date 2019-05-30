﻿using System;
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

        private sbyte satiationEatIncrementOverTimeCycle = -3;
        private sbyte satiationDrinkIncrementOverTimeCycle = -10;
        private sbyte satiationPlayIncrementOverTimeCycle = -5;
        private sbyte satiationEarScratchIncrementOverTimeCycle = -1;

        private ConsoleKey keyToEat = ConsoleKey.E;
        private ConsoleKey keyToDrink = ConsoleKey.D;
        private ConsoleKey keyToPlay = ConsoleKey.P;
        private ConsoleKey keyToEarScratch = ConsoleKey.S;
        private string actualAction;
        private sbyte origWellBeing;
        private sbyte modifiedMeasure;


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
            if (origWellBeing != wellBeing)
            {
                Console.WriteLine($"Wellbeing modified from {origWellBeing} to {wellBeing}.");
            }
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
            Console.WriteLine("---TimeCycle passed.---");
            AdjustSatiationsOverTimeCycle();
            Console.WriteLine($"Satiations - eat: {satiationEat}, drink: {satiationDrink}" +
                $", play: {satiationPlay}, earScratch: {satiationEarScratch} ");
            Console.WriteLine("-----------------------");
        }

        protected void AdjustSatiationsOverTimeCycle()
        {
            actualAction = "Eat";
            satiationEat = AdjustSatiation(satiationEat, satiationEatIncrementOverTimeCycle);
            actualAction = "Drink";
            satiationDrink = AdjustSatiation(satiationDrink, satiationDrinkIncrementOverTimeCycle);
            actualAction = "Play";
            satiationPlay = AdjustSatiation(satiationPlay, satiationPlayIncrementOverTimeCycle);
            actualAction = "EarScratch";
            satiationEarScratch = AdjustSatiation(satiationEarScratch, satiationEarScratchIncrementOverTimeCycle);
        }

        public void Eat()
        {
            Console.WriteLine($"Tamagotchi is eating.");
            actualAction = "Eat";
            satiationEat = AdjustSatiation(satiationEat, satiationIncrement);
        }

        public void Drink()
        {
            Console.WriteLine($"Tamagotchi is drinking.");
            actualAction = "Drink";
            satiationDrink = AdjustSatiation(satiationDrink, satiationIncrement);
        }

        public void Play()
        {
            Console.WriteLine($"Tamagotchi is playing.");
            actualAction = "Play";
            satiationPlay = AdjustSatiation(satiationPlay, satiationIncrement);
        }

        public void EarScratch()
        {
            Console.WriteLine($"Tamagotchi's ear is being scratched right now.");
            actualAction = "EarScratch";
            satiationEarScratch = AdjustSatiation(satiationEarScratch, satiationIncrement);
        }

        private sbyte AdjustSatiation(sbyte measure, sbyte increment)
        {
            modifiedMeasure = measure;
            
            if (measure + increment >= 0 && measure + increment <= 100)
            {
                modifiedMeasure += increment;
                ModifyWellBeing(actionOk);
            }
            else if (measure + increment < 0)
            {
                modifiedMeasure = 0;
                ModifyWellBeing(actionUnder);
            }
            else if (measure + increment > 100)
            {
                modifiedMeasure = 100;
                ModifyWellBeing(actionOver);
            }
            Console.WriteLine($"{actualAction} satiation modified from {measure} to {modifiedMeasure}.");
            return modifiedMeasure;
        }
    }
}
