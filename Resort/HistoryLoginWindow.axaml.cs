using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Resort;

public partial class HistoryLoginWindow : Window
{
    public HistoryLoginWindow()
    {
        InitializeComponent();
        SetData();
    }

    private void SetData()
    {
        historyLB.ItemsSource = DataSource.Helper.dataBase.HistoryLogins;
    }
}