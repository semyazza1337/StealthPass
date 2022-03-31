using SQLite;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StealthPass
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ReadDatabase();
        }

        private void logout()
        {
            Startup startupWindow = new Startup();
            Close();
            startupWindow.Show();
        }

        private void hideAddPassword()
        {
            siteLabel.Visibility = Visibility.Collapsed;
            siteTextBox.Visibility = Visibility.Collapsed;
            emailLabel.Visibility = Visibility.Collapsed;
            emailTextBox.Visibility = Visibility.Collapsed;
            passLabel.Visibility = Visibility.Collapsed;
            passTextBox.Visibility = Visibility.Collapsed;
            addCredentialsButton.Visibility = Visibility.Collapsed;
        }
        
        private void showAddPassword()
        {
            siteLabel.Visibility = Visibility.Visible;
            siteTextBox.Visibility = Visibility.Visible;
            emailLabel.Visibility = Visibility.Visible;
            emailTextBox.Visibility = Visibility.Visible;
            passLabel.Visibility = Visibility.Visible;
            passTextBox.Visibility = Visibility.Visible;
            addCredentialsButton.Visibility= Visibility.Visible;
        }

        private void showPasswords()
        {
            credentialsLabel.Visibility = Visibility.Visible;
            credentialsListView.Visibility = Visibility.Visible;
        }

        private void hidePasswords()
        {
            credentialsLabel.Visibility = Visibility.Collapsed;
            credentialsListView.Visibility = Visibility.Collapsed;
        }

        private void hideWelcomeMessage()
        {
            welcomeBackLabel.Visibility = Visibility.Collapsed;
            niceDayLabel.Visibility = Visibility.Collapsed;
        }

        private void addCredentialsButton_Click(object sender, RoutedEventArgs e)
        {
            Credentials credentials = new Credentials()
            {
                Site = siteTextBox.Text,
                Email = emailTextBox.Text,
                Pass = passTextBox.Text
            };
        
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Credentials>();
                connection.Insert(credentials);
            }
        
            siteTextBox.Text = null;
            emailTextBox.Text = null;
            passTextBox.Text = null;
        
            ReadDatabase();
        }
        
        void ReadDatabase()
        {
            List<Credentials> credentials;
            using(SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Credentials>();
                credentials = conn.Table<Credentials>().ToList();
            }
            if (credentials != null)
            {
                credentialsListView.ItemsSource = credentials;
            }
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void showPasswordsButton_Click(object sender, RoutedEventArgs e)
        {
            hideAddPassword();
            hideWelcomeMessage();
            showPasswords();
        }

        private void addPasswordsButton_Click(object sender, RoutedEventArgs e)
        {
            hidePasswords();
            hideWelcomeMessage();
            showAddPassword();
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            logout();
        }
    }
}
