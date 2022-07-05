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
        static InputManager inputManager = new InputManager();


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

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("To begin, what is your name ? ");
            string playerName= inputManager.GetPlayerString(2, 30);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Hi {playerName}. Choose your profession : ");
            Console.WriteLine();
            foreach (var job in engine.JobsList)
            {
                Console.WriteLine($"{engine.JobsList.IndexOf(job) + 1}. {job.Name}");
            }

            
            int playerChoice = inputManager.GetPlayerInteger(engine.JobsList.Select(job => engine.JobsList.IndexOf(job)+1).ToList());
                    

            Console.WriteLine($"You are a {engine.JobsList[playerChoice - 1].Name} !" + "\n" +
                              $"The {engine.JobsList[playerChoice - 1].Name} offers you {engine.JobsList[playerChoice - 1].MaxHealth} HP and {engine.JobsList[playerChoice - 1].Armor} of protection. ");
               

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();

            Console.WriteLine("Now, pick a weapon : ");
            Console.WriteLine();
            foreach (var weapon in engine.WeaponsList)
            {
                Console.WriteLine($"{engine.WeaponsList.IndexOf(weapon) + 1}. {weapon.Name}");
            }

            // When weapon is picked, we give some information to player
            int playerChoice2 = inputManager.GetPlayerInteger(engine.WeaponsList.Select(weap => engine.WeaponsList.IndexOf(weap)+1).ToList());
            
            Console.WriteLine($"You picked {engine.WeaponsList[playerChoice2 - 1].Name} !" + "\n" +
                              $"It's a powerful ally which deals between {engine.WeaponsList[playerChoice2 - 1].MinDamage} and {engine.WeaponsList[playerChoice2 - 1].MaxDamage} damages to an eventual target. " + "\n" +
                              $"Moreover, this weapon increases your natural armor by {engine.WeaponsList[playerChoice2 - 1].BonusArmor} points. ");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();

            Console.WriteLine("Oh, one more thing before you go. The Spaceship could be dangerous.");
            Console.WriteLine("You could meet some creatures during your trip, like  {0}", string.Join(", ", engine.MonstersList.Select(m => m.Name)));
            Console.WriteLine("Be Careful...");

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.WriteLine();
            Console.WriteLine($"Now , be brave and proud young {engine.JobsList[playerChoice - 1].Name} and let's fight the evil of the lost Spaceship with your new {engine.WeaponsList[playerChoice2 - 1].Name} ..." + "\n" +
                $"Ready?");
            Console.ReadKey(true);
            Console.Clear();

            engine.YourCharacterJob = engine.JobsList[playerChoice - 1];
            engine.SelectedWeapon = engine.WeaponsList[playerChoice2 - 1];
        }
            

        static void Fight()
        {
            
            // We generate a random monster and use the weapon picked up by player to start a fight
            engine.GenerateMonster();
            engine.AppearingMonster.CurrentHealth = engine.AppearingMonster.MaxHealth;

            Console.WriteLine($"You enter the room. It's dark, but you can see a big shadow in front of you. " +
                                $"Looks to be a {engine.AppearingMonster.Name}.");
            Console.WriteLine($"You grab your {engine.SelectedWeapon.Name} and a violent fight takes place!");
            Console.WriteLine($"This {engine.AppearingMonster.Name} has {engine.AppearingMonster.MaxHealth} HP.");
            Console.WriteLine($"You have {engine.YourCharacterJob.CurrentHealth} HP.");
            Console.ReadKey(true);
            Console.Clear();

            // Starting the fight
            // engine.Appearing_monster.CurrentHealth = engine.Appearing_monster.MaxHealth;

            while (engine.AppearingMonster.CurrentHealth >= 0 || engine.YourCharacterJob.CurrentHealth >= 0)
            {
                // Tour du monstre
               
                var MonsterAttack = engine.MonsterAttack();
                var CharacterAttack = engine.CharacterAttack();
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"You have {engine.YourCharacterJob.Armor + engine.SelectedWeapon.BonusArmor} of defense. {engine.AppearingMonster.Name} attacks and scores {MonsterAttack.Score}.");
                if (MonsterAttack.Success)
                {
                    Console.WriteLine($"The creature hurts you and you lose {engine.MonsterDamage()} Hp.");
                    Console.WriteLine($"You still have {engine.YourCharacterJob.CurrentHealth} HP.");
                }
                else
                {
                    Console.WriteLine("Missed!");
                }
                Console.WriteLine();
                Console.ReadKey(true);

                if (engine.YouLoseTheFight())
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("You received a huge strike over the head.");
                    Console.WriteLine("Game Over");
                    Environment.Exit(0);
                }

                // Tour du joueur
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"The {engine.AppearingMonster.Name} has {engine.AppearingMonster.Armor} of defense. You attack and score {CharacterAttack.Score}.");
                if (CharacterAttack.Success)
                {
                    Console.WriteLine($"You beat the creature and deals {engine.WeaponDamage()} damages!");
                    Console.WriteLine($"The {engine.AppearingMonster.Name} still have {engine.AppearingMonster.CurrentHealth} HP.");
                }
                else
                {
                    Console.WriteLine("Missed!");
                }
                Console.WriteLine();
                Console.ReadKey(true);

                if (engine.YouWinTheFight())
                { 
                    
                    engine.AddExperience();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"The {engine.AppearingMonster.Name} is dead. Well done! You won the fight!");
                    Console.WriteLine($"You still have {engine.YourCharacterJob.CurrentHealth} HP after the fight.");
                    Console.WriteLine($"You won {engine.AppearingMonster.XpValue} xp points and your xp is now {engine.YourCharacter.CurrentXp}");
                    if (engine.LevelUp())
                    {
                        Console.WriteLine($"Congratulation, you are now level {engine.YourCharacter.CurrentLevel}.");
                    }
                    break;
                }

            }
            Console.ReadKey(true);
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"What do you want to do ?"+ "\n" +
                              $"1. Use backpack"+ "\n" +
                              $"2. Next room!" + "\n" +
                              $"3. Exit Game");
            
            int playerChoice4 = inputManager.GetPlayerInteger(new List<int> { 1, 2, 3});
            if (playerChoice4 == 1)
            {
                foreach (var item in engine.ItemsList)
                {
                    Console.WriteLine($"{engine.ItemsList.IndexOf(item) + 1}. {item.Name}");
                }
                int playerChoice3 = inputManager.GetPlayerInteger(engine.JobsList.Select(pro => engine.JobsList.IndexOf(pro)).ToList());
                engine.SomeItem = engine.ItemsList[playerChoice3 - 1];

                switch (playerChoice3)
                {
                    case 1:
                        Console.WriteLine($"You use {engine.ItemsList[playerChoice3 - 1].Name} !" + "\n" +
                                            $"You regen {engine.Medipack()} HP." + "\n" +
                                            $"You feel better and now have {engine.YourCharacterJob.CurrentHealth} HP");
                        break;

                    case 2:
                        Console.WriteLine($"You use {engine.ItemsList[playerChoice3 - 1].Name} !" + "\n" +
                                          $"You increased your armor by {engine.ArmorImplant()} points." + "\n" +
                                          $"You feel stronger and now have {engine.YourCharacterJob.Armor} armor score.");
                        break;
                }

            }
            else if (playerChoice4 == 2)
            {
                engine.KeepFighting();
            }
            else if(playerChoice4 == 3)
            {
                Environment.Exit(0);
            }

            
        }



    }




}
