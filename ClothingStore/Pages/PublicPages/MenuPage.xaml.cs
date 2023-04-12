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
using ClothingStore.DB;
using ClothingStore.Pages;
using ClothingStore.Pages.ClientPages;

namespace ClothingStore.Pages.PublicPages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        private Employee employee = null; 
        private Customer customer=null;
        public MenuPage()
        {
            InitializeComponent();
            MenuClass.buttonLogin = btn_Login;
            MenuClass.buttonCatalog = btn_Catalog;
            MenuClass.buttonCart = btn_Cart;
            MenuClass.buttonPersonalAccount = btn_PersonalAccount;
            buttonPersonalAccount.Visibility = Visibility.Collapsed;
        }
       
        public MenuPage(Customer customerpage)
        {
            InitializeComponent();
            this.customer = customerpage;
            this.employee = null;
            MenuClass.buttonLogin = btn_Login;
            MenuClass.buttonCatalog = btn_Catalog;
            MenuClass.buttonCart = btn_Cart;
            MenuClass.buttonPersonalAccount = btn_PersonalAccount;
            buttonPersonalAccount.Visibility = Visibility.Visible;
            buttonLogin.Visibility = Visibility.Collapsed;


        }
        public MenuPage(Employee employeepage)
        {
            InitializeComponent();
            this.employee =  employeepage;
            this.customer = null;
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

            //authorizationFrame.Navigate(new AuthorizationPage());
            NavigatePage(authorizationFrame, windowFrame, new AuthorizationPage());
            authorizationFrame.Visibility = Visibility.Visible;


        }

        private void bt_Catalog_Click(object sender, RoutedEventArgs e)
        {
            SetFocusButton(sender);
            //if (!windowFrame.CanGoBack && !windowFrame.CanGoForward)
            //{

            //    mainFrame.Navigate(new CatalogePage());
            //    return;

            //}
            //var entry = windowFrame.RemoveBackEntry();
            //while (entry != null)
            //{
            //    entry = windowFrame.RemoveBackEntry();
            //}

            NavigatePage(mainFrame, windowFrame, new CatalogePage());
            //mainFrame.Navigate(new CatalogePage()); 

        }

        private void btn_Cart_Click(object sender, RoutedEventArgs e)
        {
            SetFocusButton(sender);
            //MessageBox.Show($"{mainFrame.Content.GetType().Name}");

            
            
            NavigatePage(mainFrame, windowFrame, new CartPage());
            //mainFrame.Navigate(new CartPage());
        }

        private void btn_PersonalAccount_Click(object sender, RoutedEventArgs e)
        {
            SetFocusButton(sender);
            if (employee==null && customer !=null)
            {
                NavigatePage(mainFrame, windowFrame, new PersonalAccountPage(customer));
            }
            else
            {
                NavigatePage(mainFrame, windowFrame, new PersonalAccountPage(employee));
            }
            //mainFrame.Navigate(new PersonalAccountPage());




        }
         

        
    }
}

