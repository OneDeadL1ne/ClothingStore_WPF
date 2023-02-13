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
using static ClothingStore.ClassHelper.ValidationClass;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

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
            cb_Gender.DisplayMemberPath = "GenTitle";
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
            pbPasswordbox.Visibility = Visibility.Collapsed;
            tbVisiblePasswordbox.Text = pbPasswordbox.Password;
        }

        private void HidePassword()
        {

            ImgShowHide.Source = showImage;
            tbVisiblePasswordbox.Visibility = Visibility.Collapsed;
            pbPasswordbox.Visibility = Visibility.Visible;

            pbPasswordbox.Focus();
        }
        //Template="{StaticResource passwordbox}"
        private void tbPasswordbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (pbPasswordbox.Password.Length > 0)
            {
                pbPasswordbox.Foreground = Brushes.Black;
                tbVisiblePasswordbox.Foreground = Brushes.Black;

                ImgShowHide.Visibility = Visibility.Visible;

                ImgShowHide.Source = showImage;
                tbVisiblePasswordbox.Visibility = Visibility.Collapsed;
                pbPasswordbox.Visibility = Visibility.Visible;

                pbPasswordbox.Focus();
            }
            else
            {
                ImgShowHide.Visibility = Visibility.Collapsed;
            }
        }







        private void tbVisiblePasswordbox_GotFocus(object sender, RoutedEventArgs e)
        {

            tbVisiblePasswordbox.Visibility = Visibility.Collapsed;
            pbPasswordbox.Visibility = Visibility.Visible;
            pbPasswordbox.Focus();
        }



        private void tbPasswordbox_LostFocus(object sender, RoutedEventArgs e)
        {

            if (pbPasswordbox.Password == "")
            {
                tbVisiblePasswordbox.Visibility = Visibility.Visible;
                pbPasswordbox.Visibility = Visibility.Collapsed;
                tbVisiblePasswordbox.Text = "Введи пароль";
                tbVisiblePasswordbox.Foreground = Brushes.Gray;

            }


        }

        private void tbVisiblePasswordbox1_GotFocus(object sender, RoutedEventArgs e)
        {
            tbVisiblePasswordbox1.Visibility = Visibility.Collapsed;
            pbPasswordbox1.Visibility = Visibility.Visible;
            pbPasswordbox1.Focus();
        }

        private void tbPasswordbox1_LostFocus(object sender, RoutedEventArgs e)
        {

            if (pbPasswordbox1.Password == "")
            {
                tbVisiblePasswordbox1.Visibility = Visibility.Visible;
                pbPasswordbox1.Visibility = Visibility.Collapsed;
                tbVisiblePasswordbox1.Text = "Повтори пароль";
                tbVisiblePasswordbox1.Foreground = Brushes.Gray;

            }
        }

        private void tbPasswordbox1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (pbPasswordbox1.Password.Length > 0)
            {
                pbPasswordbox1.Foreground = Brushes.Black;
                tbVisiblePasswordbox1.Foreground = Brushes.Black;




                tbVisiblePasswordbox1.Visibility = Visibility.Collapsed;
                pbPasswordbox1.Visibility = Visibility.Visible;

                pbPasswordbox1.Focus();
            }

        }

        public void GotFocusText(object sender, RoutedEventArgs e)
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

            ClassHelper.NavigateClass.authorizationFrame.GoBack();
            ClassHelper.NavigateClass.authorizationFrame.RemoveBackEntry();
        }

        private void bt_Registration_Click(object sender, RoutedEventArgs e)
        {
            RefreshForm();
            ValidationForm();


        }

        public bool ValidationForm()
        {
            bool IsOkey = true;


            //Имя

            if (ValidationText(tbFirstName.Text) || tbFirstName.Text == "Имя")
            {
                tb_ER_FName.Visibility = Visibility.Visible;
                tbFirstName.BorderBrush = Brushes.Red;
                IsOkey = false;
            }


            //Фамилия

            if (ValidationText(tbLastName.Text) || tbLastName.Text == "Фамилия")
            {
                tb_ER_LName.Visibility = Visibility.Visible;
                tbLastName.BorderBrush = Brushes.Red;
                IsOkey = false;
            }

            //Отчество

            if (ValidationText(tbPatronymic.Text))
            {
                tb_ER_PName.Visibility = Visibility.Visible;
                tbPatronymic.BorderBrush = Brushes.Red;
                IsOkey = false;
            }

            //Телефон 

            if (ValidationPhone(tbPhone.Text) || (tbPhone.Text.Length<16 || tbPhone.Text.Length > 16))
            {
                tb_ER_Phone.Visibility = Visibility.Visible;
                tbPhone.BorderBrush = Brushes.Red;
                IsOkey = false;
            }
            else
            {
                tbPhone.Text = GetFormatedPhoneNumber(tbPhone.Text);
                tbPhone.SelectionStart = tbPhone.Text.Length;
            }

            //Email







            return IsOkey;
        }
        public void RefreshForm()
        {
            tb_ER_FName.Visibility = Visibility.Collapsed;
            tb_ER_LName.Visibility = Visibility.Collapsed;
            tb_ER_PName.Visibility = Visibility.Collapsed;
            tb_ER_Phone.Visibility = Visibility.Collapsed;
            tb_ER_Email.Visibility = Visibility.Collapsed;
            tb_ER_Password.Visibility = Visibility.Collapsed;
            tb_ER_PasswordRepeat.Visibility = Visibility.Collapsed;
            tb_ER_Bitrhday.Visibility = Visibility.Collapsed;
            tbFirstName.BorderBrush = Brushes.Black;
            tbLastName.BorderBrush = Brushes.Black;
            tbPhone.BorderBrush = Brushes.Black;
            tbEmail.BorderBrush = Brushes.Black;
            dpDate.BorderBrush = Brushes.Gray;
            pbPasswordbox.BorderBrush = Brushes.Black;
            tbPatronymic.BorderBrush = Brushes.Black;
        }


        private void tbPhone_TextChanged(object sender, TextChangedEventArgs e)
        {


            if (ValidateSymbols(tbPhone.Text))
            {
                tbPhone.Text = GetFormatedPhoneNumber(tbPhone.Text);
                tbPhone.SelectionStart = tbPhone.Text.Length;
            }

            if (tbPhone.Text.Contains("(("))
            {
                tbPhone.Clear();
                

            }




        }


    }


}

