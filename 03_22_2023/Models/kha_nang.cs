//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _03_22_2023.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class kha_nang
    {
        public string ma_nha_cung_cap { get; set; }
        public string ma_loai_hang_hoa { get; set; }
        public string ghi_chu { get; set; }
    
        public virtual loai_hang_hoa loai_hang_hoa { get; set; }
        public virtual nha_cung_cap nha_cung_cap { get; set; }
    }
}
