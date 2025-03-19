using System;
using System.Globalization;
using Avalonia.Data;
using Avalonia.Data.Converters;

namespace NovaApp.Common;

public abstract class Converters {
    public static IValueConverter ExtensionConverter { get; } = new ExtensionToNameConverter();
    public static IValueConverter SizeConverter { get; } = new SizeToStringConverter();

    private class ExtensionToNameConverter : IValueConverter {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) {
            if (value is string sourceText && parameter is string targetCase && targetType.IsAssignableTo(typeof(string)))
                Console.WriteLine(@"Converting text case");

            return value;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) {
            //throw new NotSupportedException();
            return "";
        }
    }
    
    private class SizeToStringConverter : IValueConverter {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) {
            if (value is not long bytes || !targetType.IsAssignableTo(typeof(string))) return value;
            bool UseMiB = false;
            var unit = UseMiB ? 1024 : 1000;
            return bytes < unit ? $"{bytes} B" : $"{bytes / Math.Pow(unit, (int)(Math.Log(bytes) / Math.Log(unit))):F2} {(@"KMGTPE")[(int)(Math.Log(bytes) / Math.Log(unit)) - 1]}" + (UseMiB ? "iB" : "B");
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) {
            //throw new NotSupportedException();
            return "";
        }
    }
}