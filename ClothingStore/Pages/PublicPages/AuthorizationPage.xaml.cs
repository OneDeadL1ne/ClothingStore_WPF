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
using ClothingStore.ClassHelper;
using static ClothingStore.ClassHelper.EFClass;
using static ClothingStore.ClassHelper.NavigateClass;


namespace ClothingStore.Pages.PublicPages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void bt_Reg_Click(object sender, RoutedEventArgs e)
        {
           

            authorizationFrame.Navigate(new RegistrationPage());




        }

        private void bt_Enter_Click(object sender, RoutedEventArgs e)
        {
            var Connection = Context.User.ToList().Where(i => i.Login == tb_Login.Text && i.Password == pb_Password.Password).FirstOrDefault();

            if (Connection != null)
            {
                authorizationFrame.Visibility = Visibility.Collapsed;
            }
        }
    }
}
