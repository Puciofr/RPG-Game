using RPG__Game;
using RPG__Game.pages;
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

namespace RPG_Game.pages
{
    /// <summary>
    /// Interakční logika pro Combat.xaml
    /// </summary>
    public partial class Combat : Page
    {
        private PlayerStats stats;
        private EnemyStats enemystats;
        private System.Windows.Threading.DispatcherTimer dispatcherTimer;
        private System.Windows.Threading.DispatcherTimer delayTimer;
        private enum Turn : int { PlayerTurn, EnemyTurn };
        private Turn turn;
        private const int healthbarSize = 125;
        private EnemyAttack next;
        public Combat()
        {
            InitializeComponent();

            turn = Turn.PlayerTurn;

            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = TimeSpan.FromSeconds(0.025);

            delayTimer = new System.Windows.Threading.DispatcherTimer();
            delayTimer.Tick += new EventHandler(delayTimer_Tick);
            delayTimer.Interval = TimeSpan.FromSeconds(0.5);

            Application.Current.MainWindow.KeyDown += Page_KeyDown;
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.I)
            {
                MainWindow.frame.Navigate(new InventoryPage());
            }
        }

        private void delayTimer_Tick(object sender, EventArgs e)
        {
            delayTimer.Stop();

            if(turn == Turn.PlayerTurn)
            {
                TransformGroup transformGroup = (TransformGroup)fireball_placeholder.RenderTransform;
                TranslateTransform translateTransform = (TranslateTransform)transformGroup.Children[0];
                translateTransform.X = -100;

                dispatcherTimer.Start();
            } else
            {
                characterHit();
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            TransformGroup transformGroup = (TransformGroup)fireball_placeholder.RenderTransform;
            TranslateTransform translateTransform = (TranslateTransform)transformGroup.Children[0];
            translateTransform.X += 20;

            if (translateTransform.X == 400)
            {
                enemyHit();
                dispatcherTimer.Stop();
                translateTransform.X = 1000;
            }

        }

        public void characterHitCompleted(object sender, RoutedEventArgs e)
        {
            character_standing.Visibility = Visibility.Visible;
            character_hit.Visibility = Visibility.Hidden;

            turn = Turn.PlayerTurn;

            frostfirebolt.IsEnabled = true;
            frostfirebolt.Opacity = 0;

        }
        public void enemyHitCompleted(object sender, RoutedEventArgs e)
        {
            enemy_standing.Visibility = Visibility.Visible;
            enemy_hit.Visibility = Visibility.Hidden;

            turn = Turn.EnemyTurn;

            enemyAttack();
        }

        public void characterAttackCompleted(object sender, RoutedEventArgs e)
        {
            character_standing.Visibility = Visibility.Visible;
            character_attack.Visibility = Visibility.Hidden;
        }
        public void enemyAttackCompleted(object sender, RoutedEventArgs e)
        {
            enemy_standing.Visibility = Visibility.Visible;
            enemy_attack.Visibility = Visibility.Hidden;

        }

        public void enemyDeathCompleted(object sender, RoutedEventArgs e)
        {
            stats.CurrentHealth = stats.MaxHealth;
            stats.CurrentMana = stats.MaxMana;
            MainWindow.frame.Navigate(new OpenWorld());
        }

        public void characterDeathCompleted(object sender, RoutedEventArgs e)
        {
            MainWindow.frame.Navigate(new GameOver());
        }

        public void enemySlamCompleted(object sender, RoutedEventArgs e)
        {
            enemy_standing.Visibility = Visibility.Visible;
            enemy_slam.Visibility = Visibility.Hidden;
        }

        public void characterDodgeCompleted(object sender, RoutedEventArgs e)
        {
            character_standing.Visibility = Visibility.Visible;
            character_dodge.Visibility = Visibility.Hidden;

            turn = Turn.PlayerTurn;

            frostfirebolt.IsEnabled = true;
            frostfirebolt.Opacity = 0;
        }

        public void enemyBlockCompleted(object sender, RoutedEventArgs e)
        {
            enemy_standing.Visibility = Visibility.Visible;
            enemy_block.Visibility = Visibility.Hidden;

            turn = Turn.EnemyTurn;

            enemyAttack();
        }
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                MainWindow mainWindow = window as MainWindow;

                if (mainWindow != null)
                {
                    stats = mainWindow.stats;
                    enemystats = new EnemyStats();

                    level.Content = stats.Level;
                    name.Content = stats.Name;

                    enemyLevel.Content = enemystats.Level;
                    enemyName.Content = enemystats.Name;

                    updateHealthbars();

                }
            }
        }


        private void frostfirebolt_Click(object sender, RoutedEventArgs e)
        {
            if (stats.CurrentMana >= stats.GetbByName("frostfirebolt").Cost)
            {
                frostfirebolt.Opacity = 0.75;

                character_attack.Visibility = Visibility.Visible;
                character_standing.Visibility = Visibility.Hidden;

                frostfirebolt.IsEnabled = false;

                delayTimer.Start();

                stats.CurrentMana -= stats.GetbByName("frostfirebolt").Cost;
                updateHealthbars();
            }

        }
        private void characterHit()
        {
            Random r = new Random();

            if (r.NextDouble() <= stats.DodgeChance)
            {
                character_dodge.Visibility = Visibility.Visible;
                character_standing.Visibility = Visibility.Hidden;
            }
            else
            {
                if (stats.CurrentHealth <= next.Damage)
                {
                    character_death.Visibility = Visibility.Visible;
                    character_standing.Visibility = Visibility.Hidden;

                    stats.CurrentHealth = 0;
                    stats.CurrentMana = 0;
                }
                else
                {
                    character_hit.Visibility = Visibility.Visible;
                    character_standing.Visibility = Visibility.Hidden;

                    stats.CurrentHealth = stats.CurrentHealth - next.Damage;
                }
            }

            updateHealthbars();
        }
        private void enemyHit()
        {
            Random r = new Random();

            if (r.NextDouble() <= enemystats.DodgeChance)
            {
                enemy_block.Visibility = Visibility.Visible;
                enemy_standing.Visibility = Visibility.Hidden;
            } else
            {
                if (enemystats.CurrentHealth <= stats.GetbByName("frostfirebolt").Damage)
                {
                    enemy_death.Visibility = Visibility.Visible;
                    enemy_standing.Visibility = Visibility.Hidden;

                    enemystats.CurrentHealth = 0;
                    enemystats.CurrentRage = 0;
                }
                else
                {
                    enemy_hit.Visibility = Visibility.Visible;
                    enemy_standing.Visibility = Visibility.Hidden;

                    enemystats.CurrentHealth = enemystats.CurrentHealth - stats.GetbByName("frostfirebolt").Damage;
                }
            }

            updateHealthbars();
        }

        private void enemyAttack()
        {

            next = enemystats.PickBestAttack();
            if (next.Name == "Slam")
            {
                enemy_slam.Visibility = Visibility.Visible;

            } else
            {
                enemy_attack.Visibility = Visibility.Visible;
            }

            enemy_standing.Visibility = Visibility.Hidden;

            enemystats.CurrentRage -= next.Cost;

            updateHealthbars();

            delayTimer.Start();

        }

        private void updateHealthbars()
        {
            Health.Width = healthbarSize * stats.CurrentHealth / stats.MaxHealth;
            HealthNumeric.Content = stats.CurrentHealth + " / " + stats.MaxHealth;
            Mana.Width = healthbarSize * stats.CurrentMana / stats.MaxMana;
            ManaNumeric.Content = stats.CurrentMana + " / " + stats.MaxMana;


            enemyHealth.Width = healthbarSize * enemystats.CurrentHealth / enemystats.MaxHealth;
            enemyHealthNumeric.Content = enemystats.CurrentHealth + " / " + enemystats.MaxHealth;
            enemyRage.Width = healthbarSize * enemystats.CurrentRage / enemystats.MaxRage;
            enemyRageNumeric.Content = enemystats.CurrentRage + " / " + enemystats.MaxRage;

        }

    }
}
