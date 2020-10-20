using System;
using System.Linq;
using System.Web.Http;
using DotNetDemo.Business.Interfaces.Services;
using DotNetDemo.Business.Common;
using System.Collections.Generic;

namespace DotNetDemo.API.Controllers
{
    [RoutePrefix("api/Group")]
    public class GroupController : BaseApiController
    {
        #region Properties

        private readonly IGroupService _groupService;

        #endregion

        #region Constructor

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        #endregion

        [HttpPost]
        public object Post()
        {
            var groups = DoActionForGet<List<string>>(string.Empty, Constant.GroupUrl);
            if (groups.Any())
            {
                _groupService.AddGroups(groups);
            }
            return GetDataWithMessage(() => new Tuple<object,string, bool>(_groupService.GetAll(), "Record imported successfully", true));
        }

        [HttpGet]
        public object Get(string searchText = "")
        {
            return GetDataWithMessage(() => new Tuple<object, string, bool>(_groupService.GetAll(searchText), string.Empty, true));
        }
    }
}