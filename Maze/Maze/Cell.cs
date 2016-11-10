using System;

public class Cell
{
    int x;
    int y;
    public bool is_wall;
    bool is_passed;
    public int[] order;


    public const int size_x = 5;
    public const int size_y = 5;

	public Cell(int x, int y, bool is_wall)
	{
        this.x = x;
        this.y = y;
        this.is_wall = is_wall;

        this.order = Maze.Form1.RandomTab();
	}



    


}
