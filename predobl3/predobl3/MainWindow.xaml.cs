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

namespace predobl3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string gor;
            string adres;
            double metr;
            int price1;
            gor = gorod.Text;
            adres=adr.Text;
            double.TryParse(met.Text, out metr);
            int.TryParse(price.Text, out price1);
            string[] row = { gor, adres, metr.ToString(), price1.ToString()};
            List1.Items.Add(row);
        }

        private void gorod_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            gorod.Clear();
        }

        private void adr_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            adr.Clear();
        }

        private void met_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            met.Clear();
        }

        private void price_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            price.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TabControl1.SelectedItem= TabControl1.Items[1];
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            TabControl1.SelectedItem = TabControl1.Items[0];
        }
    }
}
