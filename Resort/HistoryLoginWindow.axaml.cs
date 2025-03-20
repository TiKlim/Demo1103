using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Resort;

public partial class HistoryLoginWindow : Window
{
    public HistoryLoginWindow()
    {
        InitializeComponent();
        back.Click += Back_Click;
        SetData();
    }

    private void Back_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        StaffWindow staffWindow = new StaffWindow();
        staffWindow.Show();
        Close();
    } 

    private void SetData()
    {
        historyLB.ItemsSource = DataSource.Helper.dataBase.HistoryLogins;
    }
}