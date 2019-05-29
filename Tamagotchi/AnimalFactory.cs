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
            switch (consoleInput.Key)
            {
                case ConsoleKey.C:
                    Console.WriteLine($"Cat has been created successfully!");
                    return new Cat();
                case ConsoleKey.D:
                    Console.WriteLine($"Dog has been created successfully!");
                    return new Dog();
                default:
                    return new Cat();
            }
        }
    }
}
