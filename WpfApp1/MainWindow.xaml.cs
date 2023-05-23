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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextBlock lastTextBlockClicked;
        bool findingMatch = false;

        public MainWindow()
        {
            InitializeComponent();
            SetupGame();
        }

        public void SetupGame()
        {
            List<string> animalEmoji = new List<string>()
            {
                "😊", "😊",
                "🤣", "🤣",
                "😍", "😍",
                "👌", "👌",
                "‍🏍", "🏍",
                "🤳", "🤳",
                "💻", "💻",
                "🎶", "🎶"
            };

            Random random = new Random();

            foreach(TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                int idx = random.Next(animalEmoji.Count);
                string nextEmoji = animalEmoji[idx];
                textBlock.Text = nextEmoji;
                animalEmoji.RemoveAt(idx);
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            /* If it's the first in the
           * pair being clicked, keep
           * track of which TextBlock
           * was clicked and make the
           * animal disappear. If
           * it's the second one,
           * either make it disappear
           * (if it's a match) or
           * bring back the first one
           * (if it's not).
           */

            TextBlock textBlock = sender as TextBlock;
            if (!findingMatch)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            } 
            else if(textBlock.Text.Equals(lastTextBlockClicked.Text))
            {
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }
    }
}
