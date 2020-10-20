using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DotNetDemo.Business.Interfaces.Services;
using DotNetDemo.Business.Models.Data;
using DotNetDemo.Business.UoW;
using DotNetDemo.Database.Domain;

namespace DotNetDemo.Business.Services
{
    public class PackageService : ServiceBase, IPackageService
    {
        public PackageService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public void AddPackages(List<string> packages)
        {
            var existingPackages = UnitOfWork.PackageRepository.GetAll().ToList();
            var newPackages = new List<Package>();
            foreach (var package in packages)
            {
                if (!existingPackages.Any(x => x.Name.Equals(package)))
                {
                    newPackages.Add(new Package { Name = package });
                }
            }
            if (newPackages.Any())
            {
                UnitOfWork.PackageRepository.InsertRange(newPackages);
                UnitOfWork.PackageRepository.Save();
            }
        }

        public List<PackageModel> GetAll(string searchText = "")
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return Mapper.Map<List<PackageModel>>(UnitOfWork.PackageRepository.GetAll());
            }
            return Mapper.Map<List<PackageModel>>(UnitOfWork.PackageRepository.FindBy(x => x.Name.Contains(searchText.Trim())));
        }
    }
}