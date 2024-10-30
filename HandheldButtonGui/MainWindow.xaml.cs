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
                INotifyPropertyChanged ( () => BannerBrush1 );
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

        private void INotifyPropertyChanged ( Func<Brush> value )
        {
            throw new NotImplementedException ();
        }



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
            throw new NotImplementedException ();
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