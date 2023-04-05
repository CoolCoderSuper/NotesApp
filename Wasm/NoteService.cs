using System.Net.Http.Json;
namespace Wasm;

public class NoteService
{
    public async Task<List<Note>> GetNotes()
    {
        using var client = new HttpClient();
        return await client.GetFromJsonAsync<List<Note>>("https://coolcodersuper-crispy-potato-9g5q6w4pj52xx4j-5124.preview.app.github.dev/Notes");
    }

    public async Task<Note> GetNoteById(int id)
    {
        using var client = new HttpClient();
        return await client.GetFromJsonAsync<Note>($"https://coolcodersuper-crispy-potato-9g5q6w4pj52xx4j-5124.preview.app.github.dev/Notes/{id}");
    }

    public async Task AddNoteAsync(Note note)
    {
        using var client = new HttpClient();
        await client.PostAsJsonAsync("https://coolcodersuper-crispy-potato-9g5q6w4pj52xx4j-5124.preview.app.github.dev/Notes", note);
    }

    public async Task UpdateNoteAsync(Note note)
    {
        using var client = new HttpClient();
        await client.PutAsJsonAsync($"https://coolcodersuper-crispy-potato-9g5q6w4pj52xx4j-5124.preview.app.github.dev/Notes/{note.Id}", note);
    }

    public async Task DeleteNoteAsync(int id)
    {
        using var client = new HttpClient();
        await client.DeleteAsync($"https://coolcodersuper-crispy-potato-9g5q6w4pj52xx4j-5124.preview.app.github.dev/Notes/{id}");
    }
}