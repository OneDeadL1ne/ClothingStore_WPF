//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClothingStore.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Check
    {
        public int CheckID { get; set; }
        public int CartID { get; set; }
        public int EmployeeID { get; set; }
        public System.DateTime CheckDateTime { get; set; }
        public decimal TotalPrice { get; set; }
    
        public virtual Cart Cart { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
