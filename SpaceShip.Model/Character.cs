using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShip.Model
{
    public class Character
    {
        public string Name { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Armor { get; set; }
        public int Attack { get; set; }
        public bool IsActive { get; set; }
        public int CurrentXp { get; set; }
        public int CurrentLevel { get; set; }
        public int[] ToLevelUp { get; set; }  


        public Character(int maxHealth, int currentHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;
            
        }


    }
}
