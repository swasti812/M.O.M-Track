//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MOMTracker
{
    using System;
    using System.Collections.Generic;
    
    public partial class INVITEESTABLE
    {
        public decimal ID { get; set; }
        public decimal MEETINGID { get; set; }
        public decimal INVITEEID { get; set; }
    
        public virtual MEETINGTABLE MEETINGTABLE { get; set; }
    }
}