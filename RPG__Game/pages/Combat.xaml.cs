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
using WpfAnimatedGif;

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
        private System.Windows.Threading.DispatcherTimer dispatcherTimer2;
        private System.Windows.Threading.DispatcherTimer delayTimer;
        private System.Windows.Threading.DispatcherTimer delayTimer2;
        private enum Turn : int { PlayerTurn, EnemyTurn };
        private Turn turn;
        private const int healthbarSize = 125;
        private EnemyAttack next;
        private bool attackEnabled;
        private int spellClickCount = 0;
        private PlayerAttack attackChoice;
        public Combat()
        {
            InitializeComponent();

            this.Cursor = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../../../resources/wow.cur");

            turn = Turn.PlayerTurn;

            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = TimeSpan.FromSeconds(0.025);

            dispatcherTimer2 = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer2.Tick += new EventHandler(dispatcherTimer2_Tick);
            dispatcherTimer2.Interval = TimeSpan.FromSeconds(0.025);

            delayTimer = new System.Windows.Threading.DispatcherTimer();
            delayTimer.Tick += new EventHandler(delayTimer_Tick);
            delayTimer.Interval = TimeSpan.FromSeconds(0.5);

            delayTimer2 = new System.Windows.Threading.DispatcherTimer();
            delayTimer2.Tick += new EventHandler(delayTimer2_Tick);
            delayTimer2.Interval = TimeSpan.FromSeconds(1.5);

            Application.Current.MainWindow.KeyDown += Page_KeyDown;

            dispatcherTimer2.Start();
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (MainWindow.CurrentPage != this)
            {
                return;
            }
            if (e.Key == Key.I)
            {
                if (attackEnabled)
                {
                    MainWindow.CurrentPage = MainWindow.InventoryPage;
                    MainWindow.Frame.Navigate(MainWindow.InventoryPage);
                }
            }
        }

        private void delayTimer_Tick(object sender, EventArgs e)
        {
            delayTimer.Stop();

            if(turn == Turn.PlayerTurn)
            {
                if (attackChoice.Name == "frostfirebolt")
                {
                    TransformGroup transformGroup = (TransformGroup)fireball_placeholder.RenderTransform;
                    TranslateTransform translateTransform = (TranslateTransform)transformGroup.Children[0];
                    translateTransform.X = -100;
                } else if (attackChoice.Name == "pyroblast")
                {
                    TransformGroup transformGroup = (TransformGroup)pyroblast_placeholder.RenderTransform;
                    TranslateTransform translateTransform = (TranslateTransform)transformGroup.Children[0];
                    translateTransform.X = -100;
                }

                dispatcherTimer.Start();
            } else
            {
                if (attackChoice.Name != "iceblock")
                {
                    characterHit();
                }
                else
                {
                    delayTimer2.Start();
                }
            }

        }

        private void delayTimer2_Tick(object sender, EventArgs e)
        {
            delayTimer2.Stop();

            character_standing.Visibility = Visibility.Visible;
            ice_block.Visibility = Visibility.Hidden;
            character_iceblock.Visibility = Visibility.Hidden;

            turn = Turn.PlayerTurn;

            attackEnabled = true;

            updateActionbar();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            TranslateTransform translateTransform = new TranslateTransform();
            if (attackChoice.Name == "frostfirebolt")
            {
                TransformGroup transformGroup = (TransformGroup)fireball_placeholder.RenderTransform;
                translateTransform = (TranslateTransform)transformGroup.Children[0];
                translateTransform.X += 20;
            } else if (attackChoice.Name == "pyroblast")
            {
                TransformGroup transformGroup = (TransformGroup)pyroblast_placeholder.RenderTransform;
                translateTransform = (TranslateTransform)transformGroup.Children[0];
                translateTransform.X += 20;
            } else if (attackChoice.Name == "evocation")
            {
                stats.CurrentMana += 1;
                updateHealthbars();

                if (stats.CurrentMana == stats.MaxMana)
                {
                    dispatcherTimer.Stop();

                    character_standing.Visibility = Visibility.Visible;
                    character_evocation.Visibility = Visibility.Hidden;

                    turn = Turn.EnemyTurn;

                    enemyAttack();
                }
            } else if (attackChoice.Name == "escape")
            {
                TransformGroup transformGroup = (TransformGroup)character_escape.RenderTransform;
                translateTransform = (TranslateTransform)transformGroup.Children[0];
                translateTransform.X += 4;
            }


            if (translateTransform.X == 400)
            {
                enemyHit();
                dispatcherTimer.Stop();
                translateTransform.X = 1000;
            } else if (translateTransform.X == 180 && attackChoice.Name == "escape")
            {
                dispatcherTimer.Stop();

                turn = Turn.PlayerTurn;

                MainWindow.CurrentPage = MainWindow.OpenWorld;
                MainWindow.Frame.Navigate(MainWindow.OpenWorld);

                MainWindow.Stats.Position -= 400;

                character_standing.Visibility = Visibility.Visible;
                character_escape.Visibility = Visibility.Hidden;

                MainWindow.Stats.CurrentHealth = MainWindow.Stats.MaxHealth;
                MainWindow.Stats.CurrentMana = MainWindow.Stats.MaxMana;

                enemystats.CurrentHealth = enemystats.MaxHealth;
                enemystats.CurrentRage = 0;

                attackEnabled = true;
            } 
        }

        private void dispatcherTimer2_Tick(object sender, EventArgs e)
        {
            ManaLabel.Opacity -= 0.05;
            PyroLabel.Opacity -= 0.05;
        }

        public void characterHitCompleted(object sender, RoutedEventArgs e)
        {
            character_standing.Visibility = Visibility.Visible;
            character_hit.Visibility = Visibility.Hidden;

            this.Cursor = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../../../resources/wow3.cur");

            turn = Turn.PlayerTurn;

            attackEnabled = true;

            updateActionbar();

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
            enemy_standing.Visibility = Visibility.Visible;
            enemy_death.Visibility = Visibility.Hidden;

            turn = Turn.PlayerTurn;

            attackEnabled = true;
            frostfirebolt.Opacity = 0;
            spellClickCount = 0;

            MainWindow.CurrentQuest.CurrentProgress++;

            if (MainWindow.CurrentQuest.CurrentProgress == MainWindow.CurrentQuest.CompletedProgress)
            {
                MainWindow.CurrentPage = MainWindow.QuestCompleted;
                MainWindow.Frame.Navigate(MainWindow.QuestCompleted);
            }
            else
            {
                MainWindow.CurrentPage = MainWindow.OpenWorld;
                MainWindow.Frame.Navigate(MainWindow.OpenWorld);
            }

        }

        public void characterDeathCompleted(object sender, RoutedEventArgs e)
        {
            MainWindow.CurrentPage = MainWindow.GameOver;
            MainWindow.Frame.Navigate(new GameOver());
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
            if (stats.CurrentMana >= stats.GetByName("frostfirebolt").Cost)
            {
                frostfirebolt.Opacity = 0;
            }

            if (stats.CurrentMana >= stats.GetByName("pyroblast").Cost && spellClickCount > 1)
            {
                pyroblast.Opacity = 0;
            }

            attackEnabled = true;

        }

        public void characterIceBlockCompleted(object sender, RoutedEventArgs e)
        {
            ice_block.Visibility = Visibility.Visible;

            turn = Turn.EnemyTurn;

            enemyAttack();
        }
        public void characterEvocationCompleted(object sender, RoutedEventArgs e)
        {
            
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
                    stats = MainWindow.Stats;
                    enemystats = MainWindow.pickClosestEnemy();

                    level.Content = stats.Level;
                    name.Content = stats.Name;

                    enemyLevel.Content = enemystats.Level;
                    enemyName.Content = enemystats.Name;

                    updateHealthbars();

                    attackEnabled = true;

                    updateActionbar();
                }
            }
        }


        private void frostfirebolt_Click(object sender, RoutedEventArgs e)
        {
            spellClickCount++;

            if (stats.CurrentMana >= stats.GetByName("frostfirebolt").Cost)
            {
                if (attackEnabled == true)
                {
                    attackEnabled = false;
 
                    attackChoice = stats.GetByName("frostfirebolt");

                    frostfirebolt.Opacity = 0.75;

                    character_attack.Visibility = Visibility.Visible;
                    character_standing.Visibility = Visibility.Hidden;

                    delayTimer.Start();

                    stats.CurrentMana -= attackChoice.Cost;

                    updateHealthbars();
                    updateActionbar();

                    this.Cursor = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../../../resources/wow.cur");

                    dispatcherTimer.Interval = TimeSpan.FromSeconds(0.025);

                }
            }
            else
            {
                ManaLabel.Opacity = 4;
            }
        }

        private void pyroblast_Click(object sender, RoutedEventArgs e)
        {
            if (attackEnabled == true)
            {
                if (spellClickCount > 1)
                {
                    if (stats.CurrentMana >= stats.GetByName("pyroblast").Cost)
                    {
                        attackEnabled = false;

                        spellClickCount = 0;
                        attackChoice = stats.GetByName("pyroblast");

                        pyroblast.Opacity = 0.75;

                        character_attack.Visibility = Visibility.Visible;
                        character_standing.Visibility = Visibility.Hidden;

                        delayTimer.Start();

                        stats.CurrentMana -= attackChoice.Cost;
                        updateHealthbars();
                        updateActionbar();

                        this.Cursor = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../../../resources/wow.cur");

                        dispatcherTimer.Interval = TimeSpan.FromSeconds(0.025);

                    }
                    else
                    {
                        ManaLabel.Opacity = 4;
                    }

                }
                else
                {
                    PyroLabel.Opacity = 4;
                }
            }
        }

        private void iceblock_Click(object sender, RoutedEventArgs e)
        {
            if (attackEnabled == true)
            {
                if (stats.CurrentMana >= stats.GetByName("iceblock").Cost)
                {
                    attackEnabled = false;

                    attackChoice = stats.GetByName("iceblock");

                    character_iceblock.Visibility = Visibility.Visible;
                    character_standing.Visibility = Visibility.Hidden;

                    stats.CurrentMana -= attackChoice.Cost;
                    updateHealthbars();
                    updateActionbar();
                }
                else
                {
                    ManaLabel.Opacity = 4;
                }
            }

        }

        private void evocation_Click(object sender, RoutedEventArgs e)
        {
            if (attackEnabled == true)
            {
                if (stats.CurrentMana < stats.MaxMana)
                {
                    attackEnabled = false;

                    attackChoice = stats.GetByName("evocation");

                    character_evocation.Visibility = Visibility.Visible;
                    character_standing.Visibility = Visibility.Hidden;

                    updateHealthbars();

                    updateActionbar();

                    dispatcherTimer.Interval = TimeSpan.FromSeconds(0.25);

                    delayTimer.Start();
                }
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
                if (enemystats.CurrentHealth <= attackChoice.Damage)
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

                    enemystats.CurrentHealth = enemystats.CurrentHealth - attackChoice.Damage;
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

        private void updateActionbar()
        {
            if (stats.CurrentMana >= stats.GetByName("frostfirebolt").Cost && attackEnabled == true)
            {
                frostfirebolt.Opacity = 0;
            }
            else
            {
                frostfirebolt.Opacity = 0.75;
            }

            if (stats.CurrentMana >= stats.GetByName("pyroblast").Cost && spellClickCount > 1 && attackEnabled == true)
            {
                pyroblast.Opacity = 0;
            }
            else
            {
                pyroblast.Opacity = 0.75;
            }

            if (stats.CurrentMana >= stats.GetByName("iceblock").Cost && attackEnabled == true)
            {
                iceblock.Opacity = 0;
            }
            else
            {
                iceblock.Opacity = 0.75;
            }

            if (stats.CurrentMana < stats.MaxMana && attackEnabled == true)
            {
                evocation.Opacity = 0;
            }
            else
            {
                evocation.Opacity = 0.75;
            }

            if (attackEnabled == true)
            {
                escape.Opacity = 0;
            }
            else
            {
                escape.Opacity = 0.75;
            }
        }


        private void updateGifs(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(this.Visibility == Visibility.Visible)
            {
                var controller = ImageBehavior.GetAnimationController(character_standing);

                if (controller != null)
                {
                    if (character_standing.Visibility == Visibility.Visible)
                    {
                        controller.Play();
                    }
                    if (enemy_standing.Visibility == Visibility.Visible)
                    {
                        controller = ImageBehavior.GetAnimationController(enemy_standing);
                        controller.Play();
                    }
                    if (enemy_block.Visibility == Visibility.Visible)
                    {
                        controller = ImageBehavior.GetAnimationController(enemy_block);
                        controller.Play();
                    }
                    if (enemy_death.Visibility == Visibility.Visible)
                    {
                        controller = ImageBehavior.GetAnimationController(enemy_death);
                        controller.Play();
                    }
                    if (enemy_hit.Visibility == Visibility.Visible)
                    {
                        controller = ImageBehavior.GetAnimationController(enemy_hit);
                        controller.Play();
                    }
                    if (enemy_slam.Visibility == Visibility.Visible)
                    {
                        controller = ImageBehavior.GetAnimationController(enemy_slam);
                        controller.Play();
                    }
                    if (enemy_attack.Visibility == Visibility.Visible)
                    {
                        controller = ImageBehavior.GetAnimationController(enemy_attack);
                        controller.Play();
                    }
                }
            }
        }

        private void spell_MouseEnter(object sender, MouseEventArgs e)
        {
            if (attackEnabled)
            {
                this.Cursor = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../../../resources/wow3.cur");
            }
        }

        private void spell_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../../../resources/wow.cur");
        }

        private void escape_Click(object sender, RoutedEventArgs e)
        {
            if (attackEnabled)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Opravdu si přejete utéct z boje?", "Potvrzení", System.Windows.MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    attackChoice = MainWindow.Stats.GetByName("escape");

                    TransformGroup transformGroup = (TransformGroup)character_escape.RenderTransform;
                    TranslateTransform translateTransform = (TranslateTransform)transformGroup.Children[0];
                    translateTransform.X = 0;

                    character_escape.Visibility = Visibility.Visible;
                    character_standing.Visibility = Visibility.Hidden;
                    
                    dispatcherTimer.Start();
                }
            }
        }

    }
}
