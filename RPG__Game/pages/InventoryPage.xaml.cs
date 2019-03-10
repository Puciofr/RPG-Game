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
        public InventoryPage()
        {
            InitializeComponent();

            Application.Current.MainWindow.KeyDown += Page_KeyDown;

            InitializeComponent();

            List<InventoryListview> items = new List<InventoryListview>();
            items.Add(new InventoryListview() { Icon = new BitmapImage(new Uri("pack://application:,,,/resources/items/potion_health.jpg")), Number = 42, Name = "john@doe-family.com", ToolTip = "Přidá 20 zdraví" });
            items.Add(new InventoryListview() { Icon = new BitmapImage(new Uri("pack://application:,,,/resources/items/potion_health.jpg")), Number = 42, Name = "john@doe-family.com", ToolTip = "Přidá 20 zdraví" });
            items.Add(new InventoryListview() { Icon = new BitmapImage(new Uri("pack://application:,,,/resources/items/potion_health.jpg")), Number = 42, Name = "john@doe-family.com", ToolTip = "Přidá 20 zdraví" });
            items.Add(new InventoryListview() { Icon = new BitmapImage(new Uri("pack://application:,,,/resources/items/potion_health.jpg")), Number = 42, Name = "john@doe-family.com", ToolTip = "Přidá 20 zdraví" });
            items.Add(new InventoryListview() { Icon = new BitmapImage(new Uri("pack://application:,,,/resources/items/potion_health.jpg")), Number = 42, Name = "john@doe-family.com", ToolTip = "Přidá 20 zdraví" });
            items.Add(new InventoryListview() { Icon = new BitmapImage(new Uri("pack://application:,,,/resources/items/potion_health.jpg")), Number = 42, Name = "john@doe-family.com", ToolTip = "Přidá 20 zdraví" });
            lvUsers.ItemsSource = items;

        }
        public class InventoryListview
        {
            public BitmapImage Icon { get; set; }
            public int Number { get; set; }
            public string Name { get; set; }
            public string ToolTip { get; set; }
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
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

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void lvUsers_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }
    }
}
