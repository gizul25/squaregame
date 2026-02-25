using System.Collections.ObjectModel;
using SquareGame.Infrastructure;

namespace SquareGame.Model;

public class Game : PropertyChangedBase
{
    public Game()
    {
        var square = new Square(0, 0, "Blue");
        var square2 = new Square(1, 1, "Red");
        var square3 = new Square(2, 2, "Aqua");
        SquareList.Add(square);
        SquareList.Add(square2);
        SquareList.Add(square3);
    }

    public static Game DesignInstance { get; } = new();

    public string StatusMessage { get; } = "Blue turn";
    public ObservableCollection<Square> SquareList { get; } = new();
}