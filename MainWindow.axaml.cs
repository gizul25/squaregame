using System;
using System.Threading;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System.Collections.Generic;

namespace SquareGame;

public partial class MainWindow : Window
{
    List<Game> games = new();
    int currGameId = 1;

    public MainWindow()
    {
        InitializeComponent();

        this.Width = 600;
        this.Height = 500;

        NewLocalBtn.Click += NewLocalBtn_Click;
        DeleteBtn.Click += DeleteBtn_Click;
    }

    private void NewLocalBtn_Click(object sender, RoutedEventArgs e)
    {
        var game = new Game(5, 3);
        games.Add(game);

        var gameView = new GameView(game);
        var tabItem = new TabItem
        {
            Header = $"Game {currGameId++}",
            Content = gameView,
        };
        MainTabControl.Items.Add(tabItem);
    }

    private void DeleteBtn_Click(object sender, RoutedEventArgs e)
    {
        var index = 0;

        games.RemoveAt(index);
        MainTabControl.Items.RemoveAt(index);
    }
}
