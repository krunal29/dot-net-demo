using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DotNetDemo.Business.Interfaces.Services;
using DotNetDemo.Business.Models.Data;
using DotNetDemo.Business.UoW;
using DotNetDemo.Database.Domain;

namespace DotNetDemo.Business.Services
{
    public class GroupService : ServiceBase, IGroupService
    {
        public GroupService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public void AddGroups(List<string> groups)
        {
            var existingPackages = UnitOfWork.GroupRepository.GetAll().ToList();
            var newTags = new List<Group>();
            foreach (var group in groups)
            {
                if (!existingPackages.Any(x => x.Name.Equals(group)))
                {
                    newTags.Add(new Group { Name = group });
                }
            }
            if (newTags.Any())
            {
                UnitOfWork.GroupRepository.InsertRange(newTags);
                UnitOfWork.GroupRepository.Save();
            }
        }

        public List<GroupModel> GetAll(string searchText = "")
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return Mapper.Map<List<GroupModel>>(UnitOfWork.GroupRepository.GetAll());
            }
            return Mapper.Map<List<GroupModel>>(UnitOfWork.GroupRepository.FindBy(x => x.Name.Contains(searchText.Trim())));
        }
    }
}