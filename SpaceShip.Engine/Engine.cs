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
                Damage = 10
            },
            new Weapon
            {
                Name = "Laser Staff",
                MaxHealth = 6,
                Armor = 12,
                Damage = 10
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
                MaxHealth = 4,
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
                MaxHealth = 6,
                Armor = 1,
                Damage = 3
            }
        };

                 

    }
}