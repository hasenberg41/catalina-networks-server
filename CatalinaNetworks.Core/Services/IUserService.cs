using CatalinaNetworks.Core.Models;
using CatalinaNetworks.Core.Models.Paggination;

namespace CatalinaNetworks.Core.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> Get(QuerryParameters parameters);
    }
}
