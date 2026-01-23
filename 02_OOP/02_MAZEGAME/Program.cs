using MAZEGAME;
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("heloo to MAZE GAME!");
Console.WriteLine("use arrows to move the player");


Maze maze = new Maze(50,20);
while (true)
{
    maze.draw();
    maze.MovePlayer();
}

