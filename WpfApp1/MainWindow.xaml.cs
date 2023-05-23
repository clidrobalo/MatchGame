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
                "🤷‍", "🤷",
                "🤳", "🤳‍",
                "💻", "👓",
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
    }
}
