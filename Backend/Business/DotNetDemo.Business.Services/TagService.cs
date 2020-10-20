using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DotNetDemo.Business.Interfaces.Services;
using DotNetDemo.Business.Models.Data;
using DotNetDemo.Business.UoW;
using DotNetDemo.Database.Domain;

namespace DotNetDemo.Business.Services
{
    public class TagService : ServiceBase, ITagService
    {
        public TagService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public void AddTags(List<string> tags)
        {
            var existingPackages = UnitOfWork.TagRepository.GetAll().ToList();
            var newTags = new List<Tag>();
            foreach (var tag in tags)
            {
                if (!existingPackages.Any(x => x.Name.Equals(tag)))
                {
                    newTags.Add(new Tag { Name = tag });
                }
            }
            if (newTags.Any())
            {
                UnitOfWork.TagRepository.InsertRange(newTags);
                UnitOfWork.TagRepository.Save();
            }
        }

        public List<TagModel> GetAll(string searchText = "")
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return Mapper.Map<List<TagModel>>(UnitOfWork.TagRepository.GetAll());
            }
            return Mapper.Map<List<TagModel>>(UnitOfWork.TagRepository.FindBy(x => x.Name.Contains(searchText.Trim())));
        }
    }
}