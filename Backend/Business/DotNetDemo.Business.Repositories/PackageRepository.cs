using DotNetDemo.Business.Interfaces.Repositories;
using DotNetDemo.Database.Domain;

namespace DotNetDemo.Business.Repositories
{
    public class PackageRepository : BaseRepository<Package>, IPackageRepository
    {
        public PackageRepository(DotNetDemoEntities context) : base(context)
        {

        }
	}
}