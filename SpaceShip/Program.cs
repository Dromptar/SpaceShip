using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        Menu();
    }

    static void Menu()
    {
        Console.WriteLine("Welcome to SpaceShip !");
        Console.WriteLine();
        Console.WriteLine("Choose your weapon : ");
        Console.WriteLine("1. Blaster");
        Console.WriteLine("2. Laser Staff");
        Console.WriteLine("3. Energy Shield");
        Console.WriteLine("4. Quitter;");
        Console.WriteLine();

        switch (Console.ReadLine())
        {
            case "1":
                Console.WriteLine($"You picked {SpaceShip.Engine.Weapon.blaster.Name} !");
                break;

            case "2":
                Console.WriteLine("You picked the Laser Staff !");
                break;

            case "3":
                Console.WriteLine("You picked the Energy Shield !");
                break;
        }
    }
}