Imports System
Imports Avalonia
Imports Avalonia.Controls.ApplicationLifetimes
Imports Avalonia.Markup.Xaml
Imports notes.ViewModels
Imports notes.Views

Public Partial Class App
    Inherits Application
    Public Overrides Sub Initialize()
        AvaloniaXamlLoader.Load(Me)
    End Sub

    Public Overrides Sub OnFrameworkInitializationCompleted()
        Dim desktop As IClassicDesktopStyleApplicationLifetime = Nothing, singleViewPlatform As ISingleViewApplicationLifetime = Nothing

        If CSharpImpl.__Assign(desktop, TryCast(ApplicationLifetime, IClassicDesktopStyleApplicationLifetime)) IsNot Nothing Then
            desktop.MainWindow = New MainWindow With {
                .DataContext = New MainViewModel()
                }
        ElseIf CSharpImpl.__Assign(singleViewPlatform, TryCast(ApplicationLifetime, ISingleViewApplicationLifetime)) IsNot Nothing Then
            singleViewPlatform.MainView = New MainView With {
                .DataContext = New MainViewModel()
                }
        End If

        MyBase.OnFrameworkInitializationCompleted()
    End Sub

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class
End Class