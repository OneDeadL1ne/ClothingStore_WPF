using ClothingStore.ClassHelper;
using ClothingStore.DB;
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
using ClothingStore.DB;

namespace ClothingStore.Pages.PublicPages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
            MenuClass.buttonLogin = btn_Login;
            MenuClass.buttonCatalog = btn_Catalog;
            MenuClass.buttonCart = btn_Cart;
            MenuClass.buttonPersonalAccount = btn_PersonalAccount;
            buttonPersonalAccount.Visibility = Visibility.Collapsed;
        }
       
        public MenuPage(Customer customer)
        {
            InitializeComponent();

            MenuClass.buttonLogin = btn_Login;
            MenuClass.buttonCatalog = btn_Catalog;
            MenuClass.buttonCart = btn_Cart;
            MenuClass.buttonPersonalAccount = btn_PersonalAccount;
            buttonPersonalAccount.Visibility = Visibility.Visible;
            buttonLogin.Visibility = Visibility.Collapsed;


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

