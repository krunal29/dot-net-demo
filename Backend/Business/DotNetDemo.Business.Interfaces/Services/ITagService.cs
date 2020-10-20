using System.Collections.Generic;
using DotNetDemo.Business.Models.Data;
using DotNetDemo.Database.Domain;

namespace DotNetDemo.Business.Interfaces.Services
{
    public interface ITagService
    {
        void AddTags(List<string> tags);        

        List<TagModel> GetAll(string searchText = "");
    }
}
