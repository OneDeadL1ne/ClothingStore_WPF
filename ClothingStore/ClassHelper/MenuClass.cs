using ClothingStore.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static ClothingStore.ClassHelper.EFClass;
using static ClothingStore.ClassHelper.ItemModel;

namespace ClothingStore.ClassHelper
{
    class MenuClass
    {
        public static Button buttonLogin;
        public static Button buttonCatalog;
        public static Button buttonCart;
        public static Button buttonPersonalAccount;
        public static Button buttonAddEdit;
        public static Button buttonLists;
        public static void SetIsEnabledTrue(string pageactive)
        {
            
            switch (pageactive)
            {
                case "CatalogePage":
                    buttonLogin.IsEnabled = true;
                    buttonCatalog.IsEnabled = false;
                    buttonCart.IsEnabled = true;
                    buttonAddEdit.IsEnabled = true;
                    buttonPersonalAccount.IsEnabled = true;
                    buttonLists.IsEnabled = true;
                    break;
                case "CartPage":
                    buttonLogin.IsEnabled = true;
                    buttonCatalog.IsEnabled = true;
                    buttonCart.IsEnabled = false;
                    buttonPersonalAccount.IsEnabled = true;
                    buttonAddEdit.IsEnabled = true;
                    buttonLists.IsEnabled = true;
                    break;
                case "AddEditPage":
                    buttonLogin.IsEnabled = true;
                    buttonCatalog.IsEnabled = true;
                    buttonCart.IsEnabled = true;
                    buttonPersonalAccount.IsEnabled = true;
                    buttonAddEdit.IsEnabled = false;
                    buttonLists.IsEnabled = true;
                    break;
                case "ListPage":
                    buttonLogin.IsEnabled = true;
                    buttonCatalog.IsEnabled = true;
                    buttonCart.IsEnabled = true;
                    buttonPersonalAccount.IsEnabled = true;
                    buttonAddEdit.IsEnabled = true;
                    buttonLists.IsEnabled = false;
                    break;
                case "ListEmployeePage":
                    buttonLogin.IsEnabled = true;
                    buttonCatalog.IsEnabled = true;
                    buttonCart.IsEnabled = true;
                    buttonPersonalAccount.IsEnabled = true;
                    buttonAddEdit.IsEnabled = true;
                    buttonLists.IsEnabled = false;
                    break;

            }
                
           
           

        }
        public static void SetIsEnabledFalse()
        {

            buttonLogin.IsEnabled = false;
            buttonCatalog.IsEnabled = false;
            buttonCart.IsEnabled = false;
            buttonPersonalAccount.IsEnabled = false;
            buttonAddEdit.IsEnabled= false;
            buttonLists.IsEnabled = false;

        }

        public static List<ItemModel>RefreshCatalog()
        {
            List<CurrentItem> products = new List<CurrentItem>();
            products = EFClass.Context.CurrentItem.ToList();
            List<ItemModel> items = new List<ItemModel>();
            foreach (var i in products)
            {
                
                List<TypeСlothes> types = new List<TypeСlothes>();
                
                ItemModel item = new ItemModel();
                item.generalItem = EFClass.Context.GeneralItem.ToList().Where(x=> x.GeneralItemID == i.GeneralItemID).First();
                item.type = (item.generalItem.TypeСlothes as TypeСlothes).TypeTitle; 
                item.currentItem = i;
                item.visibility = Visibility.Collapsed;
                if (CurrentUser.CurrentCustomer != null)
                {
                    item.visibility = Visibility.Collapsed;
                }

                if (CurrentUser.CurrentManager != null)
                {
                    item.visibility = Visibility.Visible;
                }


                items.Add(item);
            }

            return items;
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
                    buttonAddEdit.IsEnabled = true;
                    buttonLists.IsEnabled = true;
                    break;
                case "btn_Cart":
                   
                    buttonCart.IsEnabled = false;
                    buttonCatalog.IsEnabled = true;
                    buttonLogin.IsEnabled = true;
                    buttonPersonalAccount.IsEnabled = true;
                    buttonAddEdit.IsEnabled = true;
                    buttonLists.IsEnabled = true;
                    break;
                case "btn_PersonalAccount":
                    buttonPersonalAccount.IsEnabled= false;
                    buttonCart.IsEnabled= true;
                    buttonCatalog.IsEnabled= true;
                    buttonLogin.IsEnabled= true;
                    buttonAddEdit.IsEnabled = true;
                    buttonLists.IsEnabled = true;
                    break;
                case "btn_AddEdit":
                    buttonAddEdit.IsEnabled = false;
                    buttonLogin.IsEnabled = true;
                    buttonCatalog.IsEnabled = true;
                    buttonCart.IsEnabled = true;
                    buttonPersonalAccount.IsEnabled = true;
                    buttonLists.IsEnabled = true;
                    break;
                case "btn_Lists":
                    buttonAddEdit.IsEnabled = true;
                    buttonLogin.IsEnabled = true;
                    buttonCatalog.IsEnabled = true;
                    buttonCart.IsEnabled = true;
                    buttonPersonalAccount.IsEnabled = true;
                    buttonLists.IsEnabled = false;
                    break;

            }
        }
    }
}
