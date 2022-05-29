namespace CatalinaNetworks.Core.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<List<T>> Get(CancellationToken cancellationToken);

        Task<T> Get(int id, CancellationToken cancellationToken);

        Task<int> Create(T item, CancellationToken cancellationToken);

        Task Update(T item, CancellationToken cancellationToken);

        Task Delete(T item, CancellationToken cancellationToken);

        Task Save(CancellationToken cancellationToken);
    }
}
