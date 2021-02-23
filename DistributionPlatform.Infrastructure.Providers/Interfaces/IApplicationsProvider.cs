using DistributionPlatform.Infrastructure.Entities;
using System;
using System.Collections.Generic;

namespace DistributionPlatform.Infrastructure.Providers
{
    public interface IApplicationsProvider : IBaseProvider
    {
        void InsertApplication(Application application);
        Application GetApplication(int id);
        List<Application> GetAllApplications();
        List<Application> GetManyApplications(Func<Application, bool> filter, IEnumerable<int> ids = null);
    }
}
