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
    
    public partial class Photo
    {
        public string PhotoID { get; set; }
        public int CurrentItemID { get; set; }
        public string PhotoPath { get; set; }
    
        public virtual CurrentItem CurrentItem { get; set; }
    }
}
