using System;
using System.Collections.Generic;

public class GamePersistence
{
    public static GameConfig Load(string filepath)
    {
        GameConfig config = new();

        try
        {
            StreamReader sr = new StreamReader(filepath);
            string[] parts = sr.ReadLine()?.Split(" ");
            if (parts.Length < 2)
            {
                throw new Exception("Invalid part length");
            }

            config.Width = int.Parse(parts[0])!;
            config.Height = int.Parse(parts[1])!;
            config.PlayerCount = int.Parse(parts[2])!;

            string[] tiles = sr.ReadLine()?.Split(" ");
            if (tiles.Length < config.Width * config.Height)
            {
                throw new Exception("invalid tile count");
            }

            int i = 0;
            for (int y = 0; y < config.Height; y++)
            {
                List<int> row = [];
                for (int x = 0; x < config.Width; x++)
                {
                    int player = int.Parse(tiles[i++]);
                    row.Add(player);
                }
                config.board.Add(row);
            }

            sr.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }

        return config;
    }

    public static void Save(Game game, string filepath)
    {
        try
        {
            StreamWriter sw = new StreamWriter(filepath);

            int width = game.GetWidth();
            int height = game.GetHeight();
            int playerCount = game.GetPlayerCount();

            sw.WriteLine($"{width} {height} {playerCount}");

            int tileCount = width * height;
            for (int i = 0; i < tileCount; i++)
            {
                int x = i % width;
                int y = i / width;
                int player = game.GetPlayer(x, y);
                if (i != tileCount - 1)
                {
                    sw.Write($"{player} ");
                }
                else
                {
                    sw.Write($"{player}");
                }
            }

            sw.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }
}