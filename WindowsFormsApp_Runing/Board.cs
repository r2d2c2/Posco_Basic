using System;

namespace WindowsFormsApp_Runing
{
    internal class Board
    {
        public TileType[,] _tile;
        public int _size;
        public enum TileType
        {
            Empty,
            Wall,
        }
        public void Initialize(int size)
        {
            _tile = new TileType[size, size];
            _size = size;
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (j == 0 || j == _size - 1 || i == 0 || i == size - 1)
                    {
                        _tile[i, j] = TileType.Wall;
                    }
                    else
                    {
                        _tile[i, j] = TileType.Empty;//갈수 있는 공간
                    }
                }
            }
        }
        public void Render()
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Console.ForegroundColor = GetTileColor(_tile[i, j]);
                    Console.Write('\u25cf');
                }
                Console.WriteLine();
            }
        }
        ConsoleColor GetTileColor(TileType type)
        {
            switch (type)
            {
                case TileType.Empty:
                    return ConsoleColor.Green;
                case TileType.Wall:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.Green;
            }
        }

    }
}
