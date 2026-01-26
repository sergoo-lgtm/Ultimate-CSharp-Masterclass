using GameDataParser.INTERFACES;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace GameDataParser
{
    internal class JsonGameParser:IGameParser
    {
        public List<VideoGame> JsonParse(string filecontent )
        {
            List<VideoGame> games = JsonSerializer.Deserialize<List<VideoGame>>(filecontent);

            return games;

        }
    }
}
