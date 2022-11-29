using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MazeGUI
{
    public partial class Main : Form
    {
        private const int _rowDimension = 0;
        private const int _columnDimension = 1;
        public Color wall = Color.Black;
        public readonly Random rand = new Random();
        public Maze maze;
        private int solverSteps;
        private SolverType solverMethod;
        private Stack<Point> solverAgenda;
        private HashSet<Point> solverHistory;
        private Point current, start, finish, previous;

        public enum SolverType
        {
            DepthFirstSearch,
            BreadthFirstSearch,
            WallFollowerRight,
            WallFollowerLeft,
            RandomMouse
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

        public Direction DirectionFromDelta(int dx, int dy)
        {
            switch (dx)
            {
                case 1:
                    return Direction.E;
                case -1:
                    return Direction.W;
            }

            switch (dy)
            {
                case 1:
                    return Direction.S;
                case -1:
                    return Direction.N;
            }

            throw new NotImplementedException();
        }

        public Main()
        {
            InitializeComponent();
        }

        private void FileLoadMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader infile = new StreamReader(openFileDialog.FileName))
                    {
                        string[] sizes = infile.ReadLine().Split(',');
                        maze = new Maze(int.Parse(sizes[0]), int.Parse(sizes[1]));
                        for (int y = 0; y < maze.RowSize; y++)
                        {
                            string[] s = infile.ReadLine().Split(',');

                            for (int x = 0; x < s.Length; x++)
                            {
                                maze.Cells[y, x] = int.Parse(s[x]);
                            }
                        }
                    }

                    Invalidate();
                }
                catch (NullReferenceException ex)
                {
                    statusLabel.Text = "File read error occurred! Is the file empty?";
                    MessageBox.Show("An error has occurred. Loading aborted! Is the selected file empty or invalid?\n\nDetails:" +
                        ex.Message, "Error", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    statusLabel.Text = "An error occurred! Unable to load.";
                    MessageBox.Show("An error has occurred. Loading aborted!\n\nDetails:" +
                        ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
        }

        protected void PaintOneCell(Point toPaint)
        {
            if (maze == null) { return; }

            Graphics g = CreateGraphics();
            Point topLeft = new Point(0, menu.Height)
            {
                X = toPaint.X * 10,
                Y = toPaint.Y * 10 + menu.Height
            };

            Bitmap drawSource = toPaint.X == current.X && toPaint.Y == current.Y
                                    ? Properties.Resources.squarecurrent
                                    : Properties.Resources.lightblue;

            //if(toPaint.X == 0 && toPaint.Y == 0)
            //    g.DrawImage(GetBitmap(maze.Cells[toPaint.Y, toPaint.X], drawSource, true, true), topLeft);
            //else if (toPaint.X == 0)
            //    g.DrawImage(GetBitmap(maze.Cells[toPaint.Y, toPaint.X], drawSource, true), topLeft);
            //else if (toPaint.Y == 0)
            //    g.DrawImage(GetBitmap(maze.Cells[toPaint.Y, toPaint.X], drawSource, false, true), topLeft);
            //else
            g.DrawImage(GetBitmap(maze.Cells[toPaint.Y, toPaint.X], drawSource), topLeft);
        }

        private Bitmap GetBitmap(int f, Bitmap square, bool xiszero = false, bool yiszero = false)
        {
            Direction setFlags = (Direction)f;

            if (yiszero)
                for (int i = 0; i < square.Width; i++)
                    square.SetPixel(i, 0, wall);

            if (xiszero)
                for (int i = 0; i < square.Height; i++)
                    square.SetPixel(0, i, wall);

            if ((setFlags & Direction.S) != Direction.S)
                for (int i = 0; i < square.Width; i++)
                    square.SetPixel(i, square.Height - 1, wall);

            if ((setFlags & Direction.E) != Direction.E)
                for (int i = 0; i < square.Height; i++)
                    square.SetPixel(square.Width - 1, i, wall);

            return square;
        }

        private void FileSaveMenuItem_Click(object sender, EventArgs e)
        {
            if (maze == null)
            {
                statusLabel.Text = "Cannot save empty maze!";
                return;
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter outfile = new StreamWriter(saveFileDialog.FileName))
                    {
                        outfile.WriteLine(string.Concat(maze.RowSize, ",", maze.ColSize));
                        for (int y = 0; y < maze.RowSize; y++)
                        {
                            string[] s = new string[maze.ColSize];
                            for (int x = 0; x < maze.ColSize; x++)
                            {
                                s[x] = maze.Cells[y, x].ToString(CultureInfo.InvariantCulture);
                            }
                            outfile.WriteLine(string.Join(",", s));
                        }
                    }
                }
                catch (Exception ex)
                {
                    statusLabel.Text = "File writing error occurred! Unable to save.";
                    MessageBox.Show("An error has occurred. Saving aborted!\n\nDetails:" +
                        ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void GenerateRecursiveBacktrackerMenuItem_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            solverSteps = 0;
            solverAgenda = new Stack<Point>();
            solverHistory = new HashSet<Point>();
            current = finish = start = new Point();
            maze = new Maze(50, 50);
            maze.Generate(Maze.GeneratorType.RecursiveBackTracker);
            Invalidate();
        }

        private void GenerateDepthFirstSearchMenuItem_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            solverSteps = 0;
            solverAgenda = new Stack<Point>();
            solverHistory = new HashSet<Point>();
            current = finish = start = new Point();
            maze = new Maze(20, 15);
            maze.Generate(Maze.GeneratorType.DepthFirstSearch);
            Invalidate();
        }

        private void GenerateBreadthFirstSearchMenuItem_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            solverSteps = 0;
            solverAgenda = new Stack<Point>();
            solverHistory = new HashSet<Point>();
            current = finish = start = new Point();
            maze = new Maze(20, 15);
            maze.Generate(Maze.GeneratorType.BreadthFirstSearch);
            Invalidate();
        }

        private void SolveStartMenuItem_Click(object sender, EventArgs e)
        {
            if (SolveMethodDepthFirstSearchMenuItem.Checked)
            {
                start = new Point(0, 0);
                solverAgenda.Push(start);
                solverMethod = SolverType.DepthFirstSearch;
            }

            if (SolveMethodWallFollowerRightMenuItem.Checked)
            {
                start = new Point(0, 0);
                finish = new Point(maze.ColSize, maze.RowSize);
                solverMethod = SolverType.WallFollowerRight;
            }

            if (SolveMethodWallFollowerLeftMenuItem.Checked)
            {
                solverMethod = SolverType.WallFollowerLeft;
            }

            //Invalidate();
            timer.Enabled = true;
            statusLabel.Text = "Solving in progress.";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            switch (solverMethod)
            {
                case SolverType.DepthFirstSearch:
                    Step_DepthFirstSearch();
                    break;
                case SolverType.BreadthFirstSearch:
                    Step_BreadthFirstSearch();
                    break;
                case SolverType.WallFollowerRight:
                    Step_WallFollower(true);
                    break;
                case SolverType.WallFollowerLeft:
                    Step_WallFollower(false);
                    break;
                case SolverType.RandomMouse:
                    Step_RandomMouse();
                    break;
            }
        }

        private void Step_WallFollower(bool right)
        {
            if (solverSteps == 0)
            {
                current = start;
                previous = new Point(start.X - 1, start.Y);
            }

            if (!Maze.IsOutOfBounds(previous.Y, previous.X, maze.Cells))
                PaintOneCell(previous);
            PaintOneCell(current);

            //compute facing direction
            int deltaX = current.X - previous.X;
            int deltaY = current.Y - previous.Y;

            List<Direction> next = new List<Direction>();

            // enumerate possible directions in order of priority
            switch (DirectionFromDelta(deltaX, deltaY))
            {
                case Direction.N:
                    next.Add(Direction.E);
                    next.Add(Direction.N);
                    next.Add(Direction.W);
                    next.Add(Direction.S);
                    break;
                case Direction.S:
                    next.Add(Direction.W);
                    next.Add(Direction.S);
                    next.Add(Direction.E);
                    next.Add(Direction.N);
                    break;
                case Direction.E:
                    next.Add(Direction.S);
                    next.Add(Direction.E);
                    next.Add(Direction.N);
                    next.Add(Direction.W);
                    break;
                case Direction.W:
                    next.Add(Direction.N);
                    next.Add(Direction.W);
                    next.Add(Direction.S);
                    next.Add(Direction.E);
                    break;
            }

            // priority for WallFollowerLeft is same as WallFollowerRight except with next[0] and next[2] swapped
            if (!right)
            {
                Direction tmp = next[0];
                next[0] = next[2];
                next[2] = tmp;
            }

            //check possible directions and move if accepted
            foreach (Direction d in next)
            {
                int nx = current.X + DirectionX[d];
                int ny = current.Y + DirectionY[d];
                Point np = new Point(nx, ny);

                if (np == finish)
                {
                    timer.Enabled = false;
                    statusLabel.Text = "Finish found in " + ++solverSteps + " steps.";
                    break;
                }

                if (!Maze.IsOutOfBounds(ny, nx, maze.Cells) && IsReachable(current, np))
                {
                    previous = current;
                    current = new Point(nx, ny);
                    break;
                }
            }
            solverSteps++;
        }

        private void Step_DepthFirstSearch()
        {
            if (solverAgenda.Count == 0)
            {
                statusLabel.Text = "Unable to find exit. Tried " + ++solverSteps + " steps!";
                timer.Enabled = false;
                return;
            }

            Point prev = current;
            current = solverAgenda.Pop();
            solverHistory.Add(current);

            if (!Maze.IsOutOfBounds(prev.Y, prev.X, maze.Cells))
                PaintOneCell(prev);
            PaintOneCell(current);

            var directions = new List<Direction>
                                 {
                                     Direction.N,
                                     Direction.S,
                                     Direction.E,
                                     Direction.W
                                 }
                                 .OrderBy(x => Guid.NewGuid());

            foreach (Direction d in directions)
            {
                int nx = current.X + DirectionX[d];
                int ny = current.Y + DirectionY[d];
                Point np = new Point(nx, ny);

                if (Maze.IsOutOfBounds(ny, nx, maze.Cells) || !IsReachable(current, np))
                    continue;

                //check if finish square
                if (nx == maze.Cells.GetLength(_columnDimension) - 1 && ny == maze.Cells.GetLength(_rowDimension) - 1)
                {
                    prev = current;
                    current = new Point(nx, ny);
                    PaintOneCell(prev);
                    PaintOneCell(current);
                    statusLabel.Text = "Finish found at (" + nx + "," + ny + ") in " + solverSteps + " steps.";
                    timer.Enabled = false;
                    break;
                }

                if (!solverAgenda.Contains(np) && !solverHistory.Contains(np))
                    solverAgenda.Push(np);
            }

            solverSteps++;
        }

        private void Step_BreadthFirstSearch()
        {
            if (solverAgenda.Count == 0)
            {
                statusLabel.Text = "Unable to find exit. Tried " + ++solverSteps + " steps!";
                timer.Enabled = false;
                return;
            }

            Point prev = current;
            current = solverAgenda.Pop();
            solverHistory.Add(current);

            if (!Maze.IsOutOfBounds(prev.Y, prev.X, maze.Cells))
                PaintOneCell(prev);
            PaintOneCell(current);

            var directions = new List<Direction>
                                 {
                                     Direction.N,
                                     Direction.S,
                                     Direction.E,
                                     Direction.W
                                 }
                                 .OrderBy(x => Guid.NewGuid());

            foreach (Direction d in directions)
            {
                int nx = current.X + DirectionX[d];
                int ny = current.Y + DirectionY[d];
                Point np = new Point(nx, ny);

                if (Maze.IsOutOfBounds(ny, nx, maze.Cells) || !IsReachable(current, np))
                    continue;

                //check if finish square
                if (nx == maze.Cells.GetLength(_columnDimension) - 1 && ny == maze.Cells.GetLength(_rowDimension) - 1)
                {
                    prev = current;
                    current = new Point(nx, ny);
                    PaintOneCell(prev);
                    PaintOneCell(current);
                    statusLabel.Text = "Finish found at (" + nx + "," + ny + ") in " + solverSteps + " steps.";
                    timer.Enabled = false;
                    break;
                }

                if (!solverAgenda.Contains(np) && !solverHistory.Contains(np))
                    solverAgenda.Push(np);
            }

            solverSteps++;
        }

        public bool IsReachable(Point pos, Point newPos)
        {
            int deltaX = newPos.X - pos.X;
            int deltaY = newPos.Y - pos.Y;
            Direction cv = (Direction)maze.Cells[pos.Y, pos.X];
            //int nv = maze.Cells[newPos.Y, newPos.X];

            if (deltaX == 1 && (cv & Direction.E) == Direction.E)
                return true;

            if (deltaX == -1 && (cv & Direction.W) == Direction.W)
                return true;

            if (deltaY == -1 && (cv & Direction.N) == Direction.N)
                return true;

            if (deltaY == 1 && (cv & Direction.S) == Direction.S)
                return true;

            return false;
        }

        private void FileExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SolveStepMenuItem_Click(object sender, EventArgs e)
        {
            Timer_Tick(null, null);
        }

        private void SolveStopMenuItem_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            statusLabel.Text = "Solving paused.";
        }

        private void ToggleMenuChecked(object sender, EventArgs e)
        {
            ToolStripMenuItem s = sender as ToolStripMenuItem;
            if (s == null) { return; }

            var parent = (ToolStripMenuItem)s.OwnerItem;
            foreach (ToolStripMenuItem item in parent.DropDownItems)
            {
                if (item == sender)
                    item.Checked = true;
                if ((item != null) && (item != sender))
                    item.Checked = false;
            }

            switch (s.Text)
            {
                case "Fastest":
                    timer.Interval = 1;
                    break;

                case "Fast":
                    timer.Interval = 15;
                    break;

                case "Normal":
                    timer.Interval = 50;
                    break;

                case "Slow":
                    timer.Interval = 100;
                    break;

                case "Slowest":
                    timer.Interval = 250;
                    break;

                case "Depth First Search":
                    solverMethod = SolverType.DepthFirstSearch;
                    break;

                case "Breadth First Search":
                    solverMethod = SolverType.BreadthFirstSearch;
                    break;

                case "Wall Follower (Right)":
                    solverMethod = SolverType.WallFollowerRight;
                    break;

                case "Wall Follower (Left)":
                    solverMethod = SolverType.WallFollowerLeft;
                    break;

                case "Random Mouse":
                    solverMethod = SolverType.RandomMouse;
                    break;
            }
        }

        private void Step_RandomMouse()
        {
            if (solverSteps == 0)
            {
                solverHistory = new HashSet<Point>();
                current = start;
                solverSteps++;
            }

            if (!Maze.IsOutOfBounds(previous.Y, previous.X, maze.Cells))
                PaintOneCell(previous);
            PaintOneCell(current);

            var directions = new List<Direction>
                                 {
                                     Direction.N,
                                     Direction.S,
                                     Direction.E,
                                     Direction.W
                                 }
                                 .OrderBy(x => Guid.NewGuid());

            int i = 0;
            foreach (Direction d in directions)
            {
                int nx = current.X + DirectionX[d];
                int ny = current.Y + DirectionY[d];
                Point np = new Point(nx, ny);

                if (np == previous && i != 3)
                {
                    continue;
                }

                if (!Maze.IsOutOfBounds(ny, nx, maze.Cells) && IsReachable(current, np))
                {
                    //check if finish square
                    if (nx == maze.Cells.GetLength(_columnDimension) - 1 && ny == maze.Cells.GetLength(_rowDimension) - 1)
                    {
                        previous = current;
                        current = new Point(nx, ny);
                        PaintOneCell(previous);
                        PaintOneCell(current);
                        statusLabel.Text = "Finish found at (" + nx + "," + ny + ") in " + solverSteps + " steps.";
                        timer.Enabled = false;
                        break;
                    }

                    previous = current;
                    current = np;
                    if (!solverHistory.Contains(current))
                        solverHistory.Add(current);
                    break;
                }
                i++;
            }
            solverSteps++;
        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            if (maze == null) { return; }

            //Size canvasSize = new Size(10 * maze.ColSize - 1, 10 * maze.RowSize - 1);
            Point topLeft = new Point(0, menu.Height);
            //Rectangle canvas = new Rectangle(topLeft, canvasSize);
            //e.Graphics.Clear(BackColor);

            for (int y = 0; y < maze.Cells.GetLength(_rowDimension); y++)
            {
                for (int x = 0; x < maze.Cells.GetLength(_columnDimension); x++)
                {
                    topLeft.X = x * 10;
                    topLeft.Y = y * 10 + menu.Height;
                    Bitmap drawSource;

                    if (solverHistory != null && solverHistory.Contains(new Point(x, y))) // visited
                        drawSource = Properties.Resources.lightblue;
                    else if (x == start.X && y == start.Y)            // start
                        drawSource = Properties.Resources.green;
                    else if (x == finish.X && y == finish.Y)    // finish
                        drawSource = Properties.Resources.red;
                    else if (x == current.X && y == current.Y)  // current
                        drawSource = Properties.Resources.squarecurrent;
                    else                                        // empty
                        drawSource = Properties.Resources.white;

                    e.Graphics.DrawImage(GetBitmap(maze.Cells[y, x], drawSource), topLeft);
                }
            }
            e.Graphics.DrawLine(Pens.Black, 0, menu.Height, 10 * maze.ColSize - 1, menu.Height);
            e.Graphics.DrawLine(Pens.Black, 0, menu.Height, 0, 10 * maze.RowSize - 1 + menu.Height);
        }
    }
}
