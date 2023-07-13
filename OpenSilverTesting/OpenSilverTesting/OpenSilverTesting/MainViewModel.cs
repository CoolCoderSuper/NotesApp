using Microsoft.Expression.Interactivity.Core;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly NoteService _noteService = new();
    private Note selectedNote;

    public event PropertyChangedEventHandler PropertyChanged;

    public ObservableCollection<Note> Notes {get; set;} = new();

    public MainViewModel()
    {
        AddNoteCommand = new ActionCommand(async () => await AddNote());
        DeleteNoteCommand = new ActionCommand(async () => await DeleteNote());
    }

    public Note SelectedNote
    {
        get => selectedNote; set
        {
            selectedNote = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedNote)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteContent)));
        }
    }

    public string NoteContent
    {
        get => SelectedNote?.Content; set
        {
            if (SelectedNote != null)
            {
                SelectedNote.Content = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteContent)));
                Save();
            }
        }
    }

    public readonly ICommand AddNoteCommand;
    public readonly ICommand DeleteNoteCommand;

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