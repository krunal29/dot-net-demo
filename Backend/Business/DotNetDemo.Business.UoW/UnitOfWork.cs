using DotNetDemo.Business.Interfaces.Repositories;
using DotNetDemo.Business.Repositories;
using DotNetDemo.Database.Domain;
using System;

namespace DotNetDemo.Business.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DotNetDemoEntities _context;

        public UnitOfWork(DotNetDemoEntities context)
        {
            _context = context;

            PackageRepository = new PackageRepository(_context);

            GroupRepository = new GroupRepository(_context);

            TagRepository = new TagRepository(_context);
        }

        public IPackageRepository PackageRepository { get; }

        public IGroupRepository GroupRepository { get; }

        public ITagRepository TagRepository { get; }



        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
