using System;
using System.Threading;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace SquareGame;

public partial class GameView : UserControl
{
    private Game game;

    public GameView() : this(new Game(4, 3)) { }

    public GameView(Game game)
    {
        this.game = game;

        InitializeComponent();

        ResetBtn.Click += ResetBtn_Click;
        LoadBtn.Click += LoadBtn_Click;
        SaveBtn.Click += SaveBtn_Click;
        RecreateBtn.Click += RecreateBtn_Click;

        InputWidth.Value = game.GetWidth();
        InputHeight.Value = game.GetHeight();

        UpdateGame(game);
    }

    void ResetBtn_Click(object sender, RoutedEventArgs e)
    {
        game = new Game(4, 4);
        UpdateGame(game);
    }

    void LoadBtn_Click(object sender, RoutedEventArgs e)
    {
        game = new Game(3, 3);
        UpdateGame(game);
    }

    void SaveBtn_Click(object sender, RoutedEventArgs e)
    {
        game = new Game(5, 5);
        UpdateGame(game);
    }

    void RecreateBtn_Click(object sender, RoutedEventArgs e)
    {
        int width = (int)InputWidth.Value;
        int height = (int)InputHeight.Value;
        game = new Game(width, height);
        UpdateGame(game);
    }

    void Rectangle_Tapped(object sender, RoutedEventArgs e)
    {
        Rectangle obj = (Rectangle)sender;
        var x = Grid.GetColumn(obj);
        var y = Grid.GetRow(obj);

        game.OnTileClicked(x, y);
        UpdateGame(game);
    }

    void UpdateGame(Game game)
    {
        var width = game.GetWidth();
        var height = game.GetHeight();

        const string SQUARE_SIZE = "50";
        GameGrid.RowDefinitions = new RowDefinitions(GenerateRowString(height, SQUARE_SIZE));
        GameGrid.ColumnDefinitions = new ColumnDefinitions(GenerateRowString(width, SQUARE_SIZE));

        GameGrid.Children.Clear();

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var player = game.GetPlayer(x, y);
                var color = Color.Parse(PlayerToColor(player));
                var square = new Rectangle
                {
                    Fill = new SolidColorBrush(color),
                };
                square.Tapped += Rectangle_Tapped;
                GameGrid.Children.Add(square);
                Grid.SetColumn(square, x);
                Grid.SetRow(square, y);
            }
        }

        StatusMessage.Text = game.GetStatusMessage();
    }

    public string GenerateRowString(int quantity, string text)
    {
        string s = "";
        for (int i = 0; i < quantity; i++)
        {
            s += text;
            if (i != quantity - 1)
            {
                s += ", ";
            }
        }

        return s;
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
}