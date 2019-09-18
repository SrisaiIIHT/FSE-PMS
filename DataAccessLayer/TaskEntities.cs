using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TaskEntities
    {
        static ProjectManagementEntities DbContext;

        static TaskEntities()
        {
            DbContext = new ProjectManagementEntities();
        }

        public static List<TaskDetail> GetAllTasks()
        {
            return DbContext.TaskDetails.ToList();
        }

        public static TaskDetail GetTaskDetail(int taskId)
        {
            return DbContext.TaskDetails.Where(p => p.Id == taskId).FirstOrDefault();
        }

        public static int GetMaxId()
        {
            return DbContext.TaskDetails.Max(x => x.Id);
        }

        public static bool InsertTask(TaskDetail task)
        {
            bool status;
            try
            {
                DbContext.TaskDetails.Add(task);
                DbContext.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        public static bool UpdateTaskDetail(TaskDetail task)
        {
            bool status;
            try
            {
                TaskDetail taskItemInfo = DbContext.TaskDetails.Where(p => p.Id == task.Id).FirstOrDefault();

                if (taskItemInfo != null)
                {
                    taskItemInfo.Id = task.Id;
                    taskItemInfo.EndDate = task.EndDate;
                    taskItemInfo.Priority = task.Priority;
                    taskItemInfo.IsParent = task.IsParent;
                    taskItemInfo.StartDate = task.StartDate;
                    taskItemInfo.ParentTaskId = task.ParentTaskId;
                    taskItemInfo.StatusId = task.StatusId;
                    taskItemInfo.ProjectId = task.ProjectId;
                    taskItemInfo.UserId = task.UserId;
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        public static bool DeleteTask(int id)
        {
            bool status;
            try
            {
                TaskDetail taskItem = DbContext.TaskDetails.Where(p => p.Id == id).FirstOrDefault();
                if (taskItem != null)
                {
                    DbContext.TaskDetails.Remove(taskItem);
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
    }
}
