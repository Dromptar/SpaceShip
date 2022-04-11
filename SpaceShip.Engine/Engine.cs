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
                
                


            },
            new Weapon
            {
                Name = "Laser Staff",
                MaxHealth = 6,
                Armor = 12,
                Damage = 6
            },
            new Weapon
            {
                Name = "Energy Shield",
                MaxHealth = 12,
                Armor = 14,
                Damage = 2
            }
        };

        public List<Monster> monsters_list = new List<Monster>
        {
            new Monster
            {
                Name = "Rancor",
                MaxHealth = 12,
                Armor = 2,
                Damage = 2
            },
            new Monster
            {
                Name = "Gretchin",
                MaxHealth = 5,
                Armor = 2,
                Damage = 3
            },
            new Monster
            {
                Name = "Droid",
                MaxHealth = 7,
                Armor = 1,
                Damage = 3
            }
        };



        public void GenerateMonster()
        {
            var rnd = new Random();
            int index = rnd.Next(monsters_list.Count);
            Appearing_monster = monsters_list[index];
        }

        public void MonsterAttack()
        {
            Selected_weapon.CurrentHealth = Selected_weapon.CurrentHealth - Appearing_monster.Damage;
        }


        public void WeaponAttack()
        {
            Appearing_monster.CurrentHealth = Appearing_monster.CurrentHealth - Selected_weapon.Damage;

        }

        public bool IsDead()
        {
            if (Appearing_monster.MaxHealth <= 0 || Selected_weapon.MaxHealth <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
