using System.Windows.Controls;
using System.Windows.Input;

namespace OpenSilverTesting;

public partial class MainPage : Page
{
    private readonly MainViewModel _model;

    public MainPage()
    {
        DataContext = new MainViewModel();
        InitializeComponent();
        _model = (MainViewModel)DataContext;
        _model.LoadNotesAsync();
    }
}