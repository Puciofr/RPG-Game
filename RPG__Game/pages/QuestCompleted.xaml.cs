using RPG_Game;
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
    /// Interakční logika pro QuestCompleted.xaml
    /// </summary>
    public partial class QuestCompleted : Page
    {
        public QuestCompleted()
        {
            InitializeComponent();

            this.Cursor = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../../../resources/wow.cur");
        }

        private void vendorbutton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.CurrentPage = MainWindow.VendorPage;
            MainWindow.Frame.Navigate(MainWindow.VendorPage);
        }

        private void nextlevelbutton_Click(object sender, RoutedEventArgs e)
        {

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
