//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Library.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Сataloging
    {
        public int id { get; set; }
        public int id_region { get; set; }
        public int id_book { get; set; }
    
        public virtual Books Books { get; set; }
        public virtual Regions Regions { get; set; }
    }
}
