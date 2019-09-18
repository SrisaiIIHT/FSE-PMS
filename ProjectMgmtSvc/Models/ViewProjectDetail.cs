using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMgmtSvc.Models
{
    public class ViewProjectDetail
    {
        public int ProjectId { get; set; }

        public string ProjectDesc { get; set; }

        public int TaskCount { get; set; }

        public int CompletedTaskCount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Priority { get; set; }
    }
}