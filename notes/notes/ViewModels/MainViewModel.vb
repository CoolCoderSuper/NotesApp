Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Threading.Tasks

Namespace ViewModels

    Public Class MainViewModel
        Inherits ViewModelBase
        Private ReadOnly _noteService As NoteService = New NoteService()

        Public Property Notes As ObservableCollection(Of Note) = New ObservableCollection(Of Note)()

        Public Property SelectedNote As Note

        Public Async Function LoadNotesAsync() As Task
            Dim notes = Await _noteService.GetNotes()
            Me.Notes.Clear()
            For Each note In notes
                Me.Notes.Add(note)
            Next
        End Function

        Public Async Function AddNote() As Task
            Dim note = New Note With {
                    .Id = If(Notes.Any(), Notes.Max(Function(x) x.Id) + 1, 1),
                    .Content = ""
                }
            Notes.Add(note)
            SelectedNote = note
            Await _noteService.AddNoteAsync(note)
        End Function

        Public Async Function DeleteNote() As Task
            If SelectedNote Is Nothing Then
                Return
            End If
            Await _noteService.DeleteNoteAsync(SelectedNote.Id)
            Notes.Remove(SelectedNote)
            Me.SelectedNote = Nothing
        End Function

        Public Async Function Save() As Task
            For Each note In Notes
                Await _noteService.UpdateNoteAsync(note)
            Next
        End Function
    End Class
End Namespace
