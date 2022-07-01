using CatalinaNetworks.Core.Models;
using CatalinaNetworks.Core.Models.Paggination;
using System.Threading.Tasks;

namespace CatalinaNetworks.Core.Services
{
    public interface IUserService
    {
        Task<UsersPage> Get(QuerryParameters parameters);
    }
}
