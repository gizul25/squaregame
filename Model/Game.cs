using System.Collections.ObjectModel;
using SquareGame.Infrastructure;

namespace SquareGame.Model;

public class Game : PropertyChangedBase
{
    public Game()
    {
        CreateGrid(3, 3);
        Grid[0][0] = 1;
        Grid[1][1] = 2;
        Grid[2][2] = 1;
        SquareList.UpdateSquareList(Grid, 3, 3);
    }

    public void CreateGrid(int width, int height)
    {
        Grid.Clear();
        for (int y = 0; y < height; y++)
        {
            List<int> row = [];
            for (int x = 0; x < width; x++)
            {
                row.Add(0);
            }
            Grid.Add(row);
        }
    }


    public static Game DesignInstance { get; } = new();

    public string StatusMessage { get; } = "Blue turn";
    public List<List<int>> Grid { get; } = [];
    public SquareList SquareList { get; } = new();
}