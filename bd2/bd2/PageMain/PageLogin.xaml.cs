using bd2.Appdata;
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
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = AppConnect.modelOdb.user.FirstOrDefault(x => x.login == txbLogin.Text && x.password == psPassword.Password);
                if (userObj == null)
                {
                    MessageBox.Show("Такого пользователя нет!","Ошибка пользователя",MessageBoxButton.OK,MessageBoxImage.Error);
                }
                else
                {
                    switch (userObj.idrole) 
                    {
                        case 1: MessageBox.Show("Здравствуйте, администратор!" + userObj.name, "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information); ;
                            break;
                        case 2:
                            MessageBox.Show("Здравствуйте, ученик!" + userObj.name, "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information); ;
                            break;
                        default:
                            MessageBox.Show("Данные не обнаружены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning); ;
                            break;                         
                    }
                    if (userObj.idrole == 2)
                    {
                        AppFrame.frameMain.Navigate(new PageStudent());

                    }
                    if (userObj.idrole == 1)
                    {
                        AppFrame.frameMain.Navigate(new PageAdmin());

                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка"+ ex.Message.ToString()+"Критическая работа приложения", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageCreateAcc());
        }
    }
}
