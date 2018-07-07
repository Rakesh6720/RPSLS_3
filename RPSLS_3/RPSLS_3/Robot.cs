using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS_3
{
    class Robot : Player
    {

        public int RoboRoll()
        {
            Random num = new Random();
            int roboRoll = num.Next(0, 4);
            return roboRoll;
        }
        public void RoboPlayerPlays()
        {
            //Console.WriteLine(this.Name + ", choose your weapon:");
           
            this.Weapon = this.RoboRoll();

        }
    }
}
