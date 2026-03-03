using System.Collections.Generic;

public class Game
{
    public Game(int width, int height)
    {
        this.width = width;
        this.height = height;

        InitBoard();
    }

    void InitBoard()
    {
        for (int y = 0; y < height; y++)
        {
            List<int> row = [];
            for (int x = 0; x < width; x++)
            {
                row.Add(0);
            }
            board.Add(row);
        }
    }

    public void OnTileClicked(int x, int y)
    {
        // TODO
        Console.WriteLine($"Tile clicked: ({x};{y})");
        board[y][x] = 1;
    }

    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }

    public int GetPlayer(int x, int y)
    {
        return board[y][x];
    }

    public string GetStatusMessage()
    {
        return statusMessage;
    }

    int width;
    int height;
    List<List<int>> board = [];
    string statusMessage = "";
}