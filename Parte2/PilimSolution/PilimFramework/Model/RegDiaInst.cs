//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PilimFramework.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class RegDiaInst
    {
        public string isin { get; set; }
        public System.DateTime dat { get; set; }
        public float val_min { get; set; }
        public float val_max { get; set; }
        public float val_ab { get; set; }
        public Nullable<float> val_fe { get; set; }
    
        public virtual Instrumento Instrumento { get; set; }
    }
}
