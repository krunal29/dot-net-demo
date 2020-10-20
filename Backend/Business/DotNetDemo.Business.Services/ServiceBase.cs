using DotNetDemo.Business.UoW;
using System;

namespace DotNetDemo.Business.Services
{
    public abstract class ServiceBase : IDisposable
    {
        protected readonly IUnitOfWork UnitOfWork;

        protected ServiceBase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing) UnitOfWork.Dispose();

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ServiceBase()
        {
            Dispose(false);
        }
    }
}
