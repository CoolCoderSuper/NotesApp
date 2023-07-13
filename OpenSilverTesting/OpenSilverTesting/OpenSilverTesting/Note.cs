using System.ComponentModel;

public class Note : INotifyPropertyChanged
{
    private int id;
    private string content;

    public int Id
    {
        get => id; set
        {
            if (id != value)
            {
                id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }
    }
    public string Content
    {
        get => content; set
        {
            if (content != value)
            {
                content = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Content)));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
}