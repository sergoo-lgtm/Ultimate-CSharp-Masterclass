using System;
using System.Collections.Generic;
using System.Text;

namespace GameDataParser.INTERFACES
{
    internal interface IGameParser
    {
        List<VideoGame> JsonParse(string filecontent);
    }
}
