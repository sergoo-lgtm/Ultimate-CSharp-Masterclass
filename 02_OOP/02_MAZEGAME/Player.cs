
namespace MAZEGAME
{
    internal class Player:IMazeItem
    {
        public int x { get; set; }
        public int y { get; set; }
        public string sympol { get => "😋"; set; }

        bool IMazeItem.ISsolid => true;

        
    }
}
