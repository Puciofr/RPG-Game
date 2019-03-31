using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RPG__Game.inventory;
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
        private int remainingPoints;
        public InventoryPage()
        {
            InitializeComponent();

            this.Cursor = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../../../resources/wow.cur");

            updateHealthbars();

            Application.Current.MainWindow.KeyDown += Page_KeyDown;

            lvUsers.ItemsSource = MainWindow.Inventory.PotionInventory;

            level.Content = MainWindow.Stats.Level;
            name.Content = MainWindow.Stats.Name;

            golds.Content = MainWindow.Inventory.Golds;

            loadSliders();

            updateSliders();

        }

        public void Listview_SelectionChanged(object sender, MouseButtonEventArgs e)
        {

            var lvi = (sender as Grid).DataContext as IPotion;

            if (lvi.Name == "HealthPotion")
            {
                if (MainWindow.Stats.CurrentHealth < MainWindow.Stats.MaxHealth)
                {
                    MainWindow.Stats.CurrentHealth = MainWindow.Stats.MaxHealth;
                    updateHealthbars();
                } else
                {
                    return;
                }
            }
            else if (lvi.Name == "ManaPotion")
            {
                if (MainWindow.Stats.CurrentMana < MainWindow.Stats.MaxMana)
                {
                    MainWindow.Stats.CurrentMana = MainWindow.Stats.MaxMana;
                    updateHealthbars();
                } else
                {
                    return;
                }
            }

            lvi.Number--;

            if (lvi.Number == 0)
            {
                var source = lvUsers.ItemsSource as List<IPotion>;
                source.Remove(lvi);
            }

            lvUsers.Items.Refresh();

        }


        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (MainWindow.CurrentPage != this)
            {
                return;
            }
            if (e.Key == Key.Escape)
            {
                if (MainWindow.Stats.Position != MainWindow.pickClosestEnemy().Positon)
                {
                    MainWindow.CurrentPage = MainWindow.OpenWorld;
                    MainWindow.Frame.Navigate(MainWindow.OpenWorld);
                } else
                {
                    MainWindow.CurrentPage = MainWindow.Combat;
                    MainWindow.Frame.Navigate(MainWindow.Combat);
                }

            }
        }

        private void SliderAdd_Click(object sender, RoutedEventArgs e)
        {
            StaminaSlider.Value += 1;

            updateSliders();
        }


        private void SliderRemove_Click(object sender, RoutedEventArgs e)
        {
            StaminaSlider.Value -= 1;

            updateSliders();
        }

        private void SliderAdd2_Click(object sender, RoutedEventArgs e)
        {
            IntellectSlider.Value += 1;

            updateSliders();
        }

        private void SliderRemove2_Click(object sender, RoutedEventArgs e)
        {
            IntellectSlider.Value -= 1;

            updateSliders();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void lvUsers_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }


        private void updateHealthbars()
        {
            Health.Width = healthbarSize * MainWindow.Stats.CurrentHealth / MainWindow.Stats.MaxHealth;
            HealthNumeric.Content = MainWindow.Stats.CurrentHealth + " / " + MainWindow.Stats.MaxHealth;
            Mana.Width = healthbarSize * MainWindow.Stats.CurrentMana / MainWindow.Stats.MaxMana;
            ManaNumeric.Content = MainWindow.Stats.CurrentMana + " / " + MainWindow.Stats.MaxMana;
        }

        private void updatePage(object sender, DependencyPropertyChangedEventArgs e)
        {
            updateGolds();

            updateHealthbars();
        }

        private void loadSliders()
        {
            StaminaSlider.Value = MainWindow.Stats.Stamina;
            IntellectSlider.Value = MainWindow.Stats.Intellect;
            remainingPoints = MainWindow.Stats.UpgradePoints;
        }

        private void updateSliders()
        {

            if (StaminaSlider.Value == MainWindow.Stats.Stamina)
            {
                SliderRemove.Visibility = Visibility.Hidden;
                SliderRemoveImg.Visibility = Visibility.Hidden;
            }
            else
            {
                SliderRemove.Visibility = Visibility.Visible;
                SliderRemoveImg.Visibility = Visibility.Visible;
            }

            if (IntellectSlider.Value == MainWindow.Stats.Intellect)
            {
                SliderRemove2.Visibility = Visibility.Hidden;
                SliderRemove2Img.Visibility = Visibility.Hidden;
            }
            else
            {
                SliderRemove2.Visibility = Visibility.Visible;
                SliderRemove2Img.Visibility = Visibility.Visible;
            }

            remainingPoints = MainWindow.Stats.UpgradePoints + MainWindow.Stats.Stamina - (int)StaminaSlider.Value + MainWindow.Stats.Intellect - (int)IntellectSlider.Value;
            UpgradePointsLabel.Content = "Počet vylepšovajících bodů: " + remainingPoints;

            if (remainingPoints == 0)
            {
                SliderAdd.Visibility = Visibility.Hidden;
                SliderAddImg.Visibility = Visibility.Hidden;

                SliderAdd2.Visibility = Visibility.Hidden;
                SliderAdd2Img.Visibility = Visibility.Hidden;
            } else
            {
                SliderAdd.Visibility = Visibility.Visible;
                SliderAddImg.Visibility = Visibility.Visible;

                SliderAdd2.Visibility = Visibility.Visible;
                SliderAdd2Img.Visibility = Visibility.Visible;
            }

            if (remainingPoints != MainWindow.Stats.UpgradePoints)
            {
                ApplyChanges.Visibility = Visibility.Visible;
            } else
            {
                ApplyChanges.Visibility = Visibility.Hidden;
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

        private void img_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../../../resources/wow3.cur");
        }

        private void img_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../../../resources/wow.cur");
        }

        private void ApplyChanges_Click(object sender, RoutedEventArgs e)
        {
            int newStamina = (int)StaminaSlider.Value - MainWindow.Stats.Stamina;
            int newIntellect = (int)IntellectSlider.Value - MainWindow.Stats.Intellect;

            MainWindow.Stats.Stamina = (int)StaminaSlider.Value;
            MainWindow.Stats.Intellect = (int)IntellectSlider.Value;

            MainWindow.Stats.UpgradePoints = remainingPoints;

            MainWindow.Stats.MaxHealth = 20 + MainWindow.Stats.Stamina * 3;
            MainWindow.Stats.MaxMana = 20 + MainWindow.Stats.Intellect * 3;

            MainWindow.Stats.CurrentHealth += newStamina * 3;
            MainWindow.Stats.CurrentMana += newIntellect * 3;

            updateSliders();

            updateHealthbars();

        }

        private void updateGolds()
        {
            golds.Content = MainWindow.Inventory.Golds;
        }
    }
}