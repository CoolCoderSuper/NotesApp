Imports Avalonia.Controls
Imports Avalonia.Controls.Templates
Imports notes.ViewModels

Public Class ViewLocator
    Implements IDataTemplate
    
    Public Function Build(data As Object) As Control Implements IDataTemplate.Build
        If data Is Nothing Then Return Nothing

        Dim name = data.GetType().FullName.Replace("ViewModel", "View")
        Dim type = System.Type.GetType(name)

        If type IsNot Nothing Then
            Return Nothing
        End If

        Return New TextBlock With {
            .Text = name
            }
    End Function

    Public Function Match(data As Object) As Boolean Implements IDataTemplate.Match
        Return TypeOf data Is ViewModelBase
    End Function
End Class