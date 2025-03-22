using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Resort.Models;

namespace Resort;

public partial class HistoryLoginWindow : Window
{
    private List<Staff> staffList = DataSource.Helper.dataBase.Staff.ToList();
    Staff Staff { get; set; }

    public HistoryLoginWindow()
    {
        InitializeComponent();
        back.Click += Back_Click;
        Staff = new Staff();
        SetData();
    }
    
    public HistoryLoginWindow(Staff staff)
    {
        InitializeComponent();
        back.Click += Back_Click;
        Staff = staff;
        SetData();
    }
    
    private void Back_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        foreach (Staff staff in staffList)
        {
            StaffWindow staffWindow = new StaffWindow(staff);
            staffWindow.Show();
            Close();
        }
    } 

    private void SetData()
    {
        historyLB.ItemsSource = DataSource.Helper.dataBase.HistoryLogins;
    }
}