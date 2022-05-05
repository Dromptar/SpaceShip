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
            int number;
            string value = Console.ReadLine();
            bool success = int.TryParse(value, out number);
            while (!success)
            {
                Console.WriteLine($"{value} is not a number. Please try again.");
                // offer again posibility to choice
                break;
            }
            return number;
             
        }


        public string GetPlayerStringChoice()
        {
            string input = Console.ReadLine();
            return input;
        }


    }
}
