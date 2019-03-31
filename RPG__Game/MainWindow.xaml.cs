using RPG__Game;
using RPG__Game.inventory;
using RPG__Game.pages;
using RPG_Game.pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RPG_Game
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame Frame;
        public static PlayerStats Stats;
        public static Inventory Inventory;
        public static List<EnemyStats> Enemies;
        public static OpenWorld OpenWorld;
        public static Combat Combat;
        public static InventoryPage InventoryPage;
        public static QuestCompleted QuestCompleted;
        public static VendorPage VendorPage;
        public static GameOver GameOver;
        public static Page CurrentPage;
        public static Quest CurrentQuest;

        public MainWindow()
        {
            InitializeComponent();

            const int snugContentWidth = 800;
            const int snugContentHeight = 490;

            var horizontalBorderHeight = SystemParameters.ResizeFrameHorizontalBorderHeight;
            var verticalBorderWidth = SystemParameters.ResizeFrameVerticalBorderWidth;
            var captionHeight = SystemParameters.CaptionHeight;

            Width = snugContentWidth + 2 * verticalBorderWidth;
            Height = snugContentHeight + captionHeight + 2 * horizontalBorderHeight;

            Frame = myFrame;

            Stats = new PlayerStats();

            Inventory = new Inventory();

            Inventory.PotionInventory.Add(new HealthPotion());
            Inventory.PotionInventory.Add(new ManaPotion());

            CurrentQuest = new Quest();
            CurrentQuest.Description = "zabij 5 alianských vojáků";
            CurrentQuest.CurrentProgress = 0;
            CurrentQuest.CompletedProgress = 5;

            Enemies = new List<EnemyStats>();
            Enemies.Add(new EnemyStats());
            Enemies.Add(new EnemyStats());
            Enemies.Add(new EnemyStats());
            Enemies.Add(new EnemyStats());
            Enemies.Add(new EnemyStats());
            Enemies[0].Positon = 1000;
            Enemies[1].Positon = 2000;
            Enemies[2].Positon = 3000;
            Enemies[3].Positon = 4000;
            Enemies[4].Positon = 5000;

            OpenWorld = new OpenWorld();
            Combat = new Combat();
            InventoryPage = new InventoryPage();
            QuestCompleted = new QuestCompleted();
            VendorPage = new VendorPage();
            GameOver = new GameOver();

            CurrentPage = OpenWorld;
            myFrame.Navigate(OpenWorld);

        }

        public static EnemyStats pickClosestEnemy()
        {
            EnemyStats closestEnemy = null;

            foreach (EnemyStats e in Enemies)
            {
                if (e.CurrentHealth > 0)
                {
                    if (closestEnemy != null)
                    {
                        if (Math.Abs(e.Positon - Stats.Position) < Math.Abs(closestEnemy.Positon - Stats.Position))
                        {
                            closestEnemy = e;
                        }
                    }
                    else
                    {
                        closestEnemy = e;
                    }
                }
            }

            return closestEnemy;
        }


    }
}
