using System;
using System.Linq;
using System.Web.Http;
using DotNetDemo.Business.Interfaces.Services;
using DotNetDemo.Business.Common;
using System.Collections.Generic;

namespace DotNetDemo.API.Controllers
{
    [RoutePrefix("api/Package")]
    public class PackageController : BaseApiController
    {
        #region Properties

        private readonly IPackageService _packageService;

        #endregion

        #region Constructor

        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        #endregion

        [HttpPost]
        public object Post()
        {
            var packages = DoActionForGet<List<string>>(string.Empty, Constant.PackageUrl);
            if (packages.Any())
            {
                _packageService.AddPackages(packages);
            }
            return GetDataWithMessage(() => new Tuple<object, string, bool>(_packageService.GetAll(), "Record imported successfully", true));
        }

        [HttpGet]
        public object Get(string searchText = "")
        {
            return GetDataWithMessage(() => new Tuple<object, string, bool>(_packageService.GetAll(searchText), string.Empty, true));
        }
    }
}