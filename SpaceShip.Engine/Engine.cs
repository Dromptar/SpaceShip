
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
                Armor = 14
            },
            new Profession(18, 18)
            {
                Name = "Smuggler",
             //   MaxHealth = 18,
                Armor = 12
            },
            new Profession(16, 16)
            {
               Name = "Alchimist",
             //   MaxHealth = 16,
                Armor = 10
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
            new Monster(12, 12)
            {
                Name = "Rancor",
                Armor = 2,
                MinDamage = 1,
                MaxDamage = 6
            },
            new Monster(5, 5)
            {
                Name = "Gretchin",
                Armor = 2,
                MinDamage = 1,
                MaxDamage = 4
            },
            new Monster(7, 7)
            {
                Name = "Droid",
                Armor = 1,
                MinDamage = 1,
                MaxDamage = 6
            },
            new Monster(10, 10)
            {
                Name = "Trandoshan",
                Armor = 1,
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


        public int MonsterRandomDamage(Monster monster)
        {
            Random rnd = new Random();
            int Damage = rnd.Next(monster.MinDamage, monster.MaxDamage);
            return Damage;
        }
        public int MonsterAttack()
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
        public int WeaponAttack()
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
