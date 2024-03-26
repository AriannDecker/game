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
    /// Interaction logic for start.xaml
    /// </summary>
    public partial class start : Window
    {

        private int answer {  get; set; }
        private int score { get; set; }

        public start()
        {
            InitializeComponent();
            uName.Content = secret.user;
            score = 0;
            scores.Content = score;
            var equation = generateQuestion();


            Question.Content +=" "+ equation[0];
            answer = Convert.ToInt32(equation[1]);
            secret.numQuestions--;
        }

        private string[] generateQuestion()
        {
            Random random = new Random();
            var x = random.Next(-10, 101);
            var y = random.Next(-10, 101);

            var operand = random.Next(0, 4);
            var symbol = "";
            var answer = 0;


            if (operand == 0)
            {
                symbol = "+";
                answer = x + y;
            }
            else if (operand == 1)
            {
                symbol = "-";
                answer = x - y;
            }
            else if (operand == 2)
            {
                symbol = "*";
                answer = x * y;
            }
            else if (operand == 3)
            {
                symbol = "/";
                answer = (int)Math.Round((double)(x / y));
            }

            var question = $"{x} {symbol} {y}";

            var list  = new List<string>();

            list.Add(question);
            list.Add(answer.ToString());

            return list.ToArray();


        }

        private void check(object sender, RoutedEventArgs e)
        {
            var input = Convert.ToInt32(userAnswer.Text);

            if (input == answer) 
            {
                score += 5;
            }
            else
            {
                score -= 3;
            }

            if (secret.numQuestions != 0)
            {
                Question.Content = "question";
                userAnswer.Text = "";
                scores.Content = score;
                var equation = generateQuestion();

                Question.Content += " " + equation[0];
                answer = Convert.ToInt32(equation[1]);

                secret.numQuestions--;
                return;

            }

            Connection.addScore(secret.user, score);
            new scoreboard().Show();
            this.Close();

        }

        private void quit(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
            
        }
    }
}
