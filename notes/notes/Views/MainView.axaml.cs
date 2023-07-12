using Avalonia.Controls;
using Avalonia.Interactivity;
using notes.ViewModels;

namespace notes.Views;

public partial class MainView : UserControl
{
    private MainViewModel _model;
    
    public MainView()
    {
        InitializeComponent();
    }

    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        _model = (MainViewModel) DataContext;
        _model.LoadNotesAsync();
    }

    private void TextBox_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        _model.Save();
    }
}