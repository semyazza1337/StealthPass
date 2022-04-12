using StealthPass.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StealthPass
{
    /// <summary>
    /// Logika interakcji dla klasy Startup.xaml
    /// </summary>
    public partial class Startup : Window
    {
        public Startup()
        {
            InitializeComponent();
        }

        private void login()
        {
            MainWindow mainWindow = new MainWindow();
            if (loginTextBox.Text == "toor" && passwordTextBox.Password == "toor")
            {
                Close();
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("Wrong username or password!", "Login failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
          
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            login();
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                login();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            User register = new User()
            {
                Username = loginTextBox.Text,
                Password = passwordTextBox.Password
            };
        }
    }
}
