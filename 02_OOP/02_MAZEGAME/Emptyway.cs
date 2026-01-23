
namespace MAZEGAME
{
    internal class Emptyway:IMazeItem
    {
         string IMazeItem.sympol { get => "⬜"; }
         bool IMazeItem.ISsolid { get => false; }

    }
}
