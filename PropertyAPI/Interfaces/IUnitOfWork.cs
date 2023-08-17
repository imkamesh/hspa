namespace PropertyAPI.Interfaces
{
    public interface IUnitOfWork
    {
        ICityRepository CityRepository { get; }
        Task<bool> SaveAsync();
    }
}
