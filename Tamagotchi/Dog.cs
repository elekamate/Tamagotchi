using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi
{
    class Dog : Animal, IWalkable
    {
        private char keyToWalk = 'w';
        private sbyte satiationWalk = 100;
        protected sbyte satiationWalkIncrementOverTimeCycle = -2;

        public Dog()
        {
            charsToActions.Add(keyToWalk, Walk);
        }

        public override void PrintCreatedMessage()
        {
            PrintCreatedMessageBase();
            Console.WriteLine($"---Write '{keyToWalk}' char to walk him.");
            Console.WriteLine($"------------------------------------------------");
        }

        public override void TimePass()
        {
            Console.WriteLine("");
            Console.WriteLine("---TimeCycle passed.----------------------------------------------------");
            AdjustSatiationsOverTimeCycle();
            Console.WriteLine($"Satiations - eat: {satiationEat}, drink: {satiationDrink}" +
                $", play: {satiationPlay}, earScratch: {satiationEarScratch}, walk: {satiationWalk}");
            Console.WriteLine($"WellBeing: {wellBeing}");
            Console.WriteLine("------------------------------------------------------------------------");
        }

        protected override void AdjustSatiationsOverTimeCycle()
        {
            AdjustSatiationsOverTimeCycleBase();
            actualAction = "Walk";
            satiationWalk = AdjustSatiation(satiationWalk, satiationWalkIncrementOverTimeCycle);
        }

        public void Walk()
        {
            Console.WriteLine($"Tamagotchi is being walked.");
            actualAction = "Walk";
            satiationWalk = AdjustSatiation(satiationWalk, satiationIncrement);
        }
    }
}
