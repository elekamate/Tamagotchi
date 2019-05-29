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
            SatiationEatModify(-3);
            SatiationDrinkModify(-10);
            SatiationPlayModify(-5);
            SatiationEarScratchModify(-1);
            Console.WriteLine($"Satiations - eat: {GetSatiationEat()}, drink: {GetSatiationDrink()}" +
                $", play: {GetSatiationPlay()}, earScratch: {GetSatiationEarScratch()} ");
        }
    }
}
