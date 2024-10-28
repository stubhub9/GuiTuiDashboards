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





        #region  Bindings

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


        #endregion  end Bindings
    }
}