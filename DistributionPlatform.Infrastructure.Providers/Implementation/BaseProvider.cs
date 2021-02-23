using Microsoft.EntityFrameworkCore;

namespace DistributionPlatform.Infrastructure.Providers
{
    public abstract class BaseProvider<T> where T : DbContext
    {
        private protected T _context;
        private protected BaseProvider(T context)
        {
            this._context = context;
        }

        public int SaveContext()
            => this._context.SaveChanges();
    }
}
