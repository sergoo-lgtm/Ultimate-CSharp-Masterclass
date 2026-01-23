

namespace MAZEGAME
{
    internal class Walls : IMazeItem
    {
          string IMazeItem.sympol { get => "🧱"; }
         bool IMazeItem.ISsolid { get => true;}
    }
}
