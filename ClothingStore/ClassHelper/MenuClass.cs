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
        public static void SetIsEnabledTrue(string pageactive)
        {
            switch (pageactive)
            {
                case "CatalogePage":
                    buttonLogin.IsEnabled = true;
                    buttonCatalog.IsEnabled = false;
                    buttonCart.IsEnabled = true;
                    buttonPersonalAccount.IsEnabled = true;
                    break;
                case "CartPage":
                    buttonLogin.IsEnabled = true;
                    buttonCatalog.IsEnabled = true;
                    buttonCart.IsEnabled = false;
                    buttonPersonalAccount.IsEnabled = true;
                    break;
            }
                
           
           

        }
        public static void SetIsEnabledFalse()
        {

            buttonLogin.IsEnabled = false;
            buttonCatalog.IsEnabled = false;
            buttonCart.IsEnabled = false;
            buttonPersonalAccount.IsEnabled = false;
            

        }
        public static void SetFocusButton(object sender)
        {
           
            Button button = (Button)sender;
            switch (button.Name) 
            {
                case "btn_Catalog":
                    buttonCatalog.IsEnabled= false;
                    buttonCart.IsEnabled= true;
                    buttonPersonalAccount.IsEnabled= true;
                    buttonLogin.IsEnabled = true;

                    break;
                case "btn_Cart":
                   
                    buttonCart.IsEnabled = false;
                    buttonCatalog.IsEnabled = true;
                    buttonLogin.IsEnabled = true;
                    buttonPersonalAccount.IsEnabled = true;
                   
                    break;
                case "btn_PersonalAccount":
                    buttonPersonalAccount.IsEnabled= false;
                    buttonCart.IsEnabled= true;
                    buttonCatalog.IsEnabled= true;
                    buttonLogin.IsEnabled= true;
                    break;
                
            }
        }
    }
}
