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
using System.Windows.Shapes;

namespace game
{
    /// <summary>
    /// Interaction logic for scoreboard.xaml
    /// </summary>
    public partial class scoreboard : Window
    {
        public scoreboard()
        {
            InitializeComponent();
            results.Text = "username \t score\n \n";
            var leaderboard = Connection.populate();
            foreach (var item in leaderboard)
            {
                results.Text += item.userName + "\t \t " + item.score + "\n" + "\n";
            }
        }

        private void backMain(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        
    }
}
