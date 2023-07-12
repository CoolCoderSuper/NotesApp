using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace notes.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly NoteService _noteService = new();

    public ObservableCollection<Note> Notes {get; set;} = new();

    public Note SelectedNote {get; set;}
    
    public async Task LoadNotesAsync()
    {
        var notes = await _noteService.GetNotes();
        Notes.Clear();
        foreach (var note in notes)
        {
            Notes.Add(note);
        }
    }
    
    public async Task AddNote()
    {
        var note = new Note { Id = Notes.Any() ? Notes.Max(x => x.Id) + 1 : 1, Content = ""};
        Notes.Add(note);
        SelectedNote = note;
        await _noteService.AddNoteAsync(note);
    }
    
    public async Task DeleteNote()
    {
        if (SelectedNote == null)
        {
            return;
        }
        await _noteService.DeleteNoteAsync(SelectedNote.Id);
        Notes.Remove(SelectedNote);
        SelectedNote = null;
    }

    public async Task Save()
    {
        foreach (var note in Notes)
        {
            await _noteService.UpdateNoteAsync(note);
        }
    }
}