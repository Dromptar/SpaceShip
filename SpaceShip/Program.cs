using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceShip.Engine;


namespace SpaceShip.Front
{

    class Program 
    {

        static GameEngine engine = new GameEngine();

        static void Main()
        {
            Menu();
            
            while(engine.KeepFighting())
            {
               Fight();
            }
            
        }


        static void Menu()
        {

            // Here is the menu to pick you weapon
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome to SpaceShip !");
            Console.WriteLine();
            Console.WriteLine("Press any key to start the game...");
            Console.ReadKey(true);
            Console.WriteLine();

            Console.WriteLine("To begin, choose your profession : ");
            Console.WriteLine();
            foreach (var profession in engine.professions_list)
            {
                Console.WriteLine($"{engine.professions_list.IndexOf(profession) + 1}. {profession.Name}");
            }
            int playerChoice1 = int.Parse(Console.ReadLine());
            Console.WriteLine($"You are a {engine.professions_list[playerChoice1 - 1].Name} !" + "\n" +
                              $"The {engine.professions_list[playerChoice1 - 1].Name} offers you {engine.professions_list[playerChoice1 - 1].MaxHealth} HP and {engine.professions_list[playerChoice1 - 1].Armor} of protection. ");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();

            Console.WriteLine("Now, pick a weapon : ");
            Console.WriteLine();
            foreach (var weapon in engine.weapons_list)
            {
                Console.WriteLine($"{engine.weapons_list.IndexOf(weapon) + 1}. {weapon.Name}");
            }

            // When weapon is picked, we give some information to player
            int playerChoice2 = int.Parse(Console.ReadLine());
            Console.WriteLine($"You picked {engine.weapons_list[playerChoice2 - 1].Name} !" + "\n" +
                              $"It's a powerful ally which deals between {engine.weapons_list[playerChoice2 - 1].MinDamage} and {engine.weapons_list[playerChoice2 - 1].MaxDamage} damages to an eventual target. ");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();

            Console.WriteLine("Oh, one more thing before you go. The Spaceship could be dangerous.");
            Console.WriteLine("You could meet some creatures during your trip, like  {0}", string.Join(", ", engine.monsters_list.Select(m => m.Name)));
            Console.WriteLine("Be Careful...");

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.WriteLine();
            Console.WriteLine($"Now , be brave and proud young {engine.professions_list[playerChoice1 - 1].Name} and let's fight the evil of the lost Spaceship with your new {engine.weapons_list[playerChoice2 - 1].Name} ..." + "\n" +
                $"Ready?");
            Console.ReadKey(true);
            Console.Clear();

            engine.Your_profession = engine.professions_list[playerChoice1 - 1];
            engine.Selected_weapon = engine.weapons_list[playerChoice2 - 1];
        }
            

        static void Fight()
        {
            
            // We generate a random monster and use the weapon picked up by player to start a fight
            engine.GenerateMonster();
            engine.Appearing_monster.CurrentHealth = engine.Appearing_monster.MaxHealth;

            Console.WriteLine($"You enter in the first room. It's dark, but you can see a big shadow in front of you. " +
                                $"Looks to be a {engine.Appearing_monster.Name}.");
            Console.WriteLine($"You grab your {engine.Selected_weapon.Name} and a violent fight takes place!");
            Console.WriteLine($"This {engine.Appearing_monster.Name} has {engine.Appearing_monster.MaxHealth} HP.");
            Console.WriteLine($"You have {engine.Your_profession.CurrentHealth} HP.");
            Console.ReadKey(true);
            Console.Clear();

            // Starting the fight
            // engine.Appearing_monster.CurrentHealth = engine.Appearing_monster.MaxHealth;

            while (engine.Appearing_monster.CurrentHealth >= 0 || engine.Your_profession.CurrentHealth >= 0)
            {
                // Tour du monstre
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"The {engine.Appearing_monster.Name} attacks and deals {engine.MonsterAttack()} damages.");
                Console.WriteLine($"You still have {engine.Your_profession.CurrentHealth} HP.");
                Console.WriteLine();
                Console.ReadKey(true);

                if (engine.Your_profession.CurrentHealth <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("You received a huge strike over the head.");
                    Console.WriteLine("Game Over");
                    break;
                }

                // Tour du joueur
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You beat the creature and deals {engine.WeaponAttack()} damages!");
                Console.WriteLine($"The {engine.Appearing_monster.Name} still have {engine.Appearing_monster.CurrentHealth} HP.");
                Console.WriteLine();
                Console.ReadKey(true);

                if (engine.Appearing_monster.CurrentHealth <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"The {engine.Appearing_monster.Name} is dead. Congratulation! You won the fight!");
                    Console.WriteLine($"You still have {engine.Your_profession.CurrentHealth} HP after the fight.");
                    break;
                }

            }
            Console.ReadKey(true);
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Would you like to use some item from your backpack? (O/N)");
            string input = Console.ReadLine().ToUpper();
            if (input == "O")
            {
                foreach (var item in engine.items_list)
                {
                    Console.WriteLine($"{engine.items_list.IndexOf(item) + 1}. {item.Name}");
                }
                int playerChoice3 = int.Parse(Console.ReadLine());
                engine.Some_item = engine.items_list[playerChoice3 - 1];

                switch (playerChoice3)
                {
                    case 1:
                        Console.WriteLine($"You use {engine.items_list[playerChoice3 - 1].Name} !" + "\n" +
                                            $"You regen {engine.HealthPotion()} HP." + "\n" +
                                            $"You feel better and now have {engine.Your_profession.CurrentHealth} HP");
                        break;

                    case 2:
                        Console.WriteLine($"You use {engine.items_list[playerChoice3 - 1].Name} !" + "\n" +
                                            $"You increased your armor by {engine.ArmorPotion()} points." + "\n" +
                                            $"You feel stronger and now have {engine.Your_profession.Armor} armor score.");
                        break;
                }

            }
            else if (input == "N")
            {
                engine.KeepFighting();
            }

            
        }



    }




}
