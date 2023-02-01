using ClothingStore.DB;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static ClothingStore.ClassHelper.EFClass;
using static System.Net.Mime.MediaTypeNames;


namespace ClothingStore.Pages.PublicPages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
            cb_Gender.ItemsSource = Context.Gender.ToList();
            cb_Gender.DisplayMemberPath = "Title";
            cb_Gender.SelectedIndex = 0;
        }

        private void bt_Authorization_Click(object sender, RoutedEventArgs e)
        {
            ClassHelper.NavigateClass.authorizationFrame.Navigate(new AuthorizationPage());
            ClassHelper.NavigateClass.authorizationFrame.Visibility = Visibility.Collapsed;
        }

        private readonly BitmapImage showImage = new BitmapImage(
            new Uri(@"\Res\Images\Show.jpg", UriKind.RelativeOrAbsolute));
        private readonly BitmapImage hideImage = new BitmapImage(
            new Uri(@"\Res\Images\Hide.jpg", UriKind.RelativeOrAbsolute));




        private void OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowPassword();
        }

        private void OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            HidePassword();
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            HidePassword();
        }

        private void ShowPassword()
        {
            ImgShowHide.Source = hideImage;
            tbVisiblePasswordbox.Visibility = Visibility.Visible;
            tbPasswordbox.Visibility = Visibility.Collapsed;
            tbVisiblePasswordbox.Text = tbPasswordbox.Password;
        }

        private void HidePassword()
        {

            ImgShowHide.Source = showImage;
            tbVisiblePasswordbox.Visibility = Visibility.Collapsed;
            tbPasswordbox.Visibility = Visibility.Visible;

            tbPasswordbox.Focus();
        }
        //Template="{StaticResource passwordbox}"
        private void tbPasswordbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (tbPasswordbox.Password.Length > 0)
            {
                tbPasswordbox.Foreground = Brushes.Black;
                tbVisiblePasswordbox.Foreground= Brushes.Black;
                
                ImgShowHide.Visibility = Visibility.Visible;

                ImgShowHide.Source = showImage;
                tbVisiblePasswordbox.Visibility = Visibility.Collapsed;
                tbPasswordbox.Visibility = Visibility.Visible;

                tbPasswordbox.Focus();
            }
            else
            {
                ImgShowHide.Visibility = Visibility.Collapsed;
            }
        }

       

        

        

        private void tbVisiblePasswordbox_GotFocus(object sender, RoutedEventArgs e)
        {
            
            tbVisiblePasswordbox.Visibility = Visibility.Collapsed;
            tbPasswordbox.Visibility = Visibility.Visible;
            tbPasswordbox.Focus();
        }

     

        private void tbPasswordbox_LostFocus(object sender, RoutedEventArgs e)
        {
            
            if (tbPasswordbox.Password == "")
            {
                tbVisiblePasswordbox.Visibility = Visibility.Visible;
                tbPasswordbox.Visibility = Visibility.Collapsed;
                tbVisiblePasswordbox.Text = "Введи пароль";
                tbVisiblePasswordbox.Foreground = Brushes.Gray;

            }  
             
            
        }

        private void tbVisiblePasswordbox1_GotFocus(object sender, RoutedEventArgs e)
        {
            tbVisiblePasswordbox1.Visibility = Visibility.Collapsed;
            tbPasswordbox1.Visibility = Visibility.Visible;
            tbPasswordbox1.Focus();
        }

        private void tbPasswordbox1_LostFocus(object sender, RoutedEventArgs e)
        {
            
            if (tbPasswordbox1.Password == "")
            {
                tbVisiblePasswordbox1.Visibility = Visibility.Visible;
                tbPasswordbox1.Visibility = Visibility.Collapsed;
                tbVisiblePasswordbox1.Text = "Повтори пароль";
                tbVisiblePasswordbox1.Foreground = Brushes.Gray;

            }
        }

        private void tbPasswordbox1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (tbPasswordbox1.Password.Length > 0)
            {
                tbPasswordbox1.Foreground = Brushes.Black;
                tbVisiblePasswordbox1.Foreground = Brushes.Black;

               

                
                tbVisiblePasswordbox1.Visibility = Visibility.Collapsed;
                tbPasswordbox1.Visibility = Visibility.Visible;

                tbPasswordbox1.Focus();
            }
            
        }

        public void GotFocusText(object sender, RoutedEventArgs e)
        {

            string str="";
            
            TextBox textBox = (TextBox)sender;
            

            switch (textBox.Name)
            {
                case "tbFirstName":
                    str = "Имя";
                    break;
                case "tbLastName":
                    str = "Фамилия";
                    break;
                case "tbPatronymic":
                    str = "Отчество";
                    break;
                case "tbPhone":
                    str = "Телефон";
                    break;
                case "tbEmail":
                    str = "Email";
                    break;
                case "tbLogin":
                    str = "Логин";
                    break;

                default:
                    break;
            }

            if (textBox.Text == str)
            {
                textBox.Text = "";
                textBox.Focus();
                textBox.Foreground = Brushes.Black;
            }

        }

        public void LostFocusText(object sender, RoutedEventArgs e)
        {

            string str = "";

            TextBox textBox = (TextBox)sender;


            switch (textBox.Name)
            {
                case "tbFirstName":
                    str = "Имя";
                    break;
                case "tbLastName":
                    str = "Фамилия";
                    break;
                case "tbPatronymic":
                    str = "Отчество";
                    break;
                case "tbPhone":
                    str = "Телефон";
                    break;
                case "tbEmail":
                    str = "Email";
                    break;
                case "tbLogin":
                    str = "Логин";
                    break;

                default:
                    break;
            }

            if (textBox.Text == "")
            {
                textBox.Text = str;
                
                textBox.Foreground = Brushes.Gray;
            }

        }

        private void bt_Back_Click(object sender, RoutedEventArgs e)
        {
            ClassHelper.NavigateClass.authorizationFrame.Navigate(new AuthorizationPage());
        }
    }


}

