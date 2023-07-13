Imports System.Runtime.Versioning
Imports System.Threading.Tasks
Imports Avalonia
Imports Avalonia.Browser
Imports Avalonia.ReactiveUI
Imports notes

<Assembly: SupportedOSPlatform("browser")>

Friend Module Program
    Public Sub Main(args As String())
        BuildAvaloniaApp().WithInterFont().UseReactiveUI().StartBrowserAppAsync("out")
    End Sub

    Public Function BuildAvaloniaApp() As AppBuilder
        Return AppBuilder.Configure(Of App)()
    End Function
End Module
