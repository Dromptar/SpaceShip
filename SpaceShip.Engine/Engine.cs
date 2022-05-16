﻿
using SpaceShip.Model;

namespace SpaceShip.Engine
{
    
    public class GameEngine
    {
        public Item SomeItem { get; set; }
        public Profession YourCharacter { get; set; }
        public Weapon SelectedWeapon { get; set; } 
        public Monster AppearingMonster { get; set; }
        public DicesManager DicesManager { get; set; }

        public List<Profession> ProfessionsList 
        { 
            get
            {
                return professionsList.Where(pro => pro.IsActive).ToList();
            }

        }

        private List<Profession> professionsList = new List<Profession>
        {
            new Profession(20, 20)
            {
                Name = "Soldier",
            //  MaxHealth = 20,
                Armor = 14,
                Attack = 2,
                IsActive = true
            },
            new Profession(18, 18)
            {
                Name = "Smuggler",
             // MaxHealth = 18,
                Armor = 12,
                Attack = 4,
                IsActive = false
            },
            new Profession(16, 16)
            {
                Name = "Alchimist",
                //MaxHealth = 16,
                Armor = 10,
                Attack = 6,
                IsActive = true
            },

        };

        public List<Weapon> WeaponsList = new List<Weapon>
        {

            new Weapon
            {
                Name = "Blaster",
                MinDamage = 1,
                MaxDamage = 10
            },
            new Weapon
            {
                Name = "Laser Staff",
                MinDamage = 1,
                MaxDamage = 6
            },
            new Weapon
            {
                Name = "Energy Shield",
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
            DiceResult roll = DicesManager.RollDice(20, YourCharacter.Armor, AppearingMonster.Attack);
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
    }
}
