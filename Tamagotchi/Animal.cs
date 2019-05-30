using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi
{
    abstract class Animal
    {
        protected sbyte wellBeing = 100;
        protected sbyte satiationIncrement = 10;
        protected sbyte satiationEat = 100;
        protected sbyte satiationDrink = 100;
        protected sbyte satiationPlay = 100;
        protected sbyte satiationEarScratch = 100;

        protected Dictionary<char, Action> charsToActions;
        protected sbyte actionOver = -10;
        protected sbyte actionOk = 30;
        protected sbyte actionUnder = -20;

        protected sbyte satiationEatIncrementOverTimeCycle = -3;
        protected sbyte satiationDrinkIncrementOverTimeCycle = -10;
        protected sbyte satiationPlayIncrementOverTimeCycle = -5;
        protected sbyte satiationEarScratchIncrementOverTimeCycle = -1;

        protected char keyToEat = 'e';
        protected char keyToDrink = 'd';
        protected char keyToPlay = 'p';
        protected char keyToEarScratch = 's';
        protected char keyToStopTime = 'x';

        protected string actualAction;
        protected sbyte origWellBeing;
        protected sbyte modifiedMeasure;

        public Animal()
        {
            charsToActions = new Dictionary<char, Action>();
            charsToActions.Add('x', StopTime);
            charsToActions.Add('e', Eat);
            charsToActions.Add('d', Drink);
            charsToActions.Add('p', Play);
            charsToActions.Add('s', EarScratch);
        }


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

        public void DoAction(string consoleLineInput)
        {
            foreach (KeyValuePair<char, Action> item in charsToActions)
            {
                if (consoleLineInput.ToLower().Contains(item.Key))
                {
                    item.Value();
                }
            }
        }

        public void CheckAndModifyWellbeing()
        {

        }

        public virtual void PrintCreatedMessage()
        {
            PrintCreatedMessageBase();
            Console.WriteLine($"---------------------------------------------");
        }

        protected void PrintCreatedMessageBase()
        {
            Console.WriteLine("");
            Console.WriteLine($"-----Cat has been created successfully!------");
            Console.WriteLine($"---Write 'x' char to stop the time.----------");
            Console.WriteLine($"---Write 'e' char to feed him.---------------");
            Console.WriteLine($"---Write 'd' char to give him water.---------");
            Console.WriteLine($"---Write 'p' char to play with him.----------");
            Console.WriteLine($"---Write 's' char to scratch his ears.-------");
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
            if (origWellBeing != wellBeing)
            {
                Console.WriteLine($"Wellbeing modified from {origWellBeing} to {wellBeing}.");
            }
        }

        public virtual void TimePass()
        {
            Console.WriteLine("");
            Console.WriteLine("---TimeCycle passed.----------------------------------------------------");
            AdjustSatiationsOverTimeCycle();
            Console.WriteLine($"Satiations - eat: {satiationEat}, drink: {satiationDrink}" +
                $", play: {satiationPlay}, earScratch: {satiationEarScratch} ");
            Console.WriteLine($"WellBeing: {wellBeing}");
            Console.WriteLine("------------------------------------------------------------------------");
        }

        public void StopTime()
        {
            Tamagotchi.timeIntervallProvider.Enabled = false;
        }

        protected virtual void AdjustSatiationsOverTimeCycle()
        {
            AdjustSatiationsOverTimeCycleBase();
        }

        protected void AdjustSatiationsOverTimeCycleBase()
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

        protected sbyte AdjustSatiation(sbyte measure, sbyte increment)
        {
            modifiedMeasure = measure;
            
            if (measure + increment >= 0 && measure + increment <= 100)
            {
                modifiedMeasure += increment;
            }
            else if (measure + increment < 0)
            {
                modifiedMeasure = 0;
            }
            else if (measure + increment > 100)
            {
                modifiedMeasure = 100;
            }

            if (measure + increment == 100)
            {
                ModifyWellBeing(actionOk);
            }
            else if (measure + increment <= 50)
            {
                ModifyWellBeing(actionUnder);
            }
            else if (measure + increment > 100)
            {
                ModifyWellBeing(actionOver);
            }

            Console.WriteLine($"{actualAction} satiation modified from {measure} to {modifiedMeasure}.");
            return modifiedMeasure;
        }
    }
}
