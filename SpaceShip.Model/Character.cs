using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShip.Model
{
    public class Character : Entity
    {

        public int MedipackQuantity { get; set; }
        public int ArmorImplantQuantity { get; set; }
        public int CurrentXp { get; set; }
        public int CurrentLevel { get; set; }
        public int[] ToLevelUp { get; set; }  


        public Character()
        {
            
            MedipackQuantity = 2;
            ArmorImplantQuantity = 1;
            CurrentLevel = 1;
            CurrentXp = 0;

        }


    }
}
