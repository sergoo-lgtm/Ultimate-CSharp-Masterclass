using System;
using System.Collections.Generic;
using System.Text;

namespace GameDataParser.INTERFACES
{
    internal interface IUserInteractor
    {
        string GameName();
        void Gamedisplay(List<VideoGame> games);
        void ErrorMessage(string message);
    }
}
