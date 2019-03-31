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

namespace RPG__Game.pages
{
    /// <summary>
    /// Interakční logika pro GameOver.xaml
    /// </summary>
    public partial class GameOver : Page
    {
        public GameOver()
        {
            InitializeComponent();

            this.Cursor = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../../../resources/wow.cur");

        }

        private void newGame_Click(object sender, RoutedEventArgs e)
        {

        }

        private void loadGame_Click(object sender, RoutedEventArgs e)
        {

        }

        private void exitGame_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Opravdu si přejete ukončit hru?", "Potvrzení", System.Windows.MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                System.Windows.Application.Current.Shutdown();
            }
        }

        private void button_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../../../resources/wow3.cur");
        }

        private void button_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../../../resources/wow.cur");
        }

    }
}
