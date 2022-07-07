using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShip.Model
{
    public class Item
    {
        public string Name { get; set; }
        public int Quantity { get; set; }     
        public int MinEffect { get; set; } 
        public int MaxEffect { get; set; }

        public Item()
        {

        }

    }

    

}
