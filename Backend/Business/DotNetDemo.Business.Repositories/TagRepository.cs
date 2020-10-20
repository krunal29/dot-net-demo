using DotNetDemo.Business.Interfaces.Repositories;
using DotNetDemo.Database.Domain;

namespace DotNetDemo.Business.Repositories
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(DotNetDemoEntities context) : base(context)
        {

        }
	}
}