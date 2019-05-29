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
            satiationEat -= 3;
            satiationDrink -= 10;
            satiationPlay -= 5;
            satiationEarScratch -= 1;
            Console.WriteLine($"Satiations - eat: {satiationEat}, drink: {satiationEat}_" +
                $", play: {satiationPlay}, earScratch: {satiationEarScratch} ");
        }
    }
}
