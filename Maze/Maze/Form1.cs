using System;
using System.Drawing;
using System.Windows.Forms;

namespace Maze
{
    public partial class Form1 : Form
    {
        System.Timers.Timer t;

        static Random r = new Random();
        Cell[][] maze;
        const int size_x = 230;
        const int size_y = 120;
        Graphics g;

        public Form1()
        {
            InitializeComponent();

            t = new System.Timers.Timer(100);
            t.Elapsed += initMaze;
            t.AutoReset = false;
            t.Start();

        }

        private void initMaze(Object source, System.Timers.ElapsedEventArgs e)
        {
            g = this.maze_zone.CreateGraphics();
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            g.FillRectangle(myBrush, new Rectangle(5, 5, this.maze_zone.Size.Width - 10, this.maze_zone.Size.Height - 10));

            maze = new Cell[size_x][];
            for (int i = 0; i < size_x; i++)
            {
                maze[i] = new Cell[size_y];

                for (int j = 0; j < size_y; j++)
                {
                    if (i == 0 || j == 0 || i == size_x - 1 || j == size_y - 1)
                    {
                        maze[i][j] = new Cell(i, j, true);
                    }
                    else
                    {
                        maze[i][j] = new Cell(i, j, false);
                    }
                }
            }

            int x = new Random().Next(1, size_x - 1);
            int y = new Random().Next(1, size_y - 1);
            createMaze(x, y, maze[x][y].order[0]);
            createMaze(x, y, maze[x][y].order[1]);
            createMaze(x, y, maze[x][y].order[2]);
            createMaze(x, y, maze[x][y].order[3]);
        }
        

        private void createMaze(int x, int y, int direction)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            // haut
            if (direction == 0)
            {
                y--;
                if (!maze[x][y].is_wall && !maze[x - 1][y].is_wall && !maze[x - 1][y - 1].is_wall && !maze[x][y - 1].is_wall && !maze[x + 1][y - 1].is_wall && !maze[x + 1][y].is_wall)
                {
                    maze[x][y].is_wall = true;
                    g.FillRectangle(myBrush, new Rectangle(Cell.size_x * x, Cell.size_y * y, Cell.size_x, Cell.size_y));
                    createMaze(x, y, maze[x][y].order[0]);
                    createMaze(x, y, maze[x][y].order[1]);
                    createMaze(x, y, maze[x][y].order[2]);
                    createMaze(x, y, maze[x][y].order[3]);
                }
                return;
            }
            // bas
            else if (direction == 1)
            {
                y++;
                if (!maze[x][y].is_wall && !maze[x - 1][y].is_wall && !maze[x - 1][y + 1].is_wall && !maze[x][y + 1].is_wall && !maze[x + 1][y + 1].is_wall && !maze[x + 1][y].is_wall)
                {
                    maze[x][y].is_wall = true;
                    g.FillRectangle(myBrush, new Rectangle(Cell.size_x * x, Cell.size_y * y, Cell.size_x, Cell.size_y));
                    createMaze(x, y, maze[x][y].order[0]);
                    createMaze(x, y, maze[x][y].order[1]);
                    createMaze(x, y, maze[x][y].order[2]);
                    createMaze(x, y, maze[x][y].order[3]);
                }
                return;
            }
            // gauche
            else if (direction == 2)
            {
                x--;
                if (!maze[x][y].is_wall && !maze[x][y - 1].is_wall && !maze[x - 1][y - 1].is_wall && !maze[x - 1][y].is_wall && !maze[x - 1][y + 1].is_wall && !maze[x][y + 1].is_wall)
                {
                    maze[x][y].is_wall = true;
                    g.FillRectangle(myBrush, new Rectangle(Cell.size_x * x, Cell.size_y * y, Cell.size_x, Cell.size_y));
                    createMaze(x, y, maze[x][y].order[0]);
                    createMaze(x, y, maze[x][y].order[1]);
                    createMaze(x, y, maze[x][y].order[2]);
                    createMaze(x, y, maze[x][y].order[3]);
                }
                return;
            }
            // droite
            else if (direction == 3)
            {
                x++;
                if (!maze[x][y].is_wall && !maze[x][y - 1].is_wall && !maze[x + 1][y - 1].is_wall && !maze[x + 1][y].is_wall && !maze[x + 1][y + 1].is_wall && !maze[x][y + 1].is_wall)
                {
                    maze[x][y].is_wall = true;
                    g.FillRectangle(myBrush, new Rectangle(Cell.size_x * x, Cell.size_y * y, Cell.size_x, Cell.size_y));
                    createMaze(x, y, maze[x][y].order[0]);
                    createMaze(x, y, maze[x][y].order[1]);
                    createMaze(x, y, maze[x][y].order[2]);
                    createMaze(x, y, maze[x][y].order[3]);
                }
                return;
            }
        }

        private void reload_Click(object sender, EventArgs e)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            this.maze_zone.Refresh();
            reloadMaze();
        }

        private void reloadMaze()
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            g.FillRectangle(myBrush, new Rectangle(5, 5, this.maze_zone.Size.Width - 10, this.maze_zone.Size.Height - 10));
            for (int i = 0; i < size_x; i++)
            {
                for (int j = 0; j < size_y; j++)
                {
                    if (i == 0 || j == 0 || i == size_x - 1 || j == size_y - 1)
                    {
                        maze[i][j] = new Cell(i, j, true);
                    }
                    else
                    {
                        
                        maze[i][j] = new Cell(i, j, false);
                    }
                }
            }
            int x = new Random().Next(1, size_x - 1);
            int y = new Random().Next(1, size_y - 1);

            createMaze(x, y, maze[x][y].order[0]);
            createMaze(x, y, maze[x][y].order[1]);
            createMaze(x, y, maze[x][y].order[2]);
            createMaze(x, y, maze[x][y].order[3]);
        }

        public static int[] RandomTab()
        {
            int[] tab = new int[4];
            int[] nb_prems = new int[] { 2, 3, 5, 7 };
            int a = 210;
            int i = 0;

            while (a != 1)
            {
                int rdm = r.Next(4);

                if (a % nb_prems[rdm] == 0)
                {
                    a = a / nb_prems[rdm];
                    tab[i] = rdm;
                    i++;
                }
            }

            return tab;
        }
    }
}
