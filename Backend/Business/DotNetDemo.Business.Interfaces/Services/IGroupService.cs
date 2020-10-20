using System.Collections.Generic;
using DotNetDemo.Business.Models.Data;
using DotNetDemo.Database.Domain;

namespace DotNetDemo.Business.Interfaces.Services
{
    public interface IGroupService
    {
        void AddGroups(List<string> groups);        

        List<GroupModel> GetAll(string searchText = "");
    }
}
