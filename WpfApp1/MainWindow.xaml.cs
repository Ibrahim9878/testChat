using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using WpfApp2.Models;

namespace WpfApp1;

public partial class MainWindow : Window,INotifyPropertyChanged
{
    private ObservableCollection<Message>? messages;

    public event PropertyChangedEventHandler? PropertyChanged;
    public ObservableCollection<Message>? Messages { get => messages; set { messages = value; OnProperty(); } }
    public MainWindow()
    {
        InitializeComponent();
        Messages = new ObservableCollection<Message>()
        {
            new("Salam"),
            new("Ehe"),
            new("Aha"),
        };
        DataContext = this;
    }
    public void OnProperty([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(name)));
    }

    private void SendButton_Click(object sender, RoutedEventArgs e)
    {
        if(SendText.Text != string.Empty)
        {
            Messages?.Add(new Message(SendText.Text));
            SendText.Text = null;
        }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        foreach (Message item in Messages)
        {
            if (item.Title == SearchBox.Text)
            { 
                MessageBox.Show(item.ToString());
                return;            
            }
        }
        MessageBox.Show("Tapilmadi");
        SearchBox.Text = null;
        
    }
}
