using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShip.Model
{
    public class DiceResult
    {
        public Dice Dice { get; set; }
        public int Score { get; set; }
        public bool Success { get; set; }

        public DiceResult()
        {

        }

    }
}
