using System;

namespace DotNetDemo.Database.Domain
{
    public partial class DotNetDemoEntities
    {		
         public DotNetDemoEntities(string nameOrConnectionString = "name=DotNetDemoEntities") : base(nameOrConnectionString)
         {
            Configuration.LazyLoadingEnabled = false;
         }
    }
}