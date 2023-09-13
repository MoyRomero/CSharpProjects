using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverload
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Score tm1 = new Score(2, 3);
            Score tm2 = new Score(4, 2);

            Score finalScores = tm1 + tm2;

            Console.WriteLine("Round 1: " + finalScores.round1Score);
            Console.WriteLine("Round 2: " + finalScores.round2Score);

        }
    }
    
    class Score{

        public int round1Score { get; set; }
        public int round2Score { get; set; }
        public Score(int r1, int r2){

            round1Score = r1;
            round2Score = r2;
        }

        public static Score operator+(Score tm1, Score tm2){

            int re1 = tm1.round1Score + tm2.round1Score;
            int re2 = tm1.round2Score + tm2.round2Score;

            Score res = new Score(re1, re2);

            return res;
        }
    }
}

    
