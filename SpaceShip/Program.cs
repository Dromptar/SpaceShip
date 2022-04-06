using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SpaceShip_Engine
{

    class Program 
    {

        static void Main()
        {
            Engine engine = new Engine();
            Menu();    
        }


        static void Menu()
        {
            Engine engine = new Engine();
            
            // Here is the menu to pick you weapon
            Console.WriteLine("Welcome to SpaceShip !");
            Console.WriteLine();
            Console.WriteLine("Press any key to start the game...");
            Console.ReadKey(true);
            Console.WriteLine();

            Console.WriteLine("Choose your weapon : ");
            foreach (var weapon in engine.weapons_list)
            {
                Console.WriteLine($"{engine.weapons_list.IndexOf(weapon) + 1}. {weapon.Name}");
            }
            Console.WriteLine("4. Quitter;");

            // When weapon is picked, we give some information to player
            int playerChoice = int.Parse(Console.ReadLine());
            Console.WriteLine($"You picked {engine.weapons_list[playerChoice - 1].Name} !" + "\n" +
                              $"The {engine.weapons_list[playerChoice - 1].Name} offers you {engine.weapons_list[playerChoice - 1].MaxHealth} points of life and {engine.weapons_list[playerChoice - 1].Armor} of protection " + "\n" +
                              $"It also permits to deal {engine.weapons_list[playerChoice - 1].Damage} damages to an eventual target ");
            Console.WriteLine();
            Console.WriteLine("Oh, one last thing before you go. The Spaceship could be dangerous.");
            Console.WriteLine("You could meet some creatures during your trip, like  {0}", string.Join(", ", engine.monsters_list.Select(m => m.Name)));
            Console.WriteLine("Be Careful...");
            Console.WriteLine();

            Console.WriteLine($"Now let's fight the evil of the lost Spaceship with your new {engine.weapons_list[playerChoice - 1].Name} ..." + "\n" +
                $"Ready?");
            Console.ReadKey(true);
            Console.Clear();

            //We generate a random monster and use the weapon picked up by player to start a fight
            engine.Selected_weapon = engine.weapons_list[playerChoice - 1];
            engine.GenerateMonster();

            Console.WriteLine($"You enter in the first room. It's dark, but you can see a big shadow in front of you. " +
                              $"Looks to be a {engine.Appearing_monster.Name}.");
            Console.WriteLine($"You grab your {engine.Selected_weapon.Name} and a violent fight takes place!");
            Console.WriteLine($"This {engine.Appearing_monster.Name} has {engine.Appearing_monster.MaxHealth} point of life.");
            
            // Starting the fight
            engine.Fight();
            Console.WriteLine($"After your strike the {engine.Appearing_monster.Name} has {engine.Appearing_monster.MaxHealth} point of life.");





        }




    }
}