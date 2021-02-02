using DistributionPlatform.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DistributionPlatform.Infrastructure.Providers
{
    public class ApplicationsProvider : BaseProvider<DistributionPlatformContext>, IApplicationsProvider
    {
        public ApplicationsProvider(DistributionPlatformContext context) : base(context) { }

        public List<Application> GetAllApplications()
            => base._context.Applications.ToList();
        

        public Application GetApplication(int id)
            => base._context.Applications.Find(id);            

        public List<Application> GetManyApplications(Func<Application, bool> filter, IEnumerable<int> ids = null)
            => (ids != null) ? base._context.Applications.Where(app => ids.Contains(app.Id)).Where(filter).ToList() : base._context.Applications.Where(filter).ToList();


        public void InsertApplication(Application application)
        {
            if (application != null)
                base._context.Applications.Add(application);
        }
    }
}
