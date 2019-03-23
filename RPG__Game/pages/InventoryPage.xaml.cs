using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RPG_Game;
using RPG_Game.pages;
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
    /// Interakční logika pro InventoryPage.xaml
    /// </summary>
    public partial class InventoryPage : Page
    {
        private const int healthbarSize = 175;
        public InventoryPage()
        {
            InitializeComponent();

            updateHealthbars();

            Application.Current.MainWindow.KeyDown += Page_KeyDown;

            List<InventoryListview> items = new List<InventoryListview>();
            items.Add(new InventoryListview() { Icon = new BitmapImage(new Uri("pack://application:,,,/resources/items/potion_health.jpg")), Number = 5, Name = "HealthPotion", ToolTip = "Přidá 20 zdraví" });
            items.Add(new InventoryListview() { Icon = new BitmapImage(new Uri("pack://application:,,,/resources/items/potion_mana.jpg")), Number = 5, Name = "ManaPotion", ToolTip = "Přidá 20 many" });

            lvUsers.ItemsSource = items;

            level.Content = MainWindow.stats.Level;
            name.Content = MainWindow.stats.Name;

        }

        public class InventoryListview
        {
            public BitmapImage Icon { get; set; }
            public int Number { get; set; }
            public string Name { get; set; }
            public string ToolTip { get; set; }
        }

        public void Listview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView inventory = sender as ListView;
            InventoryListview lvi = (inventory.SelectedItem) as InventoryListview;

            lvi.Number--;

            if (lvi.Number == 0)
            {
                //inventory.Items.RemoveAt(inventory.SelectedIndex);
                //(inventory.ItemsSource as ItemCollection).RemoveAt(0);
                //var source = inventory.ItemsSource.removeitem;
                //inventory.Items.Remove(inventory.Items.CurrentItem);

            }

            inventory.Items.Refresh();

            if (lvi.Name == "HealthPotion")
            {
                MainWindow.stats.CurrentHealth = MainWindow.stats.MaxHealth;
                updateHealthbars();
            } else if (lvi.Name == "ManaPotion")
            {
                MainWindow.stats.CurrentMana = MainWindow.stats.MaxMana;
                updateHealthbars();
            }

        }




        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.I)
            {
                MainWindow.frame.Navigate(new Combat());
            }
        }

        private void SliderAdd_Click(object sender, RoutedEventArgs e)
        {
            StaminaSlider.Value += 1;
        }

       
        private void SliderRemove_Click(object sender, RoutedEventArgs e)
        {
            StaminaSlider.Value -= 1;
        }

        private void SliderAdd2_Click(object sender, RoutedEventArgs e)
        {
            IntellectSlider.Value += 1;
        }

        private void SliderRemove2_Click(object sender, RoutedEventArgs e)
        {
            IntellectSlider.Value -= 1;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void lvUsers_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        private void HealthPotion_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.stats.CurrentHealth = MainWindow.stats.MaxHealth;
            updateHealthbars();
        }

        private void ManaPotion_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.stats.CurrentMana = MainWindow.stats.MaxMana;
            updateHealthbars();
        }

        private void updateHealthbars()
        {
            Health.Width = healthbarSize * MainWindow.stats.CurrentHealth / MainWindow.stats.MaxHealth;
            HealthNumeric.Content = MainWindow.stats.CurrentHealth + " / " + MainWindow.stats.MaxHealth;
            Mana.Width = healthbarSize * MainWindow.stats.CurrentMana / MainWindow.stats.MaxMana;
            ManaNumeric.Content = MainWindow.stats.CurrentMana + " / " + MainWindow.stats.MaxMana;
        }

    }
}
