using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShip.Model
{
    public class Entity
    {
        public string Name { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Armor { get; set; }
        public int Attack { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }

    }
}
