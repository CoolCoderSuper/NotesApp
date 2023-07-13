Imports Avalonia.Controls
Imports Avalonia.Interactivity
Imports Avalonia.Markup.Xaml
Imports notes.ViewModels

Namespace Views

    Public Partial Class MainView
        Inherits UserControl
        Private _model As MainViewModel

        Public Sub New()
            AvaloniaXamlLoader.Load(Me)
        End Sub

        Private Sub Control_OnLoaded(sender As Object, e As RoutedEventArgs)
            _model = CType(DataContext, MainViewModel)
            _model.LoadNotesAsync()
        End Sub

        Private Sub TextBox_OnTextChanged(sender As Object, e As TextChangedEventArgs)
            _model.Save()
        End Sub
    End Class
End Namespace
