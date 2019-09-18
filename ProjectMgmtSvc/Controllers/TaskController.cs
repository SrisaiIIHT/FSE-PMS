using AutoMapper;
using DataAccessLayer;
using ProjectMgmtSvc.Models;
using ProjectMgmtSvc.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace ProjectMgmtSvc.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class TaskController : ApiController
    {

        //api/Task/GetAllTaskDetails
        [HttpGet]
        public JsonResult<List<Models.TaskDetails>> GetAllTaskDetails()
        {
            List<DataAccessLayer.TaskDetail> taskList = TaskEntities.GetAllTasks();
            List<Models.TaskDetails> tasks = new List<Models.TaskDetails>();


            List<Models.TaskDetails> taskObj = Mapper.Map<List<DataAccessLayer.TaskDetail>, List<Models.TaskDetails>>(taskList);
            return Json(taskObj);
        }

        //api/Task/GetAllTaskDetailsSorted
        [HttpGet]
        public JsonResult<List<Models.TaskDetails>> GetAllTaskDetailsSorted(string sortBy, bool ascending)
        {
            List<DataAccessLayer.TaskDetail> prodList = TaskEntities.GetAllTasks().AsQueryable().OrderByPropertyName(sortBy, ascending).ToList();
            var result = new List<DataAccessLayer.TaskDetail>();

            var taskObject = Mapper.Map<List<DataAccessLayer.TaskDetail>, List<Models.TaskDetails>>(prodList);
            return Json(taskObject);
        }

        ////api/Task/GetAllTaskDetailsFiltered
        [HttpPost]
        public JsonResult<List<Models.TaskDetails>> GetAllTaskDetailsFiltered([FromBody] SearchSortParameter request)
        {
            var result = TaskEntities.GetAllTasks();
            List<DataAccessLayer.TaskDetail> prodList;
            IEnumerable<DataAccessLayer.TaskDetail> searchResult;

            if (!string.IsNullOrEmpty(request.Search))
                searchResult = result.Where(x => x.Task.Contains(request.Search));
            else
                searchResult = result;

            prodList = searchResult.AsQueryable().OrderByPropertyName(request.SortBy, request.Ascending).ToList();

            var taskObj = Mapper.Map<List<DataAccessLayer.TaskDetail>, List<Models.TaskDetails>>(prodList);
            return Json(taskObj);
        }
               
        //api/Task/GetTaskDetail
        [HttpGet]
        public JsonResult<Models.TaskDetails> GetTaskDetail(int id)
        {
            DataAccessLayer.TaskDetail TaskInfo = TaskEntities.GetTaskDetail(id);
            var task = new Models.TaskDetails();
            Models.TaskDetails obj = Mapper.Map<DataAccessLayer.TaskDetail, Models.TaskDetails>(TaskInfo);
            return Json<Models.TaskDetails>(obj);
        }

        //api/Task/InsertTaskDetail
        [HttpPost]
        public bool InsertTaskDetail([FromBody] Models.TaskDetails taskDetails)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                taskDetails.id = TaskEntities.GetMaxId() + 1;
                var taskDetailsObj = Mapper.Map<Models.TaskDetails, DataAccessLayer.TaskDetail>(taskDetails);
                status = TaskEntities.InsertTask(taskDetailsObj);
            }
            return status;

        }

        //api/Task/UpdateTaskDetail
        [HttpPut]
        public bool UpdateTaskDetail([FromBody] Models.TaskDetails taskDetails)
        {
            var taskDetailsObj = Mapper.Map<Models.TaskDetails, DataAccessLayer.TaskDetail>(taskDetails);
            var status = TaskEntities.UpdateTaskDetail(taskDetailsObj);
            return status;
        }

        //api/Task/DeleteTaskDetail
        [HttpDelete]
        public bool DeleteTaskDetail(int id)
        {
            var status = TaskEntities.DeleteTask(id);
            return status;
        }
    }
}
