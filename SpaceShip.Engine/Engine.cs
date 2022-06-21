
using SpaceShip.Model;

namespace SpaceShip.Engine
{

    public class GameEngine
    {
        public Item SomeItem { get; set; }
        public Character YourCharacter { get; set; }
        public Weapon SelectedWeapon { get; set; }
        public Monster AppearingMonster { get; set; }
        public DicesManager DicesManager { get; set; }

        public List<Character> ProfessionsList
        {
            get
            {
                return professionsList.Where(pro => pro.IsActive).ToList();
            }

        }

        private List<Character> professionsList = new List<Character>
        {
            new Character(20, 20)
            {
                Name = "Soldier",
                CurrentLevel = 1,
            //  MaxHealth = 20,
                Armor = 14,
                Attack = 2,
                IsActive = true
            },
            new Character(18, 18)
            {
                Name = "Smuggler",
                CurrentLevel = 1,
             // MaxHealth = 18,
                Armor = 12,
                Attack = 4,
                IsActive = true
            },
            new Character(16, 16)
            {
                Name = "Alchimist",
                CurrentLevel = 1,
                //MaxHealth = 16,
                Armor = 10,
                Attack = 6,
                IsActive = true
            },
            new Character(50, 50)
            {
                Name = "Chuck",
                //MaxHealth = 16,
                Armor = 40,
                Attack = 30,
                IsActive = false
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
            }
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
                Attack = 4
            },
            new Monster()
            {
                Name = "Gretchin",
                MaxHealth = 5,
                Armor = 8,
                MinDamage = 1,
                MaxDamage = 4,
                Attack = 1
            },
            new Monster()
            {
                Name = "Droid",
                MaxHealth = 7,
                Armor = 10,
                MinDamage = 1,
                MaxDamage = 6,
                Attack = 2
            },
            new Monster()
            {
                Name = "Trandoshan",
                MaxHealth = 10,
                Armor = 12,
                MinDamage = 1,
                MaxDamage = 8,
                Attack = 3
            }
        };

        public List<Item> ItemsList = new List<Item>
        {
            new Item
            {
                Name = "Health Potion",
                Quantity = 1,
                MinEffect = 1,
                MaxEffect = 8
            },
            new Item
            {
                Name = "Armor Potion",
                Quantity = 1,
                MinEffect = 1,
                MaxEffect = 6
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

        public DiceResult MonsterAttack()
        {
            int heroArmor = YourCharacter.Armor + SelectedWeapon.BonusArmor;
            DiceResult roll = DicesManager.RollDice(20, heroArmor, AppearingMonster.Attack);
            return roll;
        }

        public DiceResult CharacterAttack()
        {
            DiceResult roll = DicesManager.RollDice(20, AppearingMonster.Armor, YourCharacter.Attack);
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
            YourCharacter.CurrentHealth -= damage;
            return damage;
        }

        public int WeaponRandomDamage(Weapon weapon)
        {
            Random rnd = new Random();
            int damage = rnd.Next(weapon.MinDamage, weapon.MaxDamage);
            return damage;
        }
        public int WeaponDamage()
        {
            int damage = WeaponRandomDamage(SelectedWeapon);
            AppearingMonster.CurrentHealth -= damage;
            return damage;

        }

        public bool KeepFighting()
        {
            if (YourCharacter.CurrentHealth > 0)
                return true;
            else
                return false;
        }

        public int PotionEffect(Item item)
        {
            Random rnd = new Random();
            int potionEffect = rnd.Next(item.MinEffect, item.MaxEffect);
            return potionEffect;
        }

        public int HealthPotion()
        {
            int regainLife = PotionEffect(SomeItem);
            YourCharacter.CurrentHealth += regainLife;
            return regainLife;
        }

        public int ArmorPotion()
        {
            int increaseArmor = PotionEffect(SomeItem);
            YourCharacter.Armor += increaseArmor;
            return increaseArmor;
        }

        public void AddExperience()
        {
            bool monsterIsDead = AppearingMonster.CurrentHealth <= 0;
            var neededXp = YourCharacter.CurrentLevel * 100 * 1.25;

            if(monsterIsDead)
            {
               YourCharacter.CurrentXp =+ 25;
                
                if(YourCharacter.CurrentXp >= neededXp)
                {
                    YourCharacter.CurrentLevel++;
                    LevelUp();
                }
            }

        }

        public void LevelUp()
        {
            //Here comes new stats modifications

        }
       
    }
 }
