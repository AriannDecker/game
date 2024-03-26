using game.classes;
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

namespace game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void begin (object sender, RoutedEventArgs e)
        {
            var firstName = fName.Text;
            var lastName = lName.Text;
            var email_Address = email.Text;
            var user = userName.Text;

            var numQuestions = 0;

            if (q10.IsChecked ?? false)
                numQuestions = 10;
            else if (q25.IsChecked ?? false)
                numQuestions = 25;
            else if (q50.IsChecked ?? false)
                numQuestions = 50;
            else
                numQuestions = 10;

            var success = Connection.submission(firstName, lastName, email_Address, user);

            if (!success)
                return;

            secret.numQuestions = numQuestions;
            secret.firstName = firstName;
            secret.user = user;

            new start().Show();
            this.Close();
        }

        private void scoreboard(object sender, RoutedEventArgs e)
        {
            new scoreboard().Show();
            this.Close();
        }
    }
}
