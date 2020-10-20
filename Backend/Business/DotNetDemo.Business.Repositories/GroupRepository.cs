using DotNetDemo.Business.Interfaces.Repositories;
using DotNetDemo.Database.Domain;

namespace DotNetDemo.Business.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(DotNetDemoEntities context) : base(context)
        {

        }
	}
}