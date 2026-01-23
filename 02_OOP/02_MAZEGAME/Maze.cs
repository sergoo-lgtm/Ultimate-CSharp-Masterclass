
using System.ComponentModel.Design;

namespace MAZEGAME
{
    internal class Maze
    {
        int _width;
        int _height;

        Player _player;

        IMazeItem[,] arrOfmazeShape;

        public Maze(int width, int height)
        {   _width = width;
            _height = height;
            arrOfmazeShape = new IMazeItem[_width, _height];
             _player = new Player();
            _player.x = 1;
            _player.y = 1;
        }



        public void MovePlayer()
        {
            var userInput  = Console.ReadKey();
            var key = userInput.Key;
            
            switch(key)
            {
                case ConsoleKey.UpArrow:
                    UpdatePlayer(0,-1);
                    break;
                case ConsoleKey.DownArrow:
                    UpdatePlayer(0, 1);
                    break;
                case ConsoleKey.LeftArrow:
                    UpdatePlayer(-1, 0);
                    break;
                case ConsoleKey.RightArrow:
                    UpdatePlayer(1 , 0);
                    break;

            }

        }





        private void UpdatePlayer(int dx , int dy)
        {
           
           int newX = _player.x + dx;
           int newY = _player.y + dy;

            if (newX < _width && newX>=0&& newY >= 0 && newY < _height && arrOfmazeShape[newX, newY].ISsolid == false)
            { 
                _player.x = newX; 
                _player.y = newY;
                draw();
            }

        }



        public void draw()
        {

            Console.Clear();
            for (int y = 0; y < _height; y++)
            {
                

                for (int x = 0; x < _width; x++) 
                {
                    if (x == _width -1 && y == _height -1)
                    {
                       arrOfmazeShape[x, y] = new Emptyway();
                        Console.Write(arrOfmazeShape[x, y].sympol);
                       

                    }
                    if (x == _width - 2 && y == _height - 2)
                    {
                        arrOfmazeShape[x, y] = new Emptyway();
                        Console.Write(arrOfmazeShape[x, y].sympol);


                    }


                    else if (x == 0 || y == 0 || x == _width - 1 || y == _height - 1)
                    {
                        arrOfmazeShape[x, y] = new Walls();
                        Console.Write(arrOfmazeShape[x, y].sympol);
                    }
                    else if (x == _player.x && y == _player.y)
                    {
                        Console.Write(_player.sympol);
                    }
                    else if (x %5  == 0 && y % 5 == 0)
                    {
                        arrOfmazeShape[x, y] = new Walls();
                        Console.Write(arrOfmazeShape[x, y].sympol);
                    }
                    else if (x % 2 == 0 && y % 3 == 0)
                    {
                        arrOfmazeShape[x, y] = new Walls();
                        Console.Write(arrOfmazeShape[x, y].sympol);
                    }
                    else
                    {
                        arrOfmazeShape[x, y] = new Emptyway();
                        Console.Write(arrOfmazeShape[x, y].sympol);
                    }


                }



                Console.WriteLine();

            }



        }




    }
}
