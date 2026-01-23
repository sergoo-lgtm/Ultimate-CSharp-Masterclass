using System;
using System.Collections.Generic;
using System.Text;

namespace Dice_Roll_Game
{
    internal class Player
    {
        

        public bool Isnumber(string userInput, out int output)
        {
            bool valid = int.TryParse(userInput, out output);
            if (!valid) 
            { 
                output = -1;  return false; 
            }
            else 
            {  
                return  true; 
            }
        }


    }
}
