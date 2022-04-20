using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShip.Items
{
    public class Item
    {
        public string Name { get; set; }
        public int Quantity { get; set; }     
        public int MinEffect { get; set; } // Until now, how much you regain life
        public int MaxEffect { get; set; }

        public Item()
        {

        }

    }

    

}
