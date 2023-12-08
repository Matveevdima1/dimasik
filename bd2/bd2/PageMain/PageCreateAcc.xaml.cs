using bd2.Appdata;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.Management.Smo;
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

namespace bd2.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageCreateAcc.xaml
    /// </summary>
    public partial class PageCreateAcc : Page
    {
        public PageCreateAcc()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (AppConnect.modelOdb.user.Count(x => x.login == txlog.Text)>0)
            {
                MessageBox.Show("Пользователь с таким логином есть","Уведомление",MessageBoxButton.OK,MessageBoxImage.Information);
                return;
            }
            try
            {
                
                user userObj =new user()
                {
                    login = txlog.Text,
                        name=tname.Text,
                        password=psbPas.Password,
                        idrole=2

                };
                AppConnect.modelOdb.user.Add(userObj);
                AppConnect.modelOdb.SaveChanges();
                MessageBox.Show("Данные успешно добавлены","Уведомление",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (psbPas.Password!=txbPas.Text)
            {
               btnCreate.IsEnabled = false;
                psbPas.Background =Brushes.LightCoral;
                psbPas.BorderBrush =Brushes.Red;
            }
            else
            {
                btnCreate.IsEnabled = true;
                psbPas.Background = Brushes.LightGreen;
                psbPas.BorderBrush = Brushes.Green;
            }
        }
    }
}
