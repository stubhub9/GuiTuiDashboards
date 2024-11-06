using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
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

namespace HandheldButtonGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region  Fields and Properties
        private bool _isSpinning = false;

        //  Project Flag
        private bool _IsEnergized = false;
        private Brush brush_LampOn = Brushes.Yellow;


        //TODO:  Banner, Color schemes, and what belongs in properties?  
        private Brush _bannerBrush1 = Brushes.Cyan;
        public Brush BannerBrush1
        {
            get
            {
                return _bannerBrush1;
            }
            set
            {
                _bannerBrush1 = value;
                //INotifyPropertyChanged ( () => BannerBrush1 );
            }
        }





        #endregion  end of Fields and Properties



        #region  Constructor
        public MainWindow ()
        {
            InitializeComponent ();
        }

        #endregion  end of Constructor





        #region  Bindings and Events


        private void btnSpinner_MouseEnter ( object sender, MouseEventArgs e)
        {
            if ( !_isSpinning )
            {
                _isSpinning = true;
                //  Make a double animation obj,
                //  register with Completed
                var dblAnim = new DoubleAnimation ();
                dblAnim.Completed += ( o, s ) => { _isSpinning = false; };

                //  Set the start value and end value.
                dblAnim.From = 0;
                dblAnim.To = 360;
                dblAnim.Duration = new Duration ( TimeSpan.FromSeconds ( 4 ) );
                dblAnim.RepeatBehavior = RepeatBehavior.Forever;


                //  Create a RotateTransform obj, set to button transform
                var rt = new RotateTransform ();
                fingerButton.RenderTransform = rt;


                //  Animate the object.
                rt.BeginAnimation ( RotateTransform.AngleProperty, dblAnim );

            }
        }



        private void fingerButton_OnClick ( object sender, RoutedEventArgs e )
        {
            var dblAnim = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                //DEFAULT:  1 Second Interval
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior (TimeSpan.FromSeconds (10)),
            };
            fingerButton.BeginAnimation ( Button.OpacityProperty, dblAnim );

        }




        //public class ColorToBrushConverter1 : IValueConverter
        //{
        //    public object Convert ( object value, Type targetType, object parameter, CultureInfo culture )
        //    {
        //        return new SolidColorBrush((Color)value);
        //    }

        //    public object ConvertBack ( object value, Type targetType, object parameter, CultureInfo culture )
        //    {
        //        //return (value as SolidColorBrush).Color;
        //        return SolidColorBrush.Red;
        //    }
        //}

        //private void INotifyPropertyChanged ( Func<Brush> value )
        //{
        //    throw new NotImplementedException ();
        //}



        private void fingerButton_Click ( object sender, RoutedEventArgs e )
        {
            /* 
             * Begin animation dropping the finger and switch to the lower position.
             * 
             *      
             *  The switch leg will be ENERGIZED anytime the switch is closed; 
             *      FROM the END of the Switch Closing animation,
             *      UNTIL the START of the Switch Opening animation.
             *  
             *  When ENERGIZED, the Motor will spin and the Light will shine.
             */


            //  Toggle the finger final position; using animation.


            //var button1 = dpstButton;

            if (!_IsEnergized)
            {
                CloseSwitch ();
                //  Complete the Closing the Switch animation.

                //  THEN
                //  Start spinning the motor.
                //  Change Lamp to Light color.
            }
            else
            {
                //  Begin Animate fingerButton and toggle switch to open position.
                //  AND
                //  Stop spinning the motor.
                //  Change Lamp to Dark color.
            }


        }







        #endregion   Bindings and Events



        #region     Methods


        private void CloseSwitch ()
        {
            NameScope.SetNameScope ( this, new NameScope () );

            ThicknessAnimation closeSwitchAnimation = new ThicknessAnimation ()
            {
                Duration = TimeSpan.FromSeconds ( 1.5 ),
                FillBehavior = FillBehavior.HoldEnd
            };






            //var dblAnimClose = new DoubleAnimation ()
            //{
            //    From = 10.0,
            //    To = 18.0,
            //    Duration = new Duration(TimeSpan.FromSeconds(1.5)),
            //    //  Leave autoreverse and repeatbehavior as default false
            //};



            //dpstButton.
            ////var switch = dpstButton;
            ////  <Button x:Name="dpstButton"
            //Storyboard storyboardCloseSwitch = new Storyboard ();
            //storyboardCloseSwitch.Children.Add ( dblAnimClose );
            //Storyboard.SetTargetName (dblAnimClose, dpstButton.Name);
            ////Storyboard.SetTargetProperty ( dblAnimClose, new PropertyPath ( Button.MarginProperty ) );


            //            < Storyboard >
            //     < ThicknessAnimationUsingKeyFrames Storyboard.TargetProperty = "Margin" BeginTime = "00:00:00" >
            //        < SplineThicknessKeyFrame KeyTime = "00:00:00" Value = "134, 70,0,0" />
            //        < SplineThicknessKeyFrame KeyTime = "00:00:03" Value = "50, 70,0,0" />
            //     </ ThicknessAnimationUsingKeyFrames >
            //</ Storyboard >


            /*
Actually, ya you can do what you want to do, exactly as you want to do using RenderTransform mixed with some DoubleAnimation and even add some extra flair to it, for example;

< Grid x:Name = "TheObject" Opacity = "0" >
    < Grid.RenderTransform >
        < TranslateTransform x:Name = "MoveMeBaby" X = "50" />
    </ Grid.RenderTransform >
    < Grid.Triggers >
        < EventTrigger RoutedEvent = "Grid.Loaded" >
            < BeginStoryboard >
                < Storyboard >
                    < DoubleAnimationUsingKeyFrames Storyboard.TargetName = "MoveMeBaby"
                                                   Storyboard.TargetProperty = "X" >
                        < SplineDoubleKeyFrame KeyTime = "0:0:1.25" Value = "0" />
                    </ DoubleAnimationUsingKeyFrames >
                    < DoubleAnimationUsingKeyFrames Storyboard.TargetName = "TheObject"
                                                   Storyboard.TargetProperty = "Opacity" >
                        < SplineDoubleKeyFrame KeyTime = "0:0:1.55" Value = "1" />
                    </ DoubleAnimationUsingKeyFrames >
                </ Storyboard >
            </ BeginStoryboard >
        </ EventTrigger >
    </ Grid.Triggers >
</ Grid >

            */




        }



        private void ToggleEnergized ()
        {
            //  ToggleEnergized should occur when:
            // the switch enters or leaves the closed position.
            ToggleEnergized_Light ();
            ToggleEnergized_Motor ();

        }

        private void ToggleEnergized_Motor ()
        {
            throw new NotImplementedException ();
        }

        private void ToggleEnergized_Light ()
        {
            throw new NotImplementedException ();
        }



        #endregion  Methods

    }
}