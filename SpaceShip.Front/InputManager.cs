using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SpaceShip.Front
{
    public class InputManager
    {



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
            bool isValueTooShort;
            bool isValueTooLong;

            do
            {
                value = Console.ReadLine();
                isValueTooShort = value.Length <= minLength;
                isValueTooLong = value.Length >= maxLength;

                if (isValueTooShort || isValueTooLong)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Invalid entry. Needs to contain between 2 and 30 caracters. Please type again.");
                }

            }
            while (isValueTooShort || isValueTooLong);

            return value;
        }


        public bool GetPlayerBool(string positiveChoice, string negativeChoice)
        {
            string value;

            do
            {
                value = Console.ReadLine().ToUpper();

                if ( value == positiveChoice)
                {
                    return true;
                    
                }
                else if( value == negativeChoice)
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid answer. Type again.");
                }
                
            }
            while (true);
        }
    }

 }

