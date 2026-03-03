using System;
using System.Threading;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace SquareGame;

public partial class MainWindow : Window
{
    private Game game = new(4, 3);

    public MainWindow()
    {
        InitializeComponent();

        this.Width = 600;
        this.Height = 500;

        ResetBtn.Click += ResetBtn_Click;
        LoadBtn.Click += LoadBtn_Click;
        SaveBtn.Click += SaveBtn_Click;
        ChangeSizeBtn.Click += ChangeSizeBtn_Click;

        UpdateGame(game);
    }

    // private void Exercise2ShowOutput_Click(object sender, RoutedEventArgs e)
    // {
    //     var textBox = this.FindControl<TextBox>("Exercise2TextBox");
    //     var comboBox = this.FindControl<ComboBox>("Exercise2ComboBox");
    //     var checkBox = this.FindControl<CheckBox>("Exercise2CheckBox");
    //     var outputTextBlock = this.FindControl<TextBlock>("OutputTextBlock");

    //     string output = $"TextBox: {textBox.Text}, ComboBox: {comboBox.SelectionBoxItem}, CheckBox: {checkBox.IsChecked}";
    //     outputTextBlock.Text = output;
    // }

    // private void Exercise3ShowImage_Click(object sender, RoutedEventArgs e)
    // {
    //     var catRadioButton = this.FindControl<RadioButton>("CatRadioButton");
    //     var dogRadioButton = this.FindControl<RadioButton>("DogRadioButton");
    //     var birdRadioButton = this.FindControl<RadioButton>("BirdRadioButton");
    //     var animalImage = this.FindControl<Image>("AnimalImage");

    //     if (catRadioButton.IsChecked == true)
    //     {
    //         animalImage.Source = new Bitmap(AssetLoader.Open(new Uri("avares://AvaloniaExercises/Assets/cat.jpg")));
    //     }
    //     if (dogRadioButton.IsChecked == true)
    //     {
    //         animalImage.Source = new Bitmap(AssetLoader.Open(new Uri("avares://AvaloniaExercises/Assets/dog.jpg")));
    //     }
    //     if (birdRadioButton.IsChecked == true)
    //     {
    //         animalImage.Source = new Bitmap(AssetLoader.Open(new Uri("avares://AvaloniaExercises/Assets/bird.jpg")));
    //     }

    // }

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

    void ChangeSizeBtn_Click(object sender, RoutedEventArgs e)
    {
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
        GridSize.Text = $"{width} x {height}";
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
