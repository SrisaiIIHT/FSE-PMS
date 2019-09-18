using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMgmtSvc.Models
{
    public class ProjectDetails
    {
        public int Id { get; set; }

        public string ProjectDesc { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int ManagerId { get; set; }

        public User Manager { get;  set; }

        public int Priority { get; set; }

        public int StatusId { get; set; }

        public string StatusDesc { get; set; }
    }
}