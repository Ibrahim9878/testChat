using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp2.Models;

public class Message : INotifyPropertyChanged
{
    private DateTime date1;
    private string title;
    private string image;

    DateTime date { get => date1; set { date1 = value; OnProperty(); } }
    public string Title { get => title; set { title = value;OnProperty(); } }
    public string Image { get => image; set{ image = value; OnProperty(); }}
    public Message(string title, string image)
    {
        this.date = DateTime.Now;
        Title = title;
        Image = image;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnProperty([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(name)));
    }
    public override string ToString()
    {
        return $"{Title}  {date.TimeOfDay}";
    }
}
