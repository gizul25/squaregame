using System.Collections.Generic;

public class Game
{
    public Game() : this(new GameConfig()) { }

    public Game(GameConfig config)
    {
        this.config = config;

        ResetBoard();
    }

    public void ResetBoard()
    {
        board.Clear();
        for (int y = 0; y < config.Height; y++)
        {
            List<int> row = [];
            for (int x = 0; x < config.Width; x++)
            {
                row.Add(0);
            }
            board.Add(row);
        }
        statusMessage = "";
    }

    public void Recreate(GameConfig config)
    {
        this.config = config;
        ResetBoard();
    }

    public void OnTileClicked(int x, int y)
    {
        // TODO
        Console.WriteLine($"Tile clicked: ({x};{y})");
        board[y][x] = 1;
    }

    public int GetWidth()
    {
        return config.Width;
    }

    public int GetHeight()
    {
        return config.Height;
    }

    public int GetPlayer(int x, int y)
    {
        return board[y][x];
    }

    public string GetStatusMessage()
    {
        return statusMessage;
    }

    GameConfig config;
    List<List<int>> board = [];
    string statusMessage = "";
}