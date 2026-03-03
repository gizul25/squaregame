using SquareGame.Infrastructure;
using Avalonia;
using System.Collections.ObjectModel;

namespace SquareGame.Model;

public class SquareList : ObservableCollection<Square>
{
    public SquareList() : base([]) { }

    private int _width = 0;
    public int Width
    {
        get => _width;
    }
    private int _height = 0;
    public int Height
    {
        get => _height;
    }

    public void UpdateSquareList(List<List<int>> grid, int width, int height)
    {
        Clear();

        _width = width;
        _height = height;

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                int player = grid[y][x];

                var square = new Square(y, x, PlayerToColor(player));
                Add(square);
            }
        }
    }

    public string PlayerToColor(int player)
    {
        return player switch
        {
            0 => "white",
            1 => "blue",
            2 => "red",
            _ => "",
        };
    }

    // public string RowDefinition
    // {
    //     get
    //     {
    //         return;
    //     }
    // }
}