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
    
    public partial class usercomment
    {
        public string username { get; set; }
        public int idProduct { get; set; }
        public string Comment { get; set; }
    
        public virtual product product { get; set; }
        public virtual user user { get; set; }
    }
}
