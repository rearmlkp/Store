//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Store.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class pendingproduct
    {
        public int idPendingProduct { get; set; }
        public string username { get; set; }
        public int idProductType { get; set; }
        public string PendingProductName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }
        public int Status { get; set; }
    
        public virtual producttype producttype { get; set; }
        public virtual user user { get; set; }
    }
}
