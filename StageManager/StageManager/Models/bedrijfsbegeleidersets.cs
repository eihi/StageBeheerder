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
    
    public partial class bedrijfsbegeleidersets
    {
        public bedrijfsbegeleidersets()
        {
            this.stagesets = new HashSet<stagesets>();
        }
    
        public string Functie { get; set; }
        public string Naam { get; set; }
        public string Opleidingsniveau { get; set; }
        public string Email { get; set; }
        public string Telefoon { get; set; }
        public Nullable<bool> Minimale_begeleidingstijd_gegarandeerd { get; set; }
        public int Id { get; set; }
        public int bedrijfset_Bedrijfs_Id { get; set; }
    
        public virtual bedrijfsets bedrijfsets { get; set; }
        public virtual ICollection<stagesets> stagesets { get; set; }
    }
}
