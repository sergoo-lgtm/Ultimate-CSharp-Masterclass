using GameDataParser.INTERFACES;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace GameDataParser
{

    internal class ConsoleUserInteractor : IUserInteractor
    {
        public string userinput;
         string IUserInteractor.GameName()
        {

            while (true)
            {
                Console.WriteLine("Enter the name of the file you want to read : \n[games.json OR gamesInvalidFormat.json]");

                userinput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userinput))
                {
                    Console.WriteLine("File name cannot be Empty. ");
                    continue;
                }

                if (!File.Exists(userinput))
                {
                    Console.WriteLine("file not found");
                    continue;

                }
                return userinput;
                    break; 

            }

        }



    



         void IUserInteractor.ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(message);

            Console.ResetColor();
        }

        void IUserInteractor.Gamedisplay(List<VideoGame> games)
        {
            Console.WriteLine("loaded games are ");
            foreach (var game in games)
            {
                Console.WriteLine($"Title : {game.Title},ReleaseYear : {game.ReleaseYear},Rating : {game.Rating} ");
            }
            Console.WriteLine("Enter Any Key To Exist...");
        }
    }
}
