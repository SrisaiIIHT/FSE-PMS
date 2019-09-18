using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMgmtSvc.Models
{
    public class TaskDetails
    {
        public int id { get; set; }

        public int ProjectId { get; set; }

        public ProjectDetails Project { get; set; }

        public string Task { get; set; }

        public bool IsParent { get; set; }

        public int ParentTaskId { get; set; }

        public TaskDetails ParentTask { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int Priority { get; set; }
    }
}