using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi
{
    class Dog : Animal
    {
        private ConsoleKey keyToWalk = ConsoleKey.W;

        public Dog()
        {
            charsToActions.Add('s', EarScratch);
        }

        public override void TimePass()
        {
            AdjustSatiationsOverTimeCycle();

            Console.WriteLine($"Satiations - eat: {GetSatiationEat()}, drink: {GetSatiationDrink()}" +
                $", play: {GetSatiationPlay()}, earScratch: {GetSatiationEarScratch()} ");
        }

        public override void PrintCreatedMessage()
        {
            PrintCreatedMessageBase();
            Console.WriteLine($"Press 'W' key to walk him.");
            Console.WriteLine($"----------------------------------------");
        }
    }
}
