using CatalinaNetworks.Core.Exceptions;
using CatalinaNetworks.Core.Repositories;
using CatalinaNetworks.DataBase.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace CatalinaNetworks.DataBase
{
    public class UsersDbContext : DbContext, IRepository<Core.Models.User>
    {
        private readonly IMapper _mapper;

        public DbSet<Entities.User> Users { get; set; }
        public DbSet<Entities.Photos> Photos { get; set; }

        public UsersDbContext(DbContextOptions<UsersDbContext> options, IMapper mapper) : base(options)
        {
            _mapper = mapper;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PhotosConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public async Task<IEnumerable<Core.Models.User>> Get(CancellationToken cancellationToken = default)
        {
            var userEntities = await Users.AsNoTracking()
                .Include(u => u.Photos)
                .ToListAsync(cancellationToken: cancellationToken);

            var users = userEntities.Select(u => _mapper.Map<Core.Models.User>(u));
            return users;
        }

        public async Task<Core.Models.User> Get(int id, CancellationToken cancellationToken = default)
        {
            if (id <= 0)
                throw new NotFoundException(nameof(Entities.User), id);

            var user = await Users.AsNoTracking()
                .Include(u => u.Photos)
                .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

            if (user == null)
                throw new NotFoundException(nameof(Entities.User), id);

            return _mapper.Map<Core.Models.User>(user);
        }

        public async Task<int> Create(Core.Models.User newUser, CancellationToken cancellationToken = default)
        {
            var userEntity = _mapper.Map<Entities.User>(newUser);
            var resultUser = await AddAsync(userEntity, cancellationToken);
            await Save(cancellationToken);

            return resultUser.Entity.Id;
        }

        public async Task Update(Core.Models.User user, CancellationToken cancellationToken = default)
        {
            var userEntity = await Users.Include(u => u.Photos)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == user.Id, cancellationToken);

            if (userEntity != null)
            {
                userEntity = _mapper.Map<Entities.User>(user);
                userEntity.Id = user.Id;

                Attach(userEntity).State = EntityState.Modified;

                if (userEntity.Photos != null)
                    Attach(userEntity.Photos).State = EntityState.Modified;
                
                await Save(cancellationToken);
            }
            else
            {
                throw new NotFoundException(nameof(user), user.Id);
                throw new InvalidUpdateException(nameof(user), user.Id);
            }
        }

        public async Task Delete(Core.Models.User user, CancellationToken cancellationToken = default)
        {
            if (user.Id <= 0
                || await Users.AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == user.Id, cancellationToken) == null)
            {
                throw new NotFoundException(nameof(user), user.Id);
            }

            var userEntity = _mapper.Map<Entities.User>(user);
            userEntity.Id = user.Id;

            Attach(userEntity).State = EntityState.Deleted;
            
            if (userEntity.Photos != null)
                Attach(userEntity.Photos).State = EntityState.Deleted;

            await Save(cancellationToken);
        }

        public async Task Save(CancellationToken cancellationToken = default)
        {
            await SaveChangesAsync(cancellationToken);
        }
    }
}
