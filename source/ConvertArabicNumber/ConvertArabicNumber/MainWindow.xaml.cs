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

namespace ConvertArabicNumber
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //MessageBox.Show(Convert.tafqeet("500"));

        }

        private void convert_Click(object sender, RoutedEventArgs e)
        {
            result.Text = Convert.ConvertToArabic(number.Text);
        }

        private void checkDouble(object sender, TextCompositionEventArgs e)
        {
            string str = ((TextBox)sender).Text;
            //bool vcond = (e.Text == "," || e.Text == ".") && (!str.Contains(",") && !str.Contains("."));
            bool vcond = e.Text == "," && !str.Contains(",");
            e.Handled = !(Function.isInt(e.Text) || vcond);
        }


    }
}
