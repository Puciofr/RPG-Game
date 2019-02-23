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
using WpfAnimatedGif;

namespace RPG_Game.pages
{
    /// <summary>
    /// Interakční logika pro OpenWorld.xaml
    /// </summary>
    public partial class OpenWorld : Page
    {
        public List<int> stop_at = new List<int>();
        private enum State : int { standing_right, standing_left, going_right, going_left };
        private State state;
        private System.Windows.Threading.DispatcherTimer dispatcherTimer;
        public OpenWorld()
        {
            InitializeComponent();

            this.Cursor = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../../../resources/wow.cur");

            state = State.standing_right;

            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = TimeSpan.FromSeconds(0.025);
            dispatcherTimer.Start();
        }

        private void window_KeyDown(object sender, KeyEventArgs e)
        {
            dispatcherTimer.Start();
            var controller = ImageBehavior.GetAnimationController(character);

            if (e.Key == Key.A && state != State.going_left)
            {
                state = State.going_left;

                character.Visibility = Visibility.Visible;
                character_standing.Visibility = Visibility.Hidden;

                controller.Play();

                TransformGroup transformGroup = (TransformGroup)character.RenderTransform;
                ScaleTransform scaleTransform = (ScaleTransform)transformGroup.Children[0];
                TranslateTransform translateTransform = (TranslateTransform)transformGroup.Children[3];
                scaleTransform.ScaleX = -1;
                translateTransform.X = 200;
            }
            if (e.Key == Key.D && state != State.going_right)
            {
                state = State.going_right;

                character.Visibility = Visibility.Visible;
                character_standing.Visibility = Visibility.Hidden;

                controller.Play();

                TransformGroup transformGroup = (TransformGroup)character.RenderTransform;
                ScaleTransform scaleTransform = (ScaleTransform)transformGroup.Children[0];
                TranslateTransform translateTransform = (TranslateTransform)transformGroup.Children[3];
                scaleTransform.ScaleX = 1;
                translateTransform.X = 0;

            }

        }

        private void window_KeyUp(object sender, KeyEventArgs e)
        {
            var controller = ImageBehavior.GetAnimationController(character);

            if (e.Key == Key.A || e.Key == Key.D)
            {
                controller.Pause();
            }
            if (e.Key == Key.A)
            {
                state = State.standing_left;

                character.Visibility = Visibility.Hidden;
                character_standing.Visibility = Visibility.Visible;

                TransformGroup transformGroup = (TransformGroup)character_standing.RenderTransform;
                ScaleTransform scaleTransform = (ScaleTransform)transformGroup.Children[0];
                TranslateTransform translateTransform = (TranslateTransform)transformGroup.Children[3];
                scaleTransform.ScaleX = -1;
                translateTransform.X = 200;
            }
            else if (e.Key == Key.D)
            {
                state = State.standing_right;

                character.Visibility = Visibility.Hidden;
                character_standing.Visibility = Visibility.Visible;

                TransformGroup transformGroup = (TransformGroup)character_standing.RenderTransform;
                ScaleTransform scaleTransform = (ScaleTransform)transformGroup.Children[0];
                TranslateTransform translateTransform = (TranslateTransform)transformGroup.Children[3];
                scaleTransform.ScaleX = 1;
                translateTransform.X = 0;
            }

        }

        private void ControllerCurrentFrameChanged(object sender, EventArgs e)
        {
            var controller = ImageBehavior.GetAnimationController(character);
            if (controller != null)
            {
                var position = controller.CurrentFrame;
                if (stop_at.Contains(position))
                {
                    controller.Pause();
                }
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (state == State.going_right)
            {
                TransformGroup transformGroup = (TransformGroup)pavement.RenderTransform;
                TransformGroup transformGroup2 = (TransformGroup)pavement2.RenderTransform;
                TransformGroup transformGroup3 = (TransformGroup)background.RenderTransform;
                TransformGroup transformGroup4 = (TransformGroup)background2.RenderTransform;
                TransformGroup transformGroup5 = (TransformGroup)enemy.RenderTransform;
                TranslateTransform translateTransform = (TranslateTransform)transformGroup.Children[3];
                TranslateTransform translateTransform2 = (TranslateTransform)transformGroup2.Children[3];
                TranslateTransform translateTransform3 = (TranslateTransform)transformGroup3.Children[3];
                TranslateTransform translateTransform4 = (TranslateTransform)transformGroup4.Children[3];
                TranslateTransform translateTransform5 = (TranslateTransform)transformGroup5.Children[3];
                translateTransform.X += -10;
                translateTransform2.X += -10;
                translateTransform3.X += -2;
                translateTransform4.X += -2;
                translateTransform5.X += -10;

                if (translateTransform5.X == -1270)
                {
                    MainWindow.frame.Navigate(new Combat());
                }

                if (translateTransform.X <= -800)
                {
                    translateTransform.X = 800;
                }
                if (translateTransform2.X <= -1600)
                {
                    translateTransform2.X = 0;
                }

                if (translateTransform3.X <= -1600)
                {
                    translateTransform3.X = 1600;
                }
                if (translateTransform4.X <= -1600)
                {
                    translateTransform4.X = 1600;
                }


            }
            if (state == State.going_left)
            {
                TransformGroup transformGroup = (TransformGroup)pavement.RenderTransform;
                TransformGroup transformGroup2 = (TransformGroup)pavement2.RenderTransform;
                TransformGroup transformGroup3 = (TransformGroup)background.RenderTransform;
                TransformGroup transformGroup4 = (TransformGroup)background2.RenderTransform;
                TransformGroup transformGroup5 = (TransformGroup)enemy.RenderTransform;
                TranslateTransform translateTransform = (TranslateTransform)transformGroup.Children[3];
                TranslateTransform translateTransform2 = (TranslateTransform)transformGroup2.Children[3];
                TranslateTransform translateTransform3 = (TranslateTransform)transformGroup3.Children[3];
                TranslateTransform translateTransform4 = (TranslateTransform)transformGroup4.Children[3];
                TranslateTransform translateTransform5 = (TranslateTransform)transformGroup5.Children[3];
                translateTransform.X += 10;
                translateTransform2.X += 10;
                translateTransform3.X += 2;
                translateTransform4.X += 2;
                translateTransform5.X += 10;

                if (translateTransform.X >= 800)
                {
                    translateTransform.X = -800;
                }
                if (translateTransform2.X >= 0)
                {
                    translateTransform2.X = -1600;
                }

                if (translateTransform3.X >= 1600)
                {
                    translateTransform3.X = -1600;
                }
                if (translateTransform4.X >= 1600)
                {
                    translateTransform4.X = -1600;
                }


            }

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.KeyDown += window_KeyDown;
            window.KeyUp += window_KeyUp;
        }



    }
}
