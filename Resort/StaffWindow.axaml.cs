using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using Resort.Models;


namespace Resort;

public partial class StaffWindow : Window
{
    Staff Staff { get; set; }
    private List<Staff> staffList = DataSource.Helper.dataBase.Staff.ToList();
    public StaffWindow()
    {
        InitializeComponent();
        historyLogin.Click += HistoryLogin_Click;
        Staff = new Staff();
        SetData();
    }
    
    public StaffWindow(Staff staff)
    {
        InitializeComponent();
        historyLogin.Click += HistoryLogin_Click;
        Staff = staff;
        dataGrid.DataContext = staff;
        SetData();
    }

    private void HistoryLogin_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        foreach (Staff staff in staffList)
        {
            HistoryLoginWindow historyLoginWindow = new HistoryLoginWindow(staff);
            historyLoginWindow.Show();
            Close();
        }
    } 

    private void SetData()
    {
        
    }
}