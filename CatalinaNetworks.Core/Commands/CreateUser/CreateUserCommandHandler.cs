using CatalinaNetworks.Core.Models;
using CatalinaNetworks.Core.Repositories;
using MediatR;

namespace CatalinaNetworks.Core.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IRepository<User> _repository;

        public CreateUserCommandHandler(IRepository<User> repository) => _repository = repository;

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                Name = request.Name,
                Photos = request.Photos,
                UniqueUrlName = request.UniqueUrlName,
            };
            int userId = await _repository.Create(user);
            await _repository.Save();

            return userId;
        }
    }
}
