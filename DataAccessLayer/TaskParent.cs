//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class TaskParent
    {
        public int Id { get; set; }
        public Nullable<int> TaskId { get; set; }
        public Nullable<int> ParentTaskId { get; set; }
    
        public virtual TaskDetail TaskDetail { get; set; }
        public virtual TaskDetail TaskDetail1 { get; set; }
    }
}