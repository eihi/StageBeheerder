//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StageManager.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class adresses
    {
        public adresses()
        {
            this.companies = new HashSet<companies>();
            this.students = new HashSet<students>();
            this.teachers = new HashSet<teachers>();
        }
    
        public int id { get; set; }
        public string place { get; set; }
        public string street { get; set; }
        public string housenumber { get; set; }
        public string zipcode { get; set; }
    
        public virtual ICollection<companies> companies { get; set; }
        public virtual ICollection<students> students { get; set; }
        public virtual ICollection<teachers> teachers { get; set; }
    }
}
