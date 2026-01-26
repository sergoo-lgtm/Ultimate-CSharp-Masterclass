using GameDataParser.INTERFACES;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace GameDataParser
{
    internal class GameDataParserApp
    {
        IFileReader _fileReader;
        IGameParser _gameParser;
        ILogger _logger;
        IUserInteractor _userInteractor;
        VideoGame _vediogame;
        public GameDataParserApp(IFileReader fileReader, IGameParser gameParser, ILogger logger, IUserInteractor userInteractor)
        {
            _fileReader = fileReader;
            _gameParser = gameParser;
            _logger = logger;
            _userInteractor = userInteractor;
        }


        public void Start() 
        {
          

            string filename = _userInteractor.GameName();
            

            string filecontent = _fileReader.read(filename);

            _vediogame = new VideoGame();
            _gameParser = new JsonGameParser();
            try
            {
               
                List<VideoGame> games = _gameParser.JsonParse(filecontent);
                _userInteractor.Gamedisplay(games);

            }
            catch (JsonException ex)
            {
                _logger.Log(ex.ToString());
                _userInteractor.ErrorMessage($"JSON in {filename} was not in valid format");
                Console.WriteLine("-----------------------------------------------------");

                int failline = (int)ex.LineNumber;

                string[] filelines = filecontent.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

                int startLine = Math.Max(0, failline - 3);
                int endLine = Math.Min(filelines.Length, failline + 5);

                
                
                for (int i = startLine; i < endLine; i++)
                {
                    string prefix;
                    if (i + 1 == failline) {  prefix = ">>>>>>>>"; }
                    else {  prefix = "        "; }
                    Console.WriteLine(prefix + filelines[i]);
                }

               
            }
            catch (Exception ex)
            {
                _userInteractor.ErrorMessage("An unexpected error occurred.");
                _logger.Log(ex.ToString());
            }

        }

    }
}
