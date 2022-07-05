
using SpaceShip.Model;

namespace SpaceShip.Engine
{

    public class GameEngine
    {
        public Item SomeItem { get; set; }
        public Character YourCharacter { get; set; }
        public Job YourCharacterJob { get; set; }
        public Weapon SelectedWeapon { get; set; }
        public Monster AppearingMonster { get; set; }
        public DicesManager DicesManager { get; set; }

        public List<Job> JobsList
        {
            get
            {
                return jobsList.Where(pro => pro.IsActive).ToList();
            }

        }

        private List<Job> jobsList = new List<Job>
        {
            new Job(14, 14)
            {
                Name = "Soldier",
                Armor = 14,
                Attack = 4,
                IsActive = true
            },
            new Job(12, 12)
            {
                Name = "Smuggler",
                Armor = 12,
                Attack = 6,
                IsActive = true
            },
            new Job(10, 10)
            {
                Name = "Alchimist",
                Armor = 10,
                Attack = 8,
                IsActive = true
            },
            new Job(25, 25)
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
                XpValue = 30
            },
            new Monster()
            {
                Name = "Gretchin",
                MaxHealth = 5,
                Armor = 8,
                MinDamage = 1,
                MaxDamage = 4,
                Attack = 1,
                XpValue = 15
            },
            new Monster()
            {
                Name = "Droid",
                MaxHealth = 7,
                Armor = 10,
                MinDamage = 1,
                MaxDamage = 6,
                Attack = 2,
                XpValue = 20
            },
            new Monster()
            {
                Name = "Trandoshan",
                MaxHealth = 10,
                Armor = 12,
                MinDamage = 1,
                MaxDamage = 8,
                Attack = 3,
                XpValue = 25
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
        }

        // generating a random monster before each fight
        public void GenerateMonster()
        {
            var rnd = new Random();
            int index = rnd.Next(MonstersList.Count);
            AppearingMonster = MonstersList[index];
        }


        /**********************  Fighting system  **********************/

        public DiceResult MonsterAttack()
        {
            int heroArmor = YourCharacterJob.Armor + SelectedWeapon.BonusArmor;
            DiceResult roll = DicesManager.RollDice(20, heroArmor, AppearingMonster.Attack);
            return roll;
        }

        public DiceResult CharacterAttack()
        {
            DiceResult roll = DicesManager.RollDice(20, AppearingMonster.Armor, YourCharacterJob.Attack);
            return roll;
        }

        public int MonsterRandomDamage(Monster monster)
        {
            Random rnd = new Random();
            int damage = rnd.Next(monster.MinDamage, monster.MaxDamage);
            return damage;
        }

        public int MonsterDamage()
        {
            int damage = MonsterRandomDamage(AppearingMonster);
            YourCharacterJob.CurrentHealth -= damage;
            if (YourCharacterJob.CurrentHealth < 0)
            {
                YourCharacterJob.CurrentHealth = 0;
            }
            return damage;
        }

        public int WeaponRandomDamage(Weapon weapon)
        {
            Random rnd = new Random();
            int damage = rnd.Next(weapon.MinDamage, weapon.MaxDamage);
            if(damage == 20)
            {
                return damage * 2;
            }
            return damage;
        }
        public int WeaponDamage()
        {
            int damage = WeaponRandomDamage(SelectedWeapon);
            AppearingMonster.CurrentHealth -= damage;
            if(AppearingMonster.CurrentHealth < 0)
            {
                AppearingMonster.CurrentHealth = 0;
            }
            return damage;
        }

        public bool KeepFighting()
        {
            if (YourCharacterJob.CurrentHealth > 0)
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
            return YourCharacterJob.CurrentHealth <= 0;
        }

        /**********************  Items / Inventory system  **********************/
        public int ItemEffect(Item item)
        {
            Random rnd = new Random();
            int itemEffect = rnd.Next(item.MinEffect, item.MaxEffect);
            return itemEffect;
        }

        public int Medipack()
        {
            int regainLife = ItemEffect(SomeItem);
            if(YourCharacter.MedipackQuantity > 0)
            {
                YourCharacterJob.CurrentHealth += regainLife;

                if (YourCharacterJob.CurrentHealth > YourCharacterJob.MaxHealth)
                {
                    YourCharacterJob.CurrentHealth = YourCharacterJob.MaxHealth;
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
            YourCharacter.Armor += increaseArmor;
            return increaseArmor;
        }

        /**********************  Leveling System  **********************/
        public void AddExperience()
        {
            YourCharacter.CurrentXp += AppearingMonster.XpValue;
        }

        public bool LevelUp()
        {
            //Here comes new stats modifications
            var neededXp = YourCharacter.CurrentLevel * 100 * 1.25;
            if (YourCharacter.CurrentXp >= neededXp)
            {
                YourCharacter.CurrentLevel++;
                YourCharacterJob.CurrentHealth += 5;
                YourCharacter.Attack += 2;
                YourCharacter.Armor += 2;
                return true;
            }
            else
                return false;
        }
       
    }
 }
