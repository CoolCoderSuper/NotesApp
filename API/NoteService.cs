namespace API;

public class NoteService
{
    private readonly List<Note> _notes = new List<Note>();

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
   }

   public void Update(Note note)
   {
    var index = _notes.FindIndex(x => x.Id == note.Id);
    _notes[index] = note;
   }

    public void Delete(int id)
    {
     var index = _notes.FindIndex(x => x.Id == id);
     _notes.RemoveAt(index);
    }
}