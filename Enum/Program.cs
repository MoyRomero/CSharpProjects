using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enum
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Player player1 = new Player(Difficulty.Easy);
            Player player2 = new Player(Difficulty.Medium);
            Player player3 = new Player(Difficulty.Hard);
        }        
    }
    class Player
    {
        public Player(Difficulty x)
        {
            switch (x)
            {

                case Difficulty.Easy:
                    Console.WriteLine("You have 3 minutes 45 seconds");
                    break;

                case Difficulty.Medium:
                    Console.WriteLine("You have 3 minutes 20 seconds");
                    break;

                case Difficulty.Hard:
                    Console.WriteLine("You have 3 minutes");
                    break;
            }

        }
    }

    enum Difficulty
    {
        Easy,
        Medium,
        Hard
    };



}
