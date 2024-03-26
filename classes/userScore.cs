using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game.classes
{
    internal class userScore
    {
        public int score {  get; set; }
        public string userName { get; set; }
        public userScore(string userName, int score) 
        {
            this.userName = userName;
            this.score = score;
        }
    }
}
