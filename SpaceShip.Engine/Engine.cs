
using SpaceShip.Model;
using SpaceShip.Model.Entities;
using SpaceShip.Model.Items;

namespace SpaceShip.Engine
{

    public class GameEngine
    {
        public Serums Serum { get; set; }
        public Character SelectedCharacter { get; set; }
        public StarterWeapon SelectedWeapon { get; set; }
        public Monster AppearingMonster { get; set; }
        public DicesManager DicesManager { get; set; }
        private Random Rnd { get; set; }
        public List<Character> AvailableCharactersList
        {
            get
            {
                return availableCharactersList.Where(pro => pro.IsActive).ToList();
            }

        }

        private List<Character> availableCharactersList = new List<Character>
        {
            new Character(16, 16)
            {
                Name = "Soldier",
                Armor = 14,
                Attack = 4,
                IsActive = true
            },
            new Character(14, 14)
            {
                Name = "Smuggler",
                Armor = 12,
                Attack = 6,
                IsActive = true
            },
            new Character(12, 12)
            {
                Name = "Alchimist",
                Armor = 10,
                Attack = 8,
                IsActive = true
            },
            new Character(25, 25)
            {
                Name = "GodMod",
                Armor = 40,
                Attack = 30,
                IsActive = true
            },

        };

        public List<StarterWeapon> WeaponsList = new List<StarterWeapon>
        {

            new StarterWeapon
            {
                Name = "Blaster",
                BonusArmor = 1,
                MinDamage = 1,
                MaxDamage = 10
            },
            new StarterWeapon
            {
                Name = "Laser Staff",
                BonusArmor = 3,
                MinDamage = 1,
                MaxDamage = 6
            },
            new StarterWeapon
            {
                Name = "Energy Shield",
                BonusArmor = 5,
                MinDamage = 1,
                MaxDamage = 4
            },
            new StarterWeapon
            {
                Name = "BFG",
                BonusArmor = 10,
                MinDamage = 1,
                MaxDamage = 12
            },
        };
        public List<Monster> EarlyGameMonsters 
        {
            get
            {
                return AllMonstersList.Where(mon => mon.Difficulty == 1).ToList();
            }
        }
        public List<Monster> MidGameMonsters
        {
            get
            {
                return AllMonstersList.Where(mon => mon.Difficulty == 2).ToList();
            }
        }
        public List<Monster> EndGameMonsters
        {
            get
            {
                return AllMonstersList.Where(mon => mon.Difficulty == 3).ToList();
            }
        }

        private List<Monster> AllMonstersList = new List<Monster>
        {
            new Monster()
            {
                Name = "Gretchin",
                MaxHealth = 5,
                Armor = 8,
                MinDamage = 1,
                MaxDamage = 4,
                Attack = 1,
                Difficulty = 1,
                XpValue = 25
            },
            new Monster()
            {
                Name = "Zerg",
                MaxHealth = 7,
                Armor = 10,
                MinDamage = 1,
                MaxDamage = 6,
                Attack = 2,
                Difficulty = 1,
                XpValue = 30
            },
            new Monster()
            {
                Name = "Space Pirate",
                MaxHealth = 8,
                Armor = 11,
                MinDamage = 1,
                MaxDamage = 6,
                Attack = 4,
                Difficulty = 1,
                XpValue = 30
            },
            new Monster()
            {
                Name = "Fellworm",
                MaxHealth = 4,
                Armor = 14,
                MinDamage = 1,
                MaxDamage = 8,
                Attack = 2,
                Difficulty = 1,
                XpValue = 30
            },
            new Monster()
            {
                Name = "Mutant",
                MaxHealth = 8,
                Armor = 14,
                MinDamage = 1,
                MaxDamage = 8,
                Attack = 4,
                Difficulty = 2,
                XpValue = 40
            },
            new Monster()
            {
                Name = "Klingon",
                MaxHealth = 10,
                Armor = 12,
                MinDamage = 1,
                MaxDamage = 8,
                Attack = 3,
                Difficulty = 2,
                XpValue = 40
            },
            new Monster()
            {
                Name = "Crazy ingeneer",
                MaxHealth = 10,
                Armor = 10,
                MinDamage = 1,
                MaxDamage = 8,
                Attack = 6,
                Difficulty = 2,
                XpValue = 45
            },
            new Monster()
            {
                Name = "Rancor",
                MaxHealth = 18,
                Armor = 14,
                MinDamage = 1,
                MaxDamage = 10,
                Attack = 8,
                Difficulty = 3,
                XpValue = 50
            },
            new Monster()
            {
                Name = "Shadow beast",
                MaxHealth = 15,
                Armor = 14,
                MinDamage = 1,
                MaxDamage = 10,
                Attack = 6,
                Difficulty = 3,
                XpValue = 50
            },
        };

        public List<Serums> SerumsList = new List<Serums>
        {
            new Serums
            {
                Name = "Health Serum",
                Quantity = 1,
                MinEffect = 1,
                MaxEffect = 8
            },
            new Serums
            {
                Name = "Steel Skin",
                Quantity = 1,
                MinEffect = 1,
                MaxEffect = 4
            }

        };

        public GameEngine() // constructor
        {
            DicesManager = new DicesManager();
            Rnd = new Random();
        }

        public void PickCharacter(Character character)
        {
            SelectedCharacter = character;
        }

        public void PickWeapon(StarterWeapon weapon)
        {
            SelectedWeapon = weapon;
        }

        // generating a random monster before each fight scaling the hero level
        public void GenerateMonster()
        {
            List<Monster> myList = MonstersList();
            int index = Rnd.Next(myList.Count);
            AppearingMonster = myList[index];
            
        }

        public List<Monster> MonstersList()
        {
            switch (SelectedCharacter.CurrentLevel)
            {
                case <= 3:
                    return EarlyGameMonsters;

                case <= 6:
                    return MidGameMonsters;

                case > 6:
                    return EndGameMonsters;

            }
        }

        /**********************  Fighting system  **********************/

        public DiceResult MonsterAttack()
        {
            int heroArmor = SelectedCharacter.Armor + SelectedWeapon.BonusArmor;
            DiceResult roll = DicesManager.RollDice(20, heroArmor, AppearingMonster.Attack);
            return roll;
        }

        public DiceResult CharacterAttack()
        {
            DiceResult roll = DicesManager.RollDice(20, AppearingMonster.Armor, SelectedCharacter.Attack);
            return roll;
        }

        public int MonsterRandomDamage(Monster monster)
        {
            int damage = Rnd.Next(monster.MinDamage, monster.MaxDamage);
            return damage;
        }

        public int MonsterDamage()
        {
            int damage = MonsterRandomDamage(AppearingMonster);
            SelectedCharacter.CurrentHealth -= damage;
            if (SelectedCharacter.CurrentHealth < 0)
            {
                SelectedCharacter.CurrentHealth = 0;
            }
            return damage;
        }

        public int WeaponRandomDamage(StarterWeapon weapon)
        {
            int damage = Rnd.Next(weapon.MinDamage, weapon.MaxDamage);
            if (damage == 20)
            {
                return damage * 2;
            }
            return damage;
        }
        public int WeaponDamage()
        {
            int damage = WeaponRandomDamage(SelectedWeapon);
            AppearingMonster.CurrentHealth -= damage;
            if (AppearingMonster.CurrentHealth < 0)
            {
                AppearingMonster.CurrentHealth = 0;
            }
            return damage;
        }

        public bool KeepFighting()
        {
            if (SelectedCharacter.CurrentHealth > 0)
                return true;
            else
                return false;
        }

        public bool YouWinTheFight()
        {
            return AppearingMonster.CurrentHealth <= 0;
        }

        public bool YouLoseTheFight()
        {
            return SelectedCharacter.CurrentHealth <= 0;
        }

        /**********************  Items / Inventory system  **********************/
        public int ItemEffect(Serums item)
        {
            int itemEffect = Rnd.Next(item.MinEffect, item.MaxEffect);
            return itemEffect;
        }

        public int Medipack()
        {
            int regainLife = ItemEffect(Serum);
            if (SelectedCharacter.MedipackQuantity > 0)
            {
                SelectedCharacter.CurrentHealth += regainLife;

                if (SelectedCharacter.CurrentHealth > SelectedCharacter.MaxHealth)
                {
                    SelectedCharacter.CurrentHealth = SelectedCharacter.MaxHealth;
                }
            }
            else
            {
                Console.WriteLine("You are out of Medipack !");
            }
            return regainLife;
        }

        public int ArmorImplant()
        {
            int increaseArmor = ItemEffect(Serum);
            SelectedCharacter.Armor += increaseArmor;
            return increaseArmor;
        }

        /**********************  Leveling System  **********************/
        public void AddExperience()
        {
            SelectedCharacter.CurrentXp += AppearingMonster.XpValue;
        }

        public bool LevelUp()
        {
            //Here comes new stats modifications
            var neededXp = SelectedCharacter.CurrentLevel * 100 * 1.25;
            if (SelectedCharacter.CurrentXp >= neededXp)
            {
                SelectedCharacter.CurrentLevel++;
                SelectedCharacter.MaxHealth += 5;
                SelectedCharacter.CurrentHealth = SelectedCharacter.MaxHealth;
                SelectedCharacter.Attack += 2;
                SelectedCharacter.Armor += 2;
                return true;
            }
            else
                return false;
        }

    }
}
