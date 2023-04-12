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
using static ClothingStore.ClassHelper.MenuClass;
using static ClothingStore.ClassHelper.ValidationClass;
using System.Text.RegularExpressions;
using ClothingStore.DB;
using System.Security.Policy;

namespace ClothingStore.Pages.PublicPages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        private string login;
        private string password;
        
        string email = null;
        string phone = null;
        public AuthorizationPage()
        {
            InitializeComponent();
            RefreshForm();
            
        }
        
        private void bt_Reg_Click(object sender, RoutedEventArgs e)
        {


            NavigatePage(authorizationFrame, windowFrame, new RegistrationPage());
            
        }

        private void bt_Enter_Click(object sender, RoutedEventArgs e)
        {
            login = tb_PhoneOrEmail.Text.Trim();
            password = tb_Passwordbox.Password.Trim();
            string PhoneOrEmail = GetPhoneOrEmail(login);
            RefreshForm();
           
           
            switch (PhoneOrEmail)
            {
                case "IsEmail":
                    email = login;
                    phone = null;
                    EnterAccount(login, password);
                    break;
                case "IsPhone":
                    phone = login;
                    email = null;
                    EnterAccount(login, password);
                    break;
                case "null":
                    tb_ER_Login.Visibility = Visibility.Visible;
                    tb_PhoneOrEmail.BorderBrush = Brushes.Red;
                    break;
            }

            if (password == null || tbVisiblePasswordbox.Text == "Введи пароль")
            {
                tb_ER_Pass.Visibility = Visibility.Visible;
                tb_Passwordbox.BorderBrush = Brushes.Red;
                tbVisiblePasswordbox.BorderBrush = Brushes.Red;

                return;
            }





            //EnterAccount();
        }

        public void RefreshForm()
        {
            if (tb_ER_Login == null) return;
            if (tb_ER_Pass == null) return;
            tb_ER_Login.Visibility = Visibility.Collapsed;
            tb_PhoneOrEmail.BorderBrush = Brushes.Black;
            tb_ER_Pass.Visibility = Visibility.Collapsed;
            tbVisiblePasswordbox.BorderBrush = Brushes.Black;
            tbVisiblePasswordbox.BorderBrush = Brushes.Black;
            tb_Passwordbox.BorderBrush= Brushes.Black;
        }

        public void EnterAccount(string login, string pass)
        {
            Employee employee = null;
            Customer customer = null;

            if (email != null && phone == null)
            {
                var IsCheckCustomers = Context.Customer.ToList().Where(i => i.Email == email && i.Password == password).FirstOrDefault();
                if (IsCheckCustomers != null)
                {
                    customer = IsCheckCustomers;
                    employee = null;

                    menuFrame.Navigate(new MenuPage(customer));
                    SetIsEnabledTrue(mainFrame.Content.GetType().Name);
                    authorizationFrame.Visibility = Visibility.Collapsed;

                    return;
                }

                var IsCheckEmployee = Context.Employee.ToList().Where(i => i.Email == email && i.Password == password).FirstOrDefault();
                if (IsCheckEmployee != null)
                {
                    employee = IsCheckEmployee;
                    customer = null;
                    return;
                }
            }

            if (phone != null && email == null)
            {


                var IsCheckCustomers = Context.Customer.ToList().Where(i => i.Phone == phone && i.Password == password).FirstOrDefault();
                if (IsCheckCustomers != null)
                {
                    customer = IsCheckCustomers;
                    employee = null;
                    menuFrame.Navigate(new MenuPage(customer));
                    SetIsEnabledTrue(mainFrame.Content.GetType().Name);
                    authorizationFrame.Visibility = Visibility.Collapsed;

                    return;
                }


                var IsCheckEmployee = Context.Employee.ToList().Where(i => i.Phone == phone && i.Password == password).FirstOrDefault();
                if (IsCheckEmployee != null)
                {
                    employee = IsCheckEmployee;
                    customer = null;


                    return;
                }
            }

        }

        private void Tb_PhoneOrEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void bt_Close_Click(object sender, RoutedEventArgs e)
        {
            authorizationFrame.Visibility = Visibility.Collapsed;
            SetIsEnabledTrue(mainFrame.Content.GetType().Name);
            tb_Passwordbox.Clear();
            tb_PhoneOrEmail.Clear();
            tb_Passwordbox_LostFocus(tb_Passwordbox,e);
            tb_PhoneOrEmail_LostFocus(tb_PhoneOrEmail,e);
           
            
        }

        private string GetPhoneOrEmail(string login)
        {
            string conde = @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)";
            
            //"^\\+?\\d{1,1}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$"
            
            if (Regex.IsMatch(login, "(\\+7|8)[\\s(]*\\d{3}[)\\s]*\\d{3}[\\s-]?\\d{2}[\\s-]?\\d{2}"))
            {
                if (login[0] != '+' || login.Length > 16)
                {
                    return "null";
                }
                else
                {
                    return "IsPhone";
                }
            }
         
            

            if (Regex.IsMatch(login, conde))
            {
                return "IsEmail";
            }
            return "null";
            

        }

       
        private void tb_PhoneOrEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshForm();



            string login = tb_PhoneOrEmail.Text.Trim();
            string answer = GetPhoneOrEmail(login);
            string phone = "";
            

            
            GetFormatedPhoneNumber(login);

            phone = GetFormatedPhoneNumber(login);
           
            if (answer == "IsPhone")
            {
               
                    tb_PhoneOrEmail.Text = phone;
                    tb_PhoneOrEmail.SelectionStart = phone.Length;

               
            }
            
        }


        

        private void tbVisiblePasswordbox_GotFocus(object sender, RoutedEventArgs e)
        {
            tbVisiblePasswordbox.Visibility = Visibility.Collapsed;
            tb_Passwordbox.Visibility = Visibility.Visible;
            tb_Passwordbox.Focus();
        }

        private void tb_Passwordbox_LostFocus(object sender, RoutedEventArgs e)
        {

            if (tb_Passwordbox.Password == "")
            {
                tbVisiblePasswordbox.Visibility = Visibility.Visible;
                tb_Passwordbox.Visibility = Visibility.Collapsed;
                tbVisiblePasswordbox.Text = "Введи пароль";
                tbVisiblePasswordbox.Foreground = Brushes.Gray;

            }

        }

        private void tb_PhoneOrEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tb_PhoneOrEmail.Text=="")
            {
                tb_PhoneOrEmail.Text = "Введи почту/телефон";
                tb_PhoneOrEmail.Foreground = Brushes.Gray;
            }
           
        }

        private void tb_PhoneOrEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tb_PhoneOrEmail.Text== "Введи почту/телефон")
            {
                tb_PhoneOrEmail.Text = "";
                tb_PhoneOrEmail.Foreground = Brushes.Black;

            }
           
        }

        private void tb_Passwordbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            RefreshForm();
            
        }

        private void tbVisiblePasswordbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshForm();
        }
    }
}
