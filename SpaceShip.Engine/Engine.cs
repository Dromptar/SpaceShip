
using SpaceShip.Model;
using SpaceShip.Model.Entities;

namespace SpaceShip.Engine
{

    public class GameEngine
    {
        public Item SomeItem { get; set; }
        public Character SelectedCharacter { get; set; }
        public Weapon SelectedWeapon { get; set; }
        public Monster AppearingMonster { get; set; }
        public DicesManager DicesManager { get; set; }
        private Random rnd { get; set; }
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

        public List<Weapon> WeaponsList = new List<Weapon>
        {

            new Weapon
            {
                Name = "Blaster",
                BonusArmor = 1,
                MinDamage = 1,
                MaxDamage = 10
            },
            new Weapon
            {
                Name = "Laser Staff",
                BonusArmor = 3,
                MinDamage = 1,
                MaxDamage = 6
            },
            new Weapon
            {
                Name = "Energy Shield",
                BonusArmor = 5,
                MinDamage = 1,
                MaxDamage = 4
            },
            new Weapon
            {
                Name = "BFG",
                BonusArmor = 10,
                MinDamage = 1,
                MaxDamage = 12
            },
        };

        public List<Monster> MonstersList = new List<Monster>
        {
            new Monster()
            {
                Name = "Rancor",
                MaxHealth = 14,
                Armor = 13,
                MinDamage = 1,
                MaxDamage = 6,
                Attack = 4,
                XpValue = 50
            },
            new Monster()
            {
                Name = "Gretchin",
                MaxHealth = 5,
                Armor = 8,
                MinDamage = 1,
                MaxDamage = 4,
                Attack = 1,
                XpValue = 25
            },
            new Monster()
            {
                Name = "Droid",
                MaxHealth = 7,
                Armor = 10,
                MinDamage = 1,
                MaxDamage = 6,
                Attack = 2,
                XpValue = 30
            },
            new Monster()
            {
                Name = "Trandoshan",
                MaxHealth = 10,
                Armor = 12,
                MinDamage = 1,
                MaxDamage = 8,
                Attack = 3,
                XpValue = 40
            }
        };

        public List<Item> ItemsList = new List<Item>
        {
            new Item
            {
                Name = "Medipack",
                Quantity = 1,
                MinEffect = 1,
                MaxEffect = 8
            },
            new Item
            {
                Name = "Armor implant",
                Quantity = 1,
                MinEffect = 1,
                MaxEffect = 4
            }

        };

        public GameEngine() // constructor
        {
            DicesManager = new DicesManager();
            rnd = new Random();
        }

        public void PickCharacter(Character character)
        {
            SelectedCharacter = character;
        }

        public void PickWeapon(Weapon weapon)
        {
            SelectedWeapon = weapon;
        }

        // generating a random monster before each fight
        public void GenerateMonster()
        {
            int index = rnd.Next(MonstersList.Count);
            AppearingMonster = MonstersList[index];
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
            int damage = rnd.Next(monster.MinDamage, monster.MaxDamage);
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

        public int WeaponRandomDamage(Weapon weapon)
        {
            int damage = rnd.Next(weapon.MinDamage, weapon.MaxDamage);
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
        public int ItemEffect(Item item)
        {
            int itemEffect = rnd.Next(item.MinEffect, item.MaxEffect);
            return itemEffect;
        }

        public int Medipack()
        {
            int regainLife = ItemEffect(SomeItem);
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
            int increaseArmor = ItemEffect(SomeItem);
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
