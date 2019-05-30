using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi
{
    static class AnimalFactory
    {
        public static Animal Create(ConsoleKeyInfo consoleInput)
        {
            if (consoleInput.Key == ConsoleKey.C)
            {
                return new Cat();
            }
            else
            {
                Console.WriteLine($"---Dog has been created successfully!---");
                return new Dog();
            }
        }
    }
}
