using CatalinaNetworks.Core.Models.Paggination;

namespace CatalinaNetworks.Core.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> Get(CancellationToken cancellationToken = default);

        Task<UsersPage> Get(QuerryParameters querryParameters, CancellationToken cancellationToken = default);

        Task<T> Get(int id, CancellationToken cancellationToken = default);

        Task<int> Create(T item, CancellationToken cancellationToken = default);

        Task Update(T item, CancellationToken cancellationToken = default);

        Task Delete(T item, CancellationToken cancellationToken = default);

        Task Save(CancellationToken cancellationToken = default);
    }
}
