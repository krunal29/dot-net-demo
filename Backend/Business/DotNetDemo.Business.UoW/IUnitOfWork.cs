using DotNetDemo.Business.Interfaces.Repositories;
using System;

namespace DotNetDemo.Business.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IPackageRepository PackageRepository { get; }
        ITagRepository TagRepository { get; }
        IGroupRepository GroupRepository { get; }
    }
}