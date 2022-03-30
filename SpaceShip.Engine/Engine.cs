namespace SpaceShip_Engine
{

    public class Engine
    {

        public Engine selected_weapon = new Engine();

        public List<Weapon> weapons = new List<Weapon>
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

       


        //Monster wolf = new Monster("Wolf", 4, 2, 2);
        //Monster orc = new Monster("Orc", 5, 2, 3);
        //Monster zombie = new Monster("Zombie", 6, 1, 3);


    }
}