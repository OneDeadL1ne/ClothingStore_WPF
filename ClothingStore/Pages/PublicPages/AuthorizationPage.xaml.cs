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
using System.Text.RegularExpressions;
using ClothingStore.DB;

namespace ClothingStore.Pages.PublicPages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        char[] char1 = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '.', ',', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', ';', ':', '+' };
        char[] char2 = Enumerable.Range('а', 'я' - 'а' + 1).Select(c => (char)c).ToArray();
        char[] char5 = Enumerable.Range('А', 'Я' - 'А' + 1).Select(c => (char)c).ToArray();
        char[] char3 = Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char)c).ToArray();
        char[] char4 = Enumerable.Range('A', 'Z' - 'A' + 1).Select(c => (char)c).ToArray();
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void bt_Reg_Click(object sender, RoutedEventArgs e)
        {
           

            authorizationFrame.Navigate(new RegistrationPage());

            //authorizationFrame.Visibility = Visibility.Collapsed;
            //SetIsEnabledTrue();
            //tb_Login.Text = "";
            //tb_Passwordbox.Password = "";


        }

        private void bt_Enter_Click(object sender, RoutedEventArgs e)
        {
            
           

            
            Employee employee = null;
            Customer customer = null;
            string login = tb_PhoneOrEmail.Text.Trim();
            string PhoneOrEmail;
            string email = null;
            string phone = null;

            if (login[0]=='+')
            {
                string pattern = @"\D";
                string target = "";
                Regex regex = new Regex(pattern);
                string result = regex.Replace(login, target);
                PhoneOrEmail = GetPhoneOrEmail(result);
            }
            else
            {
                PhoneOrEmail = GetPhoneOrEmail(login);
            }




            //MessageBox.Show($"{PhoneOrEmail}");

            switch (PhoneOrEmail)
            {
                case "IsEmail":
                    email = tb_PhoneOrEmail.Text;
                    phone = null;
                    break;
                case "IsPhone":
                    phone= tb_PhoneOrEmail.Text;
                    email = null;
                    break;
                case "null":
                    
                    break;
            }

            if (email!=null && phone==null)
            {
                var IsCheckCustomers = Context.Customer.ToList().Where(i => i.Email == email && i.Password == tb_Passwordbox.Password).FirstOrDefault();
                if (IsCheckCustomers!=null)
                {
                    customer = IsCheckCustomers;
                    employee = null;
                   
                    menuFrame.Navigate(new MenuPage(customer));
                    authorizationFrame.Visibility = Visibility.Collapsed;
                    return;
                }

                var IsCheckEmployee = Context.Employee.ToList().Where(i => i.Email==email && i.Password==tb_Passwordbox.Password).FirstOrDefault();
                if (IsCheckEmployee!=null)
                {
                    employee= IsCheckEmployee;
                    customer = null;
                    return;
                }
            }

            if (phone!=null && email==null)
            {
               

                var IsCheckCustomers = Context.Customer.ToList().Where(i => i.Phone == phone && i.Password == tb_Passwordbox.Password).FirstOrDefault();
                if (IsCheckCustomers != null)
                {
                    customer = IsCheckCustomers;
                    employee = null;
                    menuFrame.Navigate (new MenuPage(customer));
                    authorizationFrame.Visibility = Visibility.Collapsed;
                    return;
                }
             

                var IsCheckEmployee = Context.Employee.ToList().Where(i => i.Phone == phone && i.Password == tb_Passwordbox.Password).FirstOrDefault();
                if (IsCheckEmployee != null)
                {
                    employee = IsCheckEmployee;
                    customer= null;


                    return;
                }
            }

            






        }

        private void bt_Close_Click(object sender, RoutedEventArgs e)
        {
            authorizationFrame.Visibility = Visibility.Collapsed;
            SetIsEnabledTrue();
            tb_Passwordbox.Clear();
            tb_PhoneOrEmail.Clear();
            tb_Passwordbox_LostFocus(tb_Passwordbox,e);
            tb_PhoneOrEmail_LostFocus(tb_PhoneOrEmail,e);
           
            
        }

        private string GetPhoneOrEmail(string login)
        {
            string conde = @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)";
            
       
            if (Regex.IsMatch(login, @"^\d+$")) 
            {

                return "IsPhone";
            }

            if (Regex.IsMatch(login, conde))
            {
                return "IsEmail";
            }
            return "null";
            

        }
        public string GetFormattedPhoneNumber(string phone)
        {
            if (phone != null && phone.Trim().Length == 11)

                return string.Format("+{0}({1}){2}-{3}-{4}",phone.Substring(0,1), phone.Substring(1, 3), phone.Substring(4, 3), phone.Substring(7, 2), phone.Substring(9,2));
            return phone;
        }

        private void tb_PhoneOrEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            string login = tb_PhoneOrEmail.Text.Trim();
            string answer = GetPhoneOrEmail(login);
            string phone = "";



            switch (answer) 
            {
                case "IsPhone":

                    phone = GetFormattedPhoneNumber(login);
                    tb_PhoneOrEmail.Text = phone;

                    
                    break;

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
    }
}
