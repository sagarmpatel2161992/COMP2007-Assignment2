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
    
    public partial class booking_master
    {
        public decimal BOOKING_ID { get; set; }
        public Nullable<decimal> SCHEDULE_ID { get; set; }
        public Nullable<decimal> USER_ID { get; set; }
        public Nullable<int> TOTAL_SEAT { get; set; }
        public Nullable<System.DateTime> BOOKING_DATE { get; set; }
    
        public virtual busschedule_master busschedule_master { get; set; }
        public virtual user_registration user_registration { get; set; }
    }
}