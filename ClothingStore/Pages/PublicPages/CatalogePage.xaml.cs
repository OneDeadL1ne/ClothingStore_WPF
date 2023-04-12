using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
using static ClothingStore.ClassHelper.EFClass;
using ClothingStore.DB;

namespace ClothingStore.Pages.PublicPages
{
    /// <summary>
    /// Логика взаимодействия для CatalogePage.xaml
    /// </summary>
    public partial class CatalogePage : Page
    {
        public CatalogePage()
        {
            InitializeComponent();
            //List<CurrentItem> products   = new List<CurrentItem>();
            //products = Context.CurrentItem.ToList();
            
            
            //lv_Products.ItemsSource = products;

            
        }
    }
}
