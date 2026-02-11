using MAZEGAME;
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Hello to MAZE GAME!");
Console.WriteLine("Use arrows to move the player");


Maze maze = new Maze(50,20);
while (true)
{
    maze.Draw();
    maze.MovePlayer();
}

