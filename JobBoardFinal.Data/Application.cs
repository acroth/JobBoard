//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobBoardFinal.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Application
    {
        public int ApplicationID { get; set; }
        public int OpenPositionID { get; set; }
        public int UserID { get; set; }
        public System.DateTime ApplicationDate { get; set; }
        public bool IsDeclined { get; set; }
        public string ResumeFilename { get; set; }
        public string ManagerNotes { get; set; }
    
        public virtual OpenPosition OpenPosition { get; set; }
    }
}
