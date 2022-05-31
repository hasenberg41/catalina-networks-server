﻿using CatalinaNetworks.Core.Exceptions;
using CatalinaNetworks.Core.Repositories;
using CatalinaNetworks.DataBase.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace CatalinaNetworks.DataBase
{
    public class UsersDbContext : DbContext, IRepository<Core.Models.User>
    {// TODO : Реализовать интерфейс и написать тесты
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

        public Task Update(Core.Models.User user, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Core.Models.User user, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task Save(CancellationToken cancellationToken = default)
        {
            await SaveChangesAsync(cancellationToken);
        }
    }
}
