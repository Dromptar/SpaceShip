using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShip.Model.Entities
{
    public class Character : Entity
    {

        public int MedipackQuantity { get; set; }
        public int ArmorImplantQuantity { get; set; }
        public int CurrentXp { get; set; }
        public int CurrentLevel { get; set; }
        public bool IsActive { get; set; }

        public Character(int maxHealth, int currentHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;
            MedipackQuantity = 2;
            ArmorImplantQuantity = 1;
            CurrentLevel = 1;
            CurrentXp = 0;
        }
    }
}
