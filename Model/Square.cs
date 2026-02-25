using SquareGame.Infrastructure;
using Avalonia;

namespace SquareGame.Model;

public class Square : PropertyChangedBase
{
    public Square(int row, int column, string color)
    {
        this.Row = row;
        this.Column = column;
        this.Color = color;
    }

    public int Row { get; } = 0;
    public int Column { get; } = 0;
    public string Color { get; } = "";
}
