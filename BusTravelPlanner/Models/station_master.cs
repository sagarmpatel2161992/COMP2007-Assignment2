//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusTravelPlanner.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class station_master
    {
        public station_master()
        {
            this.bus_master = new HashSet<bus_master>();
            this.bus_master1 = new HashSet<bus_master>();
        }
    
        public decimal STATION_ID { get; set; }
        public string STATION_NAME { get; set; }
    
        public virtual ICollection<bus_master> bus_master { get; set; }
        public virtual ICollection<bus_master> bus_master1 { get; set; }
    }
}
