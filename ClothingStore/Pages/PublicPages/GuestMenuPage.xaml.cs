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
using static ClothingStore.ClassHelper.NavigateClass;
using static ClothingStore.ClassHelper.MenuClass;
using ClothingStore.ClassHelper;

namespace ClothingStore.Pages.PublicPages
{
    /// <summary>
    /// Логика взаимодействия для GuestMenuPage.xaml
    /// </summary>
    public partial class GuestMenuPage : Page
    {
        public GuestMenuPage()
        {
            InitializeComponent();
            
            MenuClass.buttonLogin = btn_Login;
            MenuClass.buttonCatalog = btn_Catalog;
            MenuClass.buttonCart = btn_Cart;
            
        }

        private void bt_Login_Click(object sender, RoutedEventArgs e)
        {
            SetIsEnabledFalse();
            

            authorizationFrame.Visibility = Visibility.Visible;
            
            
        }

        private void bt_Catalog_Click(object sender, RoutedEventArgs e)
        {
            SetFocusButton(sender);
        }

        private void btn_Cart_Click(object sender, RoutedEventArgs e)
        {
            SetFocusButton(sender);
        }
    }
}
