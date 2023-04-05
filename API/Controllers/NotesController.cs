using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class NotesController : ControllerBase
{
    private readonly NoteService _service;
    private readonly ILogger<NotesController> _logger;

    public NotesController(NoteService service, ILogger<NotesController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet(Name = "GetNotes")]
    public List<Note> Get()
    {
        return _service.GetNotes();
    }

    [HttpGet("{id}", Name = "GetNoteById")]
    public Note Get(int id)
    {
        return _service.GetNoteById(id);
    }

    [HttpPost(Name = "AddNote")]
    public void Post([FromBody] Note note)
    {
        _service.Add(note);
    }

    [HttpPut(Name = "UpdateNote")]
    public void Put([FromBody] Note note)
    {
        _service.Update(note);
    }

    [HttpDelete("{id}", Name = "DeleteNote")]
    public void Delete(int id)
    {
        _service.Delete(id);
    }
}
