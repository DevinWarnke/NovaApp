// ReSharper disable RedundantUsingDirective
using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FluentAvalonia.Core;
using FluentAvalonia.UI.Controls;
using NovaApp.Pages;
using NovaApp.ViewModels;
#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace NovaApp.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        
        var nv = this.FindControl<NavigationView>("MainViewNavView");
        if (nv != null)
        {
            nv.SelectionChanged += OnMainViewNavViewSelectionChanged;
            nv.SelectedItem = nv.MenuItems.ElementAt(0);
        }
    }
    
    private void OnMainViewNavViewSelectionChanged(object? sender, NavigationViewSelectionChangedEventArgs e)
    {
        if (e.IsSettingsSelected)
        {
            (sender as NavigationView).Content = new SettingsPage();
        }
        else if (e.SelectedItem is NavigationViewItem nvi)
        {
            var smpPage = $"NovaApp.Pages.{nvi.Tag}";
            var pg = Activator.CreateInstance(Type.GetType(smpPage) ?? throw new InvalidOperationException());
            (sender as NavigationView).Content = pg;
        }
    }
}
