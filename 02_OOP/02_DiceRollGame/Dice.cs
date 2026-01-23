using System;
using System.Collections.Generic;
using System.Text;

namespace Dice_Roll_Game
{
    internal class Dice
    {


        Random random = new Random();
        public int Roll ()
        {
            return random.Next(1, 7); 
        }

    }
}
