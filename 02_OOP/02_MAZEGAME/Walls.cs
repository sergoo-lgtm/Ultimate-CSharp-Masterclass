

namespace MAZEGAME
{
    internal class Walls : IMazeItem
    {
          string IMazeItem.Symbol { get => "🧱"; }
         bool IMazeItem.IsSolid { get => true;}
    }
}
