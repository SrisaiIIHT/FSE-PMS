using AutoMapper;
using DataAccessLayer;
using ProjectMgmtSvc.Models;
using ProjectMgmtSvc.Repository;
using ProjectMgmtSvc.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace ProjectMgmtSvc.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        //api/User/GetAllUsers
        [HttpGet]
        public JsonResult<List<Models.User>> GetAllUsers()
        {
            List<DataAccessLayer.User> prodList = UserEntities.GetAllUsers();
            List<Models.User> Users = new List<Models.User>();


            List<Models.User> userObj = Mapper.Map<List<DataAccessLayer.User>, List<Models.User>>(prodList);
            return Json(userObj);
        }

        //api/User/GetAllUsersSorted
        [HttpGet]
        public JsonResult<List<Models.User>> GetAllUsersSorted(string sortBy,bool ascending)
        {
            List<DataAccessLayer.User> prodList = UserEntities.GetAllUsers().AsQueryable().OrderByPropertyName(sortBy, ascending).ToList();
            var result = new List<DataAccessLayer.User>();

            var userObj = Mapper.Map<List<DataAccessLayer.User>, List<Models.User>>(prodList);
            return Json(userObj);
        }

        ////api/User/GetAllUsersFiltered
        [HttpPost]
        public JsonResult<List<Models.User>> GetAllUsersFiltered([FromBody] SearchSortParameter request)
        {
            var result = UserEntities.GetAllUsers();
            List<DataAccessLayer.User> prodList;
            IEnumerable<DataAccessLayer.User> searchResult;

            if (!string.IsNullOrEmpty(request.Search))
                searchResult = result.Where(x => x.FirstName.Contains(request.Search) || x.LastName.Contains(request.Search) || x.EmpId.ToString().Contains(request.Search));
            else
                searchResult = result;

            prodList = searchResult.AsQueryable().OrderByPropertyName(request.SortBy,request.Ascending).ToList();

            var userObj = Mapper.Map<List<DataAccessLayer.User>, List<Models.User>>(prodList);
            return Json(userObj);
        }


        //api/User/GetUser
        [HttpGet]
        public JsonResult<Models.User> GetUser(int id)
        {
            DataAccessLayer.User UserEntitiesUser = UserEntities.GetUsers(id);
            var Users = new Models.User();
            Models.User obj = Mapper.Map<DataAccessLayer.User, Models.User>(UserEntitiesUser);
            return Json<Models.User>(obj);
        }

        ////api/User/InsertUser
        [HttpPost]
        public bool InsertUser(Models.User User)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                var UserObj = Mapper.Map<Models.User, DataAccessLayer.User>(User);
                status = UserEntities.InsertUser(UserObj);
            }
            return status;

        }

        ////api/User/UpdateUser
        [HttpPut]
        public bool UpdateUser(Models.User User)
        {
            var UserObj = Mapper.Map<Models.User, DataAccessLayer.User>(User);
            var status = UserEntities.UpdateUser(UserObj);
            return status;
        }

        ////api/User/DeleteUser
        [HttpDelete]
        public bool DeleteUser(int id)
        {
            var status = UserEntities.DeleteUser(id);
            return status;
        }
    }
}
