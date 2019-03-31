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
    /// Interakční logika pro VendorPage.xaml
    /// </summary>
    public partial class VendorPage : Page
    {
        private System.Windows.Threading.DispatcherTimer dispatcherTimer3;

        public VendorPage()
        {
            InitializeComponent();

            Application.Current.MainWindow.KeyDown += Page_KeyDown;

            this.Cursor = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../../../resources/wow.cur");

            golds.Content = MainWindow.Inventory.Golds;

            dispatcherTimer3 = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer3.Tick += new EventHandler(dispatcherTimer3_Tick);
            dispatcherTimer3.Interval = TimeSpan.FromSeconds(0.025);

            dispatcherTimer3.Start();
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (MainWindow.CurrentPage != this)
            {
                return;
            }
            if (e.Key == Key.I)
            {
                MainWindow.CurrentPage = MainWindow.InventoryPage;
                MainWindow.Frame.Navigate(MainWindow.InventoryPage);
            }
        }
        private void vendor_healthpotion_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.Inventory.Golds < 3)
            {
                goldsLabel.Opacity = 4;
            }
            else
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Opravdu si přejete koupit lektvar?", "Potvrzení", System.Windows.MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    MainWindow.Inventory.Golds -= 3;

                    MainWindow.Inventory.GetByName("HealthPotion").Number++;

                    updateGolds();
                }

            }

        }

        private void vendor_manapotion_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.Inventory.Golds < 2)
            {  
                goldsLabel.Opacity = 4;
            }
            else
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Opravdu si přejete koupit lektvar?", "Potvrzení", System.Windows.MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    MainWindow.Inventory.Golds -= 2;

                    MainWindow.Inventory.GetByName("ManaPotion").Number++;

                    updateGolds();
                }
            }
        }

        private void updateGolds()
        {
            golds.Content = MainWindow.Inventory.Golds;
        }

        private void dispatcherTimer3_Tick(object sender, EventArgs e)
        {
            goldsLabel.Opacity -= 0.05;
        }

        private void button_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../../../resources/wow2.cur");
        }

        private void button_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../../../resources/wow.cur");
        }

        private void button_MouseEnter2(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../../../resources/wow3.cur");
        }

        private void button_MouseLeave2(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../../../resources/wow.cur");
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.CurrentPage = MainWindow.QuestCompleted;
            MainWindow.Frame.Navigate(MainWindow.QuestCompleted);
        }
    }
}
