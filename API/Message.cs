public class Message
{
    public Message(string content)
    {
        Content = content;
    }
    public string Content {get; set;}

    public static List<Message> GetMessages()
    {
        return System.Text.Json.JsonSerializer.Deserialize<List<Message>>(System.IO.File.ReadAllText("data.json"));
    }
}