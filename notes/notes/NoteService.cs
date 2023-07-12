using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class NoteService
{
    const string baseUrl = "http://192.168.11.74:5446";
    public async Task<List<Note>> GetNotes()
    {
        using var client = new HttpClient();
        return await client.GetFromJsonAsync<List<Note>>($"{baseUrl}/Notes");
    }

    public async Task<Note> GetNoteById(int id)
    {
        using var client = new HttpClient();
        return await client.GetFromJsonAsync<Note>($"{baseUrl}/Notes/{id}");
    }

    public async Task AddNoteAsync(Note note)
    {
        using var client = new HttpClient();
        await client.PostAsJsonAsync($"{baseUrl}/Notes", note);
    }

    public async Task UpdateNoteAsync(Note note)
    {
        using var client = new HttpClient();
        await client.PutAsJsonAsync($"{baseUrl}/Notes", note);
    }

    public async Task DeleteNoteAsync(int id)
    {
        using var client = new HttpClient();
        await client.DeleteAsync($"{baseUrl}/Notes/{id}");
    }
}