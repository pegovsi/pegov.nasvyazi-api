using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Pegov.Nasvyazi.Application.Common.Extension;
using Pegov.Nasvyazi.Domains.Common;
using Pegov.Nasvyazi.Domains.Entities.Accounts;
using Pegov.Nasvyazi.Domains.Entities.Organizations;
using Pegov.Nasvyazi.Application.Common.Interfaces;
using Pegov.Nasvyazi.Domains.Entities.Groups;
using Pegov.Nasvyazi.Domains.Entities.Positions;
using Pegov.Nasvyazi.Domains.Enumerations;

namespace Pegov.Nasvyazi.Persistence.Postgres
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        private readonly IMediator _mediator;
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options,
            IMediator mediator)
            : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Position> Positions { get; set; }

        public DbSet<AccountStatus> AccountStatuses { get; set; }
        public DbSet<EntityStatus> EntityStatuses { get; set; }
        public DbSet<ChatStatus> ChatStatuses { get; set; }
        public DbSet<ChatType> ChatTypes { get; set; }
        public DbSet<GroupType> GroupTypes { get; set; }

        public DbContext DbContext => this;
        public System.Data.Common.DbConnection DbConnection => Database.GetDbConnection();

        //public DbSet<UserMasterDataFieldView> UserMasterDataFieldView { get; set; }


        public async Task<int> ExecuteSqlRawAsync(string sql, CancellationToken token = default)
        {
            return await base.Database.ExecuteSqlRawAsync(sql, token);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder
            //     .Entity<UserMasterDataFieldView>()
            //     .ToView(Domain.Views.UserMasterDataFieldView.View)
            //     .HasNoKey();

            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //var currentUser = _currentUserService.GetCurrentUser();
            var dateTime = DateTime.Now;
            foreach (var entry in ChangeTracker.Entries<Entity>())
            {
                UpdateState(entry);

                switch (entry.State)
                {
                    case EntityState.Added:
                       // entry.Entity.CreatedBy = currentUser.Id.ToString();
                        entry.Entity.Created = dateTime;
                        break;
                    case EntityState.Modified:
                       // entry.Entity.ModifiedBy = currentUser.Id.ToString();
                        entry.Entity.Modified = dateTime;
                        break;
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            // Не посылаем события во время тестов
            if (Database.IsNpgsql())
            {
                await DispatchDomainEventsAsync();
            }

            return result;
        }

        private static void UpdateState(EntityEntry<Entity> entry)
        {
            if (entry.Entity.IsNew)
            {
                entry.State = EntityState.Added;
            }
        }

        private async Task DispatchDomainEventsAsync()
        {
            var domainEntities = ChangeTracker
               .Entries<Entity>()
               .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());
            await _mediator.DispatchDomainEventsAsync(domainEntities);
        }
    }
}
