namespace API;

public class Note
{
    public Note(int id, string content)
    {
        Id = id;
        Content = content;
    }

    public int Id { get; set; }
    public string Content { get; set; } = "";
}