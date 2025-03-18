using Avalonia.Controls;
using Avalonia.Threading;
using Resort.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resort
{
    public partial class MainWindow : Window
    {
        private List<Staff> users = DataSource.Helper.dataBase.Staff.ToList();
        public MainWindow()
        {
            InitializeComponent();
            welcome.Click += Welcome_Click;
            iSeeYou.Click += ISeeYou_Click;
            update.Click += Update_Click;
        }

        private void Update_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            UpdateCaptcha();
        } 

        private void ISeeYou_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (passwordTB.PasswordChar == '•')
            {
                passwordTB.PasswordChar = '\0';
            }
            else
            {
                passwordTB.PasswordChar = '•';
            }
        } 

        private void UpdateCaptcha()
        {
            string randomText = GenerateString(3);
            captcha.Text = randomText;
        }

        private void Welcome_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            string login = loginTB.Text;
            string password = passwordTB.Text;

            foreach (Staff user in users)
            {
                if (attention.IsVisible == true)
                {
                    if (vvod.Text == null)
                    {
                        UpdateCaptcha();
                    }
                    else if (vvod.Text == captcha.Text && user.StaffLogin == login && user.StaffPassword == password && vvod.Text != null)
                    {
                        StaffWindow staffWindow = new StaffWindow();
                        staffWindow.Show();
                        Close();
                    }
                    else if (vvod.Text != captcha.Text && user.StaffLogin != login && user.StaffPassword != password && vvod.Text != null)
                    {
                        HideElements();
                    }
                    else if (login.Length > 0)
                    {
                        attention.IsVisible = true;
                    }
                }
                else
                {
                    if (user.StaffLogin == login && user.StaffPassword == password)
                    {
                        StaffWindow staffWindow = new StaffWindow();
                        staffWindow.Show();
                        Close();
                    }
                    else
                    {
                        attention.IsVisible = true;
                        captcha.IsVisible = true;
                        vvod.IsVisible = true;
                        update.IsVisible = true;
                        UpdateCaptcha();
                    }
                }
            }
        }

        private string GenerateString(int length)
        {
            string chars = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm0123456789";

            Random random = new Random();
            char[] result = new char[length];

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length);
                result[i] = chars[index];
            }

            return new string(result);
        }

        private async Task HideElements()
        {
            attention.IsVisible = true;
            captcha.IsVisible = false;
            vvod.IsVisible = false;
            vvod.Text = string.Empty;
            welcome.IsVisible = false;
            iSeeYou.IsVisible = false;
            loginTB.IsVisible = false;
            passwordTB.IsVisible = false;
            update.IsVisible = false;

            await Task.Delay(10000);

            attention.IsVisible = false;
            welcome.IsVisible = true;
            iSeeYou.IsVisible = true;
            loginTB.IsVisible = true;
            passwordTB.IsVisible = true;
            captcha.IsVisible = false;
            vvod.IsVisible = false;
            update.IsVisible = false;
            loginTB.Text = string.Empty;
            passwordTB.Text = string.Empty;
        }
    }
}