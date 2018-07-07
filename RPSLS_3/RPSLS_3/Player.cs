using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS_3
{
    class Player
    {
        string name;
        int score;
        int weapon;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
        }
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                this.score = value;
            }
        }
        
        public int Weapon
        {
            get
            {
                return weapon;
            }
            set
            {
                this.weapon = value;
            }
        }
    }
}
