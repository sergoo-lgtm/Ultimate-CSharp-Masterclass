
namespace MAZEGAME
{
    internal class Player:IMazeItem
    {
        public int x { get; set; }
        public int y { get; set; }
        public string Symbol { get; set; } = "😋";

        bool IMazeItem.IsSolid => true;

        
    }
}
