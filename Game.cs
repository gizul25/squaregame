using System.Collections.Generic;

public class Game
{
    public Game() : this(new GameConfig()) { }

    public Game(GameConfig config)
    {
        this.config = config;

        LoadBoard();
    }

    public void LoadBoard()
    {
        board.Clear();
        if (config.board.Count > 0)
        {
            FillFromBoard(config.board);
        }
        else
        {
            FillEmptyBoard();
        }


        statusMessage = "";
    }

    public void ResetBoard()
    {
        board.Clear();
        FillEmptyBoard();
        statusMessage = "";
    }

    public void Recreate(GameConfig config)
    {
        this.config = config;
        LoadBoard();
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

    public int GetPlayerCount()
    {
        return config.PlayerCount;
    }

    public int GetPlayer(int x, int y)
    {
        return board[y][x];
    }

    public string GetStatusMessage()
    {
        return statusMessage;
    }

    void FillFromBoard(List<List<int>> src)
    {
        for (int y = 0; y < config.Height; y++)
        {
            List<int> row = [];
            for (int x = 0; x < config.Width; x++)
            {
                row.Add(src[y][x]);
            }
            board.Add(row);
        }
    }


    void FillEmptyBoard()
    {
        for (int y = 0; y < config.Height; y++)
        {
            List<int> row = [];
            for (int x = 0; x < config.Width; x++)
            {
                row.Add(0);
            }
            board.Add(row);
        }
    }

    GameConfig config;
    List<List<int>> board = [];
    string statusMessage = "";
}