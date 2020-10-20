using AutoMapper;
using DotNetDemo.Business.Models.Data;
using DotNetDemo.Database.Domain;

namespace DotNetDemo.Business.Mappings
{
    public static class MapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Package, PackageModel>();
                cfg.CreateMap<Group, GroupModel>();
                cfg.CreateMap<Tag, TagModel>();
            });
        }

    }
}