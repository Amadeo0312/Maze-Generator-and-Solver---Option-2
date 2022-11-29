using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MazeGUI
{
    [Flags]
    public enum Direction
    {
        N = 1,
        S = 2,
        E = 4,
        W = 8
    }

    public class Maze
    {
        private const int _rowDimension = 0;
        private const int _columnDimension = 1;

        public int RowSize { get; private set; }
        public int ColSize { get; private set; }
        public int[,] Cells { get; private set; }

        public enum GeneratorType
        {
            RecursiveBackTracker,
            DepthFirstSearch,
            BreadthFirstSearch
        }

        public Maze(int rows, int columns)
        {
            RowSize = rows;
            ColSize = columns;
            Cells = Init(rows, columns);
        }

        public int[,] Init(int rows, int columns)
        {
            int[,] cells = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    cells[i, j] = 0;
                }
            }

            return cells;
        }

        private readonly Dictionary<Direction, int> DirectionX = new Dictionary<Direction, int>
                                                                      {
                                                                          {Direction.N, 0},
                                                                          {Direction.S, 0},
                                                                          {Direction.E, 1},
                                                                          {Direction.W, -1}
                                                                      };

        private readonly Dictionary<Direction, int> DirectionY = new Dictionary<Direction, int>
                                                                      {
                                                                          {Direction.N, -1},
                                                                          {Direction.S, 1},
                                                                          {Direction.E, 0},
                                                                          {Direction.W, 0}
                                                                      };

        private readonly Dictionary<Direction, Direction> Opposite = new Dictionary<Direction, Direction>
                                                                           {
                                                                               {Direction.N, Direction.S},
                                                                               {Direction.S, Direction.N},
                                                                               {Direction.E, Direction.W},
                                                                               {Direction.W, Direction.E}
                                                                           };

        public int[,] Generate(GeneratorType algorithm)
        {
            int[,] cells = Cells;

            switch (algorithm)
            {
                case GeneratorType.RecursiveBackTracker:
                    RecursiveBacktracker(0, 0, ref cells);
                    break;
                case GeneratorType.DepthFirstSearch:
                    DepthFirstSearch(new Point(0, 0));
                    break;
                case GeneratorType.BreadthFirstSearch:
                    BreadthFirstSearch(new Point(0, 0));
                    break;
            }

            return cells;
        }

        public void DepthFirstSearch(Point start)
        {
            Stack<Point> cellStack = new Stack<Point>();
            int totalCells = RowSize * ColSize;
            int visitedCells = 1;
            Point current = start;

            while (visitedCells < totalCells)
            {
                var directions = new List<Direction>
                                 {
                                     Direction.N,
                                     Direction.S,
                                     Direction.E,
                                     Direction.W
                                 }
                                 .OrderBy(x => Guid.NewGuid());

                int nx = 0;
                int ny = 0;
                Direction selected = new Direction();

                foreach (var d in directions)
                {
                    nx = current.X + DirectionX[d];
                    ny = current.Y + DirectionY[d];

                    if (IsOutOfBounds(ny, nx, Cells))
                        continue;

                    if (Cells[ny, nx] == 0)
                    {
                        selected = d;
                        break;
                    }
                }

                if (selected == Direction.N || selected == Direction.S || selected == Direction.E || selected == Direction.W)
                {
                    Cells[current.Y, current.X] |= (int)selected;
                    Cells[ny, nx] |= (int)Opposite[selected];

                    cellStack.Push(new Point(nx, ny));
                    current.X = nx;
                    current.Y = ny;
                    visitedCells++;
                }
                else
                {
                    Point newCurrent = cellStack.Pop();
                    current.X = newCurrent.X;
                    current.Y = newCurrent.Y;
                }
            }
        }

        public void BreadthFirstSearch(Point start)
        {
            Queue<Point> cellStack = new Queue<Point>();
            int totalCells = RowSize * ColSize;
            int visitedCells = 1;
            Point current = start;

            while (visitedCells < totalCells)
            {
                var directions = new List<Direction>
                                 {
                                     Direction.N,
                                     Direction.S,
                                     Direction.E,
                                     Direction.W
                                 }
                                 .OrderBy(x => Guid.NewGuid());

                int nx = 0;
                int ny = 0;
                Direction selected = new Direction();

                foreach (var d in directions)
                {
                    nx = current.X + DirectionX[d];
                    ny = current.Y + DirectionY[d];

                    if (IsOutOfBounds(ny, nx, Cells))
                        continue;

                    if (Cells[ny, nx] == 0)
                    {
                        selected = d;
                        break;
                    }
                }

                if (selected == Direction.N || selected == Direction.S || selected == Direction.E || selected == Direction.W)
                {
                    Cells[current.Y, current.X] |= (int)selected;
                    Cells[ny, nx] |= (int)Opposite[selected];

                    cellStack.Enqueue(new Point(nx, ny));
                    current.X = nx;
                    current.Y = ny;
                    visitedCells++;
                }
                else
                {
                    Point newCurrent = cellStack.Dequeue();
                    current.X = newCurrent.X;
                    current.Y = newCurrent.Y;
                }
            }
        }


        public void RecursiveBacktracker(int cy, int cx, ref int[,] grid)
        {
            var directions = new List<Direction>
                                 {
                                     Direction.N,
                                     Direction.S,
                                     Direction.E,
                                     Direction.W
                                 }
                                 .OrderBy(x => Guid.NewGuid());

            foreach (var direction in directions)
            {
                int nx = cx + DirectionX[direction];
                int ny = cy + DirectionY[direction];

                if (IsOutOfBounds(ny, nx, grid))
                    continue;

                if (grid[ny, nx] != 0)
                    continue;

                grid[cy, cx] |= (int)direction;
                grid[ny, nx] |= (int)Opposite[direction];

                RecursiveBacktracker(ny, nx, ref grid);
            }
        }

        public static bool IsOutOfBounds(int y, int x, int[,] grid)
        {
            return x < 0 || x > grid.GetLength(_columnDimension) - 1 || y < 0 || y > grid.GetLength(_rowDimension) - 1;
        }
    }
}