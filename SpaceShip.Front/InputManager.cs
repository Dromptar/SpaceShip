using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShip.Front
{
    public class InputManager
    {
        public int GetPlayerIntegerChoice()
        {
            int input = int.Parse(Console.ReadLine());

            return input;
        }

        public string GetPlayerStringChoice()
        {
            string input = Console.ReadLine();
            return input;
        }


    }
}
