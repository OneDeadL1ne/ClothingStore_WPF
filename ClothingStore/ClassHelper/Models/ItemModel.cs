using ClothingStore.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static ClothingStore.ClassHelper.EFClass;

namespace ClothingStore.ClassHelper
{
    public class ItemModel
    {
        public string type { get; set; }
        public GeneralItem generalItem { get; set; }
        public CurrentItem currentItem { get; set; }
        public Visibility visibility { get; set; }
    }
}
