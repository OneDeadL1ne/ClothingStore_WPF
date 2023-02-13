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
using ClothingStore.Pages.PublicPages;
using ClothingStore.DB;

namespace ClothingStore.Pages.ClientPages
{
    /// <summary>
    /// Логика взаимодействия для PersonalAccountPage.xaml
    /// </summary>
    public partial class PersonalAccountPage : Page
    {
        private Employee employee=null;
        private Customer customer=null;
        public PersonalAccountPage()
        {
            InitializeComponent();
        }
        public PersonalAccountPage(Customer customerpage)
        {

            InitializeComponent();
            this.customer = customerpage;
            tb_FName.Text = customer.FName;
            tb_Patronymic.Text = customer.Patronymic;
            tb_Phone.Text = customer.Phone;
            tb_LName.Text = customer.LName;
        }
        public PersonalAccountPage(Employee employeepage)
        {
            InitializeComponent();
            this.employee = employeepage;
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            //windowFrame.RemoveBackEntry();
            //menuFrame.Navigate(new MenuPage());
            //mainFrame.Navigate(new CatalogePage());
            //authorizationFrame.NavigationService.Refresh();
            //authorizationFrame.Navigate(new AuthorizationPage());

            if (!windowFrame.CanGoBack && !windowFrame.CanGoForward)
            {
                return;
            }

            var entry = windowFrame.RemoveBackEntry();
            while (entry != null)
            {
                entry = windowFrame.RemoveBackEntry();
            }

            windowFrame.Navigate(new HomePage());
        }
    }
}
