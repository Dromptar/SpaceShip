using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SpaceShip.Front
{
    public class InputManager
    {


        //public int GetPlayerIntegerChoice(List<int> myList)
        //{
        //    int number;
        //    string value = Console.ReadLine();
        //    bool success = int.TryParse(value, out number);
        //    var exists = myList.Contains(number);
        //    while (!success && !exists)
        //    {
        //        Console.WriteLine($"{value} is not a number. Please try again.");
        //        // offer again posibility to choice
        //        value = Console.ReadLine();
        //        success = int.TryParse(value, out number);

        //    }
        //        return number;  
        //}

        public int GetPlayerInteger(List<int> acceptableValues)
        {
            int number;
            bool isValueANumber;
            bool isValueInAcceptableValues;

            do
            {
                string value = Console.ReadLine();
                isValueANumber = int.TryParse(value, out number);
                isValueInAcceptableValues = acceptableValues.Contains(number);

                if (!isValueANumber)
                {
                    Console.WriteLine($"{value} is not a number.");
                }
                else if (!isValueInAcceptableValues)
                {
                    Console.WriteLine($"{value} is not an available choice.");
                }

            }
            while (!isValueANumber || !isValueInAcceptableValues);

            return number;
        }


        public string GetPlayerString(int minLength, int maxLength)
        {
            string value;

            do
            {
                value = Console.ReadLine();

                if (value.Length <= minLength)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Invalid entry. Needs to contain between 2 and 30 caracters. Please type again.");
                }
                else if (value.Length >= maxLength)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Invalid entry. Needs to contain between 2 and 30 caracters. Please type again.");
                }

            }
            while (value.Length <= minLength || value.Length >= maxLength);

            return value;
        }
    }


 }

