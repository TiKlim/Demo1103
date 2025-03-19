using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;


namespace Resort;

public partial class StaffWindow : Window
{
    public StaffWindow()
    {
        InitializeComponent();
        historyLogin.Click += HistoryLogin_Click;
        SetData();
    }

    private void HistoryLogin_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        HistoryLoginWindow historyLoginWindow = new HistoryLoginWindow();
        historyLoginWindow.Show();
        Close();
    } 

    private void SetData()
    {

    }
}