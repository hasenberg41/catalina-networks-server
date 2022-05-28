namespace CatalinaNetworks.Core.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(int id);

        Task<int> Create(T item);

        Task Update(T item);

        Task Delete(T item);

        Task Save();
    }
}
