using ClothingStore.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using static ClothingStore.ClassHelper.EFClass;

namespace ClothingStore.Windows
{
    /// <summary>
    /// Логика взаимодействия для TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        public List<string> selectedGroups = new List<string>();
        public List<CustomerGroup> data = new List<CustomerGroup>();
        public TestWindow()
        {
            InitializeComponent();
            ObservableCollection<ModelGroup> custdata = new ObservableCollection<ModelGroup>();
        
            data = Context.CustomerGroup.ToList();
            for (int i = 0; i<data.Count;i++)
            {
                custdata.Add(new ModelGroup() { GroupTitle = data.ToList()[i].GruopTitle});
            }

            lst.ItemsSource = custdata;
            //lst.ItemsSource = typeof(Colors).GetProperties();
        }

        public class ModelGroup{
            public string GroupTitle { get; set; }
        }

        private void btn_GetId_Click(object sender, RoutedEventArgs e)
        {
            
            for (int i = 0; i < selectedGroups.Count; i++)
            {
                var id = data.ToList().Where(x => x.GruopTitle == selectedGroups[i]).FirstOrDefault().CustomerGroupID;
                MessageBox.Show(id.ToString());
                //selectedGroups.RemoveAt(i);
            }
            
            
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            DataTemplate dataTemplate = new DataTemplate();
            dataTemplate=lv_Header.ItemTemplate;
            var cb = (CheckBox)sender;
            if (cb.IsChecked.Value)
            {
                selectedGroups.Add(cb.Content.ToString());
            }

            if (!cb.IsChecked.Value)
            {
                selectedGroups.Remove(cb.Content.ToString());
            }


            if (selectedGroups.Count>=2)
            {
                DataTemplate template = new DataTemplate();
                DataTemplate template1 = null;
                template.DataType = typeof(string);
                FrameworkElementFactory tb = new FrameworkElementFactory(typeof(TextBlock));
                int count = selectedGroups.Count();
                lst.DisplayMemberPath = selectedGroups.Count.ToString();
                tb.SetValue(TextBlock.TextProperty,count.ToString());


                template.VisualTree = tb;
                lv_Header.ItemTemplate = template1;
                
                
                
            }
         
            if(selectedGroups.Count<2 && selectedGroups.Count>0)
            {

                DataTemplate template = new DataTemplate();
                template.DataType = typeof(string);
                FrameworkElementFactory tb = new FrameworkElementFactory(typeof(TextBlock));
             
                tb.SetValue(TextBlock.TextProperty, selectedGroups[0]);


                template.VisualTree = tb;
                lv_Header.ItemTemplate = template;
            }
        }

       

       
    }
    
}
