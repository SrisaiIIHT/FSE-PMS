using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class ProjectEntities
    {
        static ProjectManagementEntities DbContext;

        static ProjectEntities()
        {
            DbContext = new ProjectManagementEntities();
        }

        public static List<ProjectDetail> GetAllProjects()
        {
            using (var myContext = new ProjectManagementEntities())
            {
                return myContext.ProjectDetails.ToList();
            }
        }

        public static List<ViewProjectDetails> GetViewProjectDetails()
        {

            List<ViewProjectDetails> viewProjectDetails = new List<ViewProjectDetails>();
            using (var myContext = new ProjectManagementEntities())
            {
            
            viewProjectDetails = (from pd in myContext.ProjectDetails
                                  join ps in myContext.LookupProjectStatus on pd.StatusId equals ps.Id
                                  select new ViewProjectDetails()
                                  {
                                      ProjectId = pd.Id,
                                      ProjectDesc = pd.ProjectDesc,
                                      StatusId = (int)pd.StatusId,
                                      Status = ps.Desc,
                                      EndDate = (DateTime)pd.EndDate,
                                      StartDate = (DateTime)pd.StartDate,
                                      Priority = (int)pd.Priority
                                  }).ToList();

            foreach (var item in viewProjectDetails)
            {
                var result = myContext.TaskDetails.Where(x => x.ProjectId == item.ProjectId).Select(x => x.StatusId);
                item.TaskCount = result.Count();
                item.CompletedTaskCount = result.Where(x => x.Value == 3).Count();
            }
        }
            return viewProjectDetails;
        }

        public static ProjectDetail GetProject(int projectId)
        {
            using (var myContext = new ProjectManagementEntities())
            {
                return myContext.ProjectDetails.Where(p => p.Id == projectId).First();
            }
        }

        public static int GetMaxProjectId()
        {
            using (var myContext = new ProjectManagementEntities())
            {
                return myContext.ProjectDetails.Max(x => x.Id);
            }
        }

        public static bool InsertProjectDetail(ProjectDetail project)
        {
            bool status;
            project.StatusId = 1;
            using (var myContext = new ProjectManagementEntities())
            {
                try
                {
                    myContext.ProjectDetails.Add(project);
                    myContext.SaveChanges();
                    status = true;
                }
                catch (Exception ex)
                {
                    status = false;
                }
            }
           
            return status;
        }

        public static bool UpdateProjectDetail(ProjectDetail project)
        {
            bool status;
            using (var myContext = new ProjectManagementEntities())
            {
                try
                {

                    ProjectDetail projectItemInfo = myContext.ProjectDetails.Where(p => p.Id == project.Id).FirstOrDefault();
                    if (projectItemInfo != null)
                    {
                        projectItemInfo.Id = project.Id;
                        projectItemInfo.ManagerId = project.ManagerId;
                        projectItemInfo.Priority = project.Priority;
                        projectItemInfo.ProjectDesc = project.ProjectDesc;
                        projectItemInfo.StartDate = project.StartDate;
                        projectItemInfo.EndDate = project.EndDate;
                        projectItemInfo.StatusId = project.StatusId;
                        myContext.SaveChanges();
                    }

                    status = true;
                }
                catch (Exception)
                {
                    status = false;
                }
            }
            return status;
        }

        public static bool DeleteProject(int id)
        {
            bool status;
            using (var myContext = new ProjectManagementEntities())
            {
                try
                {
                    ProjectDetail prodItem = myContext.ProjectDetails.Where(p => p.Id == id).FirstOrDefault();
                    if (prodItem != null)
                    {
                        myContext.ProjectDetails.Remove(prodItem);
                        myContext.SaveChanges();
                    }
                    status = true;
                }
                catch (Exception)
                {
                    status = false;
                }
            }
            return status;
        }
    }
}
