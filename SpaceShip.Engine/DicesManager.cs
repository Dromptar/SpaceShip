using SpaceShip.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShip.Engine
{
    public class DicesManager
    {
        public List<Dice> DicesList { get; set; }

        public DiceResult RollDice(int maxScore, int tresHold, int bonus)
        {
            Random rnd = new Random();
            DiceResult rollDice = new DiceResult();
            Dice dice = DicesList.First(x => x.MaxScore == maxScore);
            int result = rnd.Next(1, maxScore) + bonus;
            bool touched = result >= tresHold;

            rollDice.Dice = dice;
            rollDice.Score = result;
            rollDice.Success = touched;

            return rollDice;
        }

        public DicesManager()
        {
            DicesList = new List<Dice>
                {
                    new Dice()
                    {
                        Name = "D20",
                        MaxScore = 20
                    }
                };
        }
    }
}
