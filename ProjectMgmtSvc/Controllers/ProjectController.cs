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
    public class ProjectController : ApiController
    {
        //api/Project/GetAllProjectDetails
        [HttpGet]
        public JsonResult<List<Models.ProjectDetails>> GetAllProjectDetails()
        {
            List<DataAccessLayer.ProjectDetail> projectList = ProjectEntities.GetAllProjects();
            List<Models.ProjectDetails> projects = new List<Models.ProjectDetails>();


            List<Models.ProjectDetails> projectObj = Mapper.Map<List<DataAccessLayer.ProjectDetail>, List<Models.ProjectDetails>>(projectList);
            return Json(projectObj);
        }

        //api/Project/GetAllProjectDetailsSorted
        [HttpGet]
        public JsonResult<List<Models.ProjectDetails>> GetAllProjectDetailsSorted(string sortBy, bool ascending)
        {
            List<DataAccessLayer.ProjectDetail> prodList = ProjectEntities.GetAllProjects().AsQueryable().OrderByPropertyName(sortBy, ascending).ToList();
            var result = new List<DataAccessLayer.ProjectDetail>();

            var projectObject = Mapper.Map<List<DataAccessLayer.ProjectDetail>, List<Models.ProjectDetails>>(prodList);
            return Json(projectObject);
        }

        ////api/Project/GetAllProjectDetailsFiltered
        [HttpPost]
        public JsonResult<List<Models.ProjectDetails>> GetAllProjectDetailsFiltered([FromBody] SearchSortParameter request)
        {
            var result = ProjectEntities.GetAllProjects();
            List<DataAccessLayer.ProjectDetail> prodList;
            IEnumerable<DataAccessLayer.ProjectDetail> searchResult;

            if (!string.IsNullOrEmpty(request.Search))
                searchResult = result.Where(x => x.ProjectDesc.Contains(request.Search));
            else
                searchResult = result;

            prodList = searchResult.AsQueryable().OrderByPropertyName(request.SortBy, request.Ascending).ToList();

            var projectObj = Mapper.Map<List<DataAccessLayer.ProjectDetail>, List<Models.ProjectDetails>>(prodList);
            return Json(projectObj);
        }

        ////api/Project/GetViewProjectsDetails
        [HttpGet]
        public JsonResult<List<Models.ViewProjectDetail>> GetViewProjectsDetails(string searchBy, string sortBy, bool ascending)
        {
            var result = ProjectEntities.GetViewProjectDetails();
            List<DataAccessLayer.ViewProjectDetails> projectList;
            IEnumerable<DataAccessLayer.ViewProjectDetails> searchResult;

            if (!string.IsNullOrEmpty(searchBy))
                searchResult = result.Where(x => x.ProjectDesc.Contains(searchBy));
            else
                searchResult = result;

            projectList = searchResult.AsQueryable().OrderByPropertyName(sortBy, ascending).ToList();

            var projectObj = Mapper.Map<List<DataAccessLayer.ViewProjectDetails>, List<Models.ViewProjectDetail>>(projectList);
            return Json(projectObj);
        }

        ////api/Project/GetViewProjectsFiltered
        [HttpPost]
        public JsonResult<List<Models.ViewProjectDetail>> GetViewProjectsFiltered([FromBody] SearchSortParameter request)
        {
            var result = ProjectEntities.GetViewProjectDetails();
            List<DataAccessLayer.ViewProjectDetails> projectList;
            IEnumerable<DataAccessLayer.ViewProjectDetails> searchResult;

            if (!string.IsNullOrEmpty(request.Search))
                searchResult = result.Where(x => x.ProjectDesc.Contains(request.Search));
            else
                searchResult = result;

            projectList = searchResult.AsQueryable().OrderByPropertyName(request.SortBy, request.Ascending).ToList();

            var projectObj = Mapper.Map<List<DataAccessLayer.ViewProjectDetails>, List<Models.ViewProjectDetail>>(projectList);
            return Json(projectObj);
        }


        //api/Project/GetProjectDetail
        [HttpGet]
        public JsonResult<Models.ProjectDetails> GetProjectDetail(int id)
        {
            var ProjectEntitiesInfo = ProjectEntities.GetProject(id);
            var project = new Models.ProjectDetails();
            Models.ProjectDetails obj = Mapper.Map<DataAccessLayer.ProjectDetail, Models.ProjectDetails>(ProjectEntitiesInfo);

            var managerInfo =  UserEntities.GetUsers((int)ProjectEntitiesInfo.ManagerId);
            obj.Manager = Mapper.Map<DataAccessLayer.User, Models.User>(managerInfo);
            return Json<Models.ProjectDetails>(obj);
        }

        //api/Project/InsertProjectDetail
        [HttpPost]
        public bool InsertProjectDetail(Models.ProjectDetails projectDetails)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                projectDetails.Id = ProjectEntities.GetMaxProjectId() + 1;
                var projectDetailsObj = Mapper.Map<Models.ProjectDetails, DataAccessLayer.ProjectDetail>(projectDetails);
                status = ProjectEntities.InsertProjectDetail(projectDetailsObj);
            }
            return status;

        }

        //api/Project/UpdateProjectDetail
        [HttpPut]
        public bool UpdateProjectDetail(Models.ProjectDetails projectDetails)
        {
            var projectDetailsObj = Mapper.Map<Models.ProjectDetails, DataAccessLayer.ProjectDetail>(projectDetails);
            var status = ProjectEntities.UpdateProjectDetail(projectDetailsObj);
            return status;
        }

        //api/Project/DeleteProjectDetail
        [HttpDelete]
        public bool DeleteProjectDetail(int id)
        {
            var status = ProjectEntities.DeleteProject(id);
            return status;
        }
    }
}
