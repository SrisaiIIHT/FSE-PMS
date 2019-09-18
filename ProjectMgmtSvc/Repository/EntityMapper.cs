using AutoMapper;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMgmtSvc.Repository
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<Models.User, User>().ForMember(dest => dest.EmpId,
               opts => opts.MapFrom(src => src.EmployeeId));
                config.CreateMap<User,Models.User>().ForMember(dest => dest.EmployeeId,
               opts => opts.MapFrom(src => src.EmpId));
                config.CreateMap<Models.ProjectDetails, ProjectDetail>();
                config.CreateMap<ProjectDetail, Models.ProjectDetails>();
                config.CreateMap<Models.TaskDetails, TaskDetail>();
                config.CreateMap<TaskDetail, Models.TaskDetails>();
                config.CreateMap<Models.ViewProjectDetail, ViewProjectDetails>();
                config.CreateMap<ViewProjectDetails, Models.ViewProjectDetail>();

            });
        }
    }
}      