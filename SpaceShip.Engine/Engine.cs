namespace SpaceShip_Engine
{

    public class Engine
    {

        public Weapon Selected_weapon { get; set; } // null
        public Monster Appearing_monster { get; set; } // null


        public List<Weapon> weapons_list = new List<Weapon>
        {

            new Weapon
            {
                Name = "Blaster",
                MaxHealth = 8,
                Armor = 10,
                MinDamage = 1,
                MaxDamage = 10
            },
            new Weapon
            {
                Name = "Laser Staff",
                MaxHealth = 6,
                Armor = 12,
                MinDamage = 1,
                MaxDamage = 6
            },
            new Weapon
            {
                Name = "Energy Shield",
                MaxHealth = 12,
                Armor = 14,
                MinDamage = 1,
                MaxDamage = 4
            }
        };

        public List<Monster> monsters_list = new List<Monster>
        {
            new Monster
            {
                Name = "Rancor",
                MaxHealth = 12,
                Armor = 2,
                MinDamage = 1,
                MaxDamage = 8
            },
            new Monster
            {
                Name = "Gretchin",
                MaxHealth = 5,
                Armor = 2,
                MinDamage = 1,
                MaxDamage = 4
            },
            new Monster
            {
                Name = "Droid",
                MaxHealth = 7,
                Armor = 1,
                MinDamage = 1,
                MaxDamage = 6
            }
        };
   

        public int WeaponRandomDamage(Weapon weapon)
        {
            Random rnd = new Random();
            int Damage = rnd.Next(weapon.MinDamage, weapon.MaxDamage);
            return Damage;
        }

        public int MonsterRandomDamage(Monster monster)
        {
            Random rnd = new Random();
            int Damage = rnd.Next(monster.MinDamage, monster.MaxDamage);
            return Damage;
        }

        public void GenerateMonster()
        {
            var rnd = new Random();
            int index = rnd.Next(monsters_list.Count);
            Appearing_monster = monsters_list[index];
        }

        public void MonsterAttack()
        {
            Selected_weapon.CurrentHealth -= MonsterRandomDamage(Appearing_monster);

        }

        public void WeaponAttack()
        {
            Appearing_monster.CurrentHealth -= WeaponRandomDamage(Selected_weapon);

        }



        
    }
}
