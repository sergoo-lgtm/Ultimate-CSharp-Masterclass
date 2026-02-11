
namespace MAZEGAME
{
    internal class Emptyway:IMazeItem
    {
         string IMazeItem.Symbol { get => "⬜"; }
         bool IMazeItem.IsSolid { get => false; }

    }
}
