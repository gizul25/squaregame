using System;
using System.Globalization;
using SquareGame.Model;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media;
using Avalonia.Controls;

namespace SquareGame.Infrastructure;

public class GridRowConverter : IValueConverter
{
    public static GridRowConverter Instance = new();

    public object? Convert(object? value, Type targetType, object? parameter,
                                                            CultureInfo culture)
    {
        int quantity = (int)value;
        string text = (string)parameter;


        return new RowDefinitions();
    }

    public object ConvertBack(object? value, Type targetType,
                                object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
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
}