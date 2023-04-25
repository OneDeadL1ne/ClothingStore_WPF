using ClothingStore.ClassHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using ClothingStore.Pages;
using static ClothingStore.ClassHelper.NavigateClass;
using static ClothingStore.ClassHelper.MenuClass;
using ClothingStore.Pages.EmployeesPages.DirectorPages;

namespace ClothingStore.Pages.PublicPages
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private bool _isListing = false;
        public AddEditPage()
        {
            InitializeComponent();
            //sp_AddEmployee.Visibility = Visibility.Collapsed;
            if (CurrentUser.CurrentDirector != null)
            {
                //sp_AddEmployee.Visibility = Visibility.Visible;
            }

            if (CurrentUser.CurrentManager != null)
            {
                //sp_AddEmployee.Visibility = Visibility.Collapsed;
            }
           
        }

        


         
          
        

     

        private void btn_Employee_Click(object sender, RoutedEventArgs e)
        {
            if (_isListing)
            {
                //NavigatePage(mainFrame, windowFrame, new ListEmployeePage());
                mainFrame.Navigate(new ListEmployeePage());
            }
            else
            {
                
            }
        }
    }
}
