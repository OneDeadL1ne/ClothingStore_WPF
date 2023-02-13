using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ClothingStore.ClassHelper
{
    class NavigateClass
    {
        public static Frame authorizationFrame;
        public static Frame mainFrame;
        public static Frame menuFrame;
        public static Frame windowFrame;



        public static void NavigatePage(Frame frame, Frame window, Page page)
        {
            

            if (window.CanGoBack)
            {
                var entry = window.RemoveBackEntry();
                while (entry != null)
                {
                    entry = window.RemoveBackEntry();
                }


            }
            frame.Navigate(page);



        }
        

    }
}
