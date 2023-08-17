using PropertyAPI.Data.Repository;
using PropertyAPI.Interfaces;

namespace PropertyAPI.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public ICityRepository CityRepository => 
            new CityRepository(dataContext);

        public async Task<bool> SaveAsync()
        {
            return await dataContext.SaveChangesAsync() > 0;
        }
    }
}
