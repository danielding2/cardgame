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

namespace Blackjack.Views
{
    /// <summary>
    /// Interaction logic for EndWindow.xaml
    /// </summary>
    public partial class EndWindow
    {
        public EndWindow(string name)
        {
            InitializeComponent();
            WinMessage.Content = name + " won!";
        }

        private void Retry(object sender, RoutedEventArgs e)
        {
            new StartWindow().Show();
            Close();
        }

        private void Quit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
