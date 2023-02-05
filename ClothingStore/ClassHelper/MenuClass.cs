using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ClothingStore.ClassHelper
{
    class MenuClass
    {
        public static Button buttonLogin;
        public static Button buttonCatalog;
        public static Button buttonCart;
        public static Button buttonPersonalAccount;
        public static void SetIsEnabledTrue()
        {
            buttonLogin.IsEnabled = true;
            buttonCatalog.IsEnabled = true;
            buttonCart.IsEnabled = true;
           

        }
        public static void SetIsEnabledFalse()
        {
            buttonLogin.IsEnabled = false;
            buttonCatalog.IsEnabled = false;
            buttonCart.IsEnabled = false;
            

        }
        public static void SetFocusButton(object sender)
        {
           
            Button button = (Button)sender;
            switch (button.Name) 
            {
                case "btn_Catalog":
                    buttonCatalog.IsEnabled= false;
                    buttonCart.IsEnabled= true;


                    break;
                case "btn_Cart":
                    buttonCart.IsEnabled = false;
                    buttonCatalog.IsEnabled = true;
                   
                    break;
                default:
                    SetIsEnabledTrue();
                    break;

            }
        }
    }
}
