using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShip.Engine
{
    public class Monster
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public int Damage { get; set; }

        public Monster(string Name, int Health, int Armor, int Damage)
        {
            Name = Name;
            Health = Health;
            Armor = Armor;
            Damage = Damage;
        }
    }
}
