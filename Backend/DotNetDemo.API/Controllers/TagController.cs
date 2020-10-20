using System;
using System.Linq;
using System.Web.Http;
using DotNetDemo.Business.Interfaces.Services;
using DotNetDemo.Business.Common;
using System.Collections.Generic;

namespace DotNetDemo.API.Controllers
{
    [RoutePrefix("api/Tag")]
    public class TagController : BaseApiController
    {
        #region Properties

        private readonly ITagService _tagService;

        #endregion

        #region Constructor

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        #endregion

        [HttpPost]
        public object Post()
        {
            var tags = DoActionForGet<List<string>>(string.Empty, Constant.TagUrl);
            if (tags.Any())
            {
                _tagService.AddTags(tags);
            }
            return GetDataWithMessage(() => new Tuple<object, string, bool>(_tagService.GetAll(), "Record imported successfully", true));
        }

        [HttpGet]
        public object Get(string searchText = "")
        {
            return GetDataWithMessage(() => new Tuple<object, string, bool>(_tagService.GetAll(searchText), string.Empty, true));
        }
    }
}