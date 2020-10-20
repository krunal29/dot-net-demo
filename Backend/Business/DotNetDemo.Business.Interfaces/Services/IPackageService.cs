using System.Collections.Generic;
using DotNetDemo.Business.Models.Data;
using DotNetDemo.Database.Domain;

namespace DotNetDemo.Business.Interfaces.Services
{
    public interface IPackageService
    {
        void AddPackages(List<string> packages);        

        List<PackageModel> GetAll(string searchText = "");
    }
}
