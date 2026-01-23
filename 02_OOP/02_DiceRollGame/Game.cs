using System;
using System.Collections.Generic;
using System.Text;

namespace Dice_Roll_Game
{

    internal class Game
    {
        Dice dice;     
        Player player; 
        int maxTries = 3;
        string Userinput;
        public void start() 
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Guess a number between 1 and 6!🎲");


            dice = new Dice();
            player = new Player();
            
            int randomnumber =dice.Roll();
            
            for (int i = 0; i < maxTries; i++)
            {
                Userinput = Console.ReadLine();
                var x = player.Isnumber(Userinput, out int output);

                if (!x) 
                { 
                    i = i - 1; 
                    Console.ForegroundColor = ConsoleColor.Red; 
                    Console.WriteLine("invalid input 😅 \nplease inter number 👌\n"); 
                    Console.ResetColor(); 
                }

                else if ( output == randomnumber) 
                {
                    Console.ForegroundColor = ConsoleColor.Green; 
                    Console.WriteLine("you win 🎉"); 
                    Console.ResetColor(); 
                    break;  
                }
                else if (i == 2) 
                { 
                    Console.WriteLine("you lose 😢"); 
                    Console.WriteLine($" the number was *****{randomnumber}*****"); 
                }

                else 
                { 
                    int triesLeft = maxTries - (i + 1); 
                    Console.ForegroundColor = ConsoleColor.Yellow; 
                    Console.WriteLine("\ntry again 😒\n"); 
                    Console.WriteLine("["+new string('*', triesLeft)+"] => " + triesLeft +  " tries is left\n"); 
                    Console.ResetColor(); 
                }
                
            }

        }

    }
}
