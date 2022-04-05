namespace SpaceShip_Engine
{

    public class Engine
    {
        
        public Weapon Selected_weapon { get; set; }
        public Monster Appearing_monster { get; set; }

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

        public void Fight()
        {
            var random = new Random();
            int index = random.Next(monsters_list.Count);

            Console.WriteLine($"You enter in the first room. It's dark, but you can see a big shadow in front of you. Seems to be a {engine.monsters_list[index].Name}");

            while(Selected_weapon.CurrentHealth > 0 && Appearing_monster.CurrentHealth > 0)
            {
                Attack();

                if(Selected_weapon.MaxHealth <= 0)
                {
                    Console.WriteLine("Game Over");
                } 
                else if(Appearing_monster.MaxHealth <= 0)
                {
                    Console.WriteLine("Bravo, vous avez vaincu ce monstre!");
                }

            } 

        }

        public void Attack()
        {
            Appearing_monster.CurrentHealth = Appearing_monster.MaxHealth - Selected_weapon.Damage;
            Selected_weapon.CurrentHealth = Selected_weapon.MaxHealth - Appearing_monster.Damage;


        }

        

    }
}