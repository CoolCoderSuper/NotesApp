Imports System.Collections.Generic
Imports System.Net.Http
Imports System.Net.Http.Json
Imports System.Threading.Tasks

Public Class NoteService
    Const baseUrl As String = "http://192.168.11.74:5446"
    Public Async Function GetNotes() As Task(Of List(Of Note))
        Dim client = New HttpClient()
        Return Await client.GetFromJsonAsync(Of List(Of Note))($"{baseUrl}/Notes")
    End Function

    Public Async Function GetNoteById(ByVal id As Integer) As Task(Of Note)
        Dim client = New HttpClient()
        Return Await client.GetFromJsonAsync(Of Note)($"{baseUrl}/Notes/{id}")
    End Function

    Public Async Function AddNoteAsync(ByVal note As Note) As Task
        Dim client = New HttpClient()
        Await client.PostAsJsonAsync($"{baseUrl}/Notes", note)
    End Function

    Public Async Function UpdateNoteAsync(ByVal note As Note) As Task
        Dim client = New HttpClient()
        Await client.PutAsJsonAsync($"{baseUrl}/Notes", note)
    End Function

    Public Async Function DeleteNoteAsync(ByVal id As Integer) As Task
        Dim client = New HttpClient()
        Await client.DeleteAsync($"{baseUrl}/Notes/{id}")
    End Function
End Class
