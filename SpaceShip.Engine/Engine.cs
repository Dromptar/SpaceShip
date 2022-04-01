namespace SpaceShip_Engine
{

    public class Engine
    {

        public Weapon Selected_weapon { get; set; }
        public Monster Selected_monster { get; set; }

        public List<Weapon> weapons_list = new List<Weapon>
        {
            new Weapon
            {
                Name = "Blaster",
                Health = 8,
                Armor = 10,
                Damage = 10
            },
            new Weapon
            {
                Name = "Laser Staff",
                Health = 6,
                Armor = 12,
                Damage = 10
            },
            new Weapon
            {
                Name = "Energy Shield",
                Health = 2,
                Armor = 14,
                Damage = 12
            }
        };

        public List<Monster> monsters_list = new List<Monster>
        {
            new Monster
            {
                Name = "Rancor",
                Health = 4,
                Armor = 2,
                Damage = 2
            },
            new Monster
            {
                Name = "Gretchin",
                Health = 5,
                Armor = 2,
                Damage = 3
            },
            new Monster
            {
                Name = "Droid",
                Health = 6,
                Armor = 1,
                Damage = 3
            }
        };

    }
}