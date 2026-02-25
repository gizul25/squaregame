using SquareGame.Infrastructure;

namespace SquareGame.Model;

public class Game : PropertyChangedBase
{
    public Game()
    {
    }

    public static Game DesignInstance { get; } = new();

    public string StatusMessage { get; } = "Blue turn";
}