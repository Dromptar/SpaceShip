
using SpaceShip.Model;

namespace SpaceShip.Engine
{
    
    public class GameEngine
    {

        public Item Some_item { get; set; }
        public Profession Your_profession { get; set; }
        public Weapon Selected_weapon { get; set; } 
        public Monster Appearing_monster { get; set; } 



        public List<Profession> professions_list = new List<Profession>
        {
            new Profession(20, 20)
            {
                Name = "Soldier",
            //  MaxHealth = 20,
                Armor = 14,
                Attack = 2
            },
            new Profession(18, 18)
            {
                Name = "Smuggler",
             // MaxHealth = 18,
                Armor = 12,
                Attack = 4
            },
            new Profession(16, 16)
            {
                Name = "Alchimist",
                //MaxHealth = 16,
                Armor = 10,
                Attack = 6
            },

        };

        public List<Weapon> weapons_list = new List<Weapon>
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

        public List<Monster> monsters_list = new List<Monster>
        {
            new Monster()
            {
                Name = "Rancor",
                MaxHealth = 14,
                Armor = 13,
                MinDamage = 1,
                MaxDamage = 6,
            },
            new Monster()
            {
                Name = "Gretchin",
                MaxHealth = 5,
                Armor = 8,
                MinDamage = 1,
                MaxDamage = 4
            },
            new Monster()
            {
                Name = "Droid",
                MaxHealth = 7,
                Armor = 10,
                MinDamage = 1,
                MaxDamage = 6
            },
            new Monster()
            {
                Name = "Trandoshan",
                MaxHealth = 10,
                Armor = 12,
                MinDamage = 1,
                MaxDamage = 8
            }
        };

        public List<Item> items_list = new List<Item>
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

        // generating a random monster before each fight
        public void GenerateMonster()
        {
            var rnd = new Random();
            int index = rnd.Next(monsters_list.Count);
            Appearing_monster = monsters_list[index];
        }

        public DiceResult MonsterAttack()
        {
            DicesManager Some_Dice = new DicesManager();
            DiceResult roll = Some_Dice.RollDice(20, Your_profession.Armor);
            return roll;
        }

        public DiceResult CharacterAttack()
        {
            DicesManager Some_Dice = new DicesManager();
            DiceResult roll = Some_Dice.RollDice(20, Appearing_monster.Armor);
            return roll;
        }

        public int MonsterRandomDamage(Monster monster)
        {
            Random rnd = new Random();
            int Damage = rnd.Next(monster.MinDamage, monster.MaxDamage);
            return Damage;
        }

        public int MonsterDamage()
        {         
            int Damage = MonsterRandomDamage(Appearing_monster);
            Your_profession.CurrentHealth -= Damage;
            return Damage;
        }

        public int WeaponRandomDamage(Weapon weapon)
        {
            Random rnd = new Random();
            int Damage = rnd.Next(weapon.MinDamage, weapon.MaxDamage);
            return Damage;
        }
        public int WeaponDamage()
        {
            int Damage = WeaponRandomDamage(Selected_weapon);
            Appearing_monster.CurrentHealth -= Damage;
            return Damage;

        }

        public bool KeepFighting()
        {
            if (Your_profession.CurrentHealth > 0)
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
            int regainLife = PotionEffect(Some_item);
            Your_profession.CurrentHealth += regainLife;
            return regainLife;
        }

        public int ArmorPotion()
        {
            int increaseArmor = PotionEffect(Some_item);
            Your_profession.Armor += increaseArmor;
            return increaseArmor;
        }



    }
}
