using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShip.Model
{
    public class DicesManager
    {
        public List<Dice> dices_list = new List<Dice>
        {
            new Dice()
            {
                Name = "D20",
                MaxScore = 20
            }
        };

        public DiceResult RollDice(int maxScore, int tresHold, int bonus)
        {
            Random rnd = new Random();
            DiceResult Roll_Dice = new DiceResult();
            Dice dice = dices_list.First(x => x.MaxScore == maxScore);
            int result = rnd.Next(1, maxScore) + bonus;
            bool touched = result > tresHold;

            Roll_Dice.Dice = dice;
            Roll_Dice.Score = result;
            Roll_Dice.Success = touched;

            return Roll_Dice;
        }

        public DicesManager()
        {
            
        }


    }

    
}
