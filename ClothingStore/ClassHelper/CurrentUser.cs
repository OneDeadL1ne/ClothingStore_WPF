using ClothingStore.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.ClassHelper
{
    public class CurrentUser
    {
        public static Employee Employee { get; set; }
        public static Customer Customer { get; set; }
        

    }
}
