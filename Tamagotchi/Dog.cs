using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi
{
    class Dog : Animal
    {
        public override void TimePass()
        {
            AdjustSatiationsOverTimeCycle();

            Console.WriteLine($"Satiations - eat: {GetSatiationEat()}, drink: {GetSatiationDrink()}" +
                $", play: {GetSatiationPlay()}, earScratch: {GetSatiationEarScratch()} ");
        }
    }
}
