using ClothingStore.Pages.PublicPages;
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
using System.Windows.Shapes;

namespace ClothingStore.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ClassHelper.NavigateClass.authorizationFrame = AuthorizationFrame;
            
            AuthorizationFrame.Navigate(new AuthorizationPage());
            ClassHelper.NavigateClass.authorizationFrame.Visibility= Visibility.Collapsed;
            windowFrame.Navigate(new HomePage());
        }
    }
}
