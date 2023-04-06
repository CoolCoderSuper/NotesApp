using System.Text.Json;
namespace API;

public class NoteService
{
    private readonly List<Note> _notes;

    private readonly string _path = "notes.json";

    public NoteService()
    {
        if (File.Exists(_path))
        {
            var json = File.ReadAllText(_path);
            _notes = JsonSerializer.Deserialize<List<Note>>(json);
        }
        else
        {
            _notes = new List<Note>();
        }
    }

    public List<Note> GetNotes()
    {
        return _notes;
    }

    public Note GetNoteById(int id)
    {
        return _notes.FirstOrDefault(x => x.Id == id);
    }

    public void Add(Note note)
    {
        note.Id = _notes.Any() ? _notes.Max(x => x.Id) + 1 : 1;
        _notes.Add(note);
        Save();
    }

    public void Update(Note note)
    {
        var index = _notes.FindIndex(x => x.Id == note.Id);
        _notes[index] = note;
        Save();
    }

    public void Delete(int id)
    {
        var index = _notes.FindIndex(x => x.Id == id);
        _notes.RemoveAt(index);
        Save();
    }

    private void Save()
    {
        var json = JsonSerializer.Serialize(_notes);
        File.WriteAllText(_path, json);
    }
}