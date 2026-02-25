using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace AvaloniaExercises;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.Width = 600;
        this.Height = 500;
    }
    private void Exercise2ShowOutput_Click(object sender, RoutedEventArgs e)
    {
        var textBox = this.FindControl<TextBox>("Exercise2TextBox");
        var comboBox = this.FindControl<ComboBox>("Exercise2ComboBox");
        var checkBox = this.FindControl<CheckBox>("Exercise2CheckBox");
        var outputTextBlock = this.FindControl<TextBlock>("OutputTextBlock");

        string output = $"TextBox: {textBox.Text}, ComboBox: {comboBox.SelectionBoxItem}, CheckBox: {checkBox.IsChecked}";
        outputTextBlock.Text = output;
    }

    private void Exercise3ShowImage_Click(object sender, RoutedEventArgs e)
    {
        var catRadioButton = this.FindControl<RadioButton>("CatRadioButton");
        var dogRadioButton = this.FindControl<RadioButton>("DogRadioButton");
        var birdRadioButton = this.FindControl<RadioButton>("BirdRadioButton");
        var animalImage = this.FindControl<Image>("AnimalImage");

        if (catRadioButton.IsChecked == true)
        {
            animalImage.Source = new Bitmap(AssetLoader.Open(new Uri("avares://AvaloniaExercises/Assets/cat.jpg")));
        }
        if (dogRadioButton.IsChecked == true)
        {
            animalImage.Source = new Bitmap(AssetLoader.Open(new Uri("avares://AvaloniaExercises/Assets/dog.jpg")));
        }
        if (birdRadioButton.IsChecked == true)
        {
            animalImage.Source = new Bitmap(AssetLoader.Open(new Uri("avares://AvaloniaExercises/Assets/bird.jpg")));
        }

    }
}
