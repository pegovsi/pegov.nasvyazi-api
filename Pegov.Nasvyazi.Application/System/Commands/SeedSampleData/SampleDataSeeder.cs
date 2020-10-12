using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pegov.Nasvyazi.Application.Common.Interfaces;
using Pegov.Nasvyazi.Domains.Entities.Chats;
using Pegov.Nasvyazi.Domains.Enumerations;

namespace Pegov.Nasvyazi.Application.System.Commands.SeedSampleData
{
    public class SampleDataSeeder
    {
        private readonly IAppDbContext _context;

        public SampleDataSeeder(IAppDbContext context)
        {
            _context = context;
        }

        public async Task SeedAllAsync(CancellationToken token)
        {
            var chat = new Chat(ChatType.Personal);
            chat.SetName("4546");
            chat.SetLogo("/stage/chat-logo/chat-id-32165489845");
            chat.AddAccount(Guid.NewGuid());
            
            await SeedAccountStatusAsync(token);
            await SeedChatStatusAsync(token);
            await SeedEntityStatusAsync(token);
            await SeedGroupTypesAsync(token);
        }
        
        private async Task SeedAccountStatusAsync(CancellationToken token)
        {
            var statuses = await _context
                .DbContext
                .Set<AccountStatus>()
                .ToListAsync(token);

            if (!statuses.Any())
            {
                statuses = new List<AccountStatus>
                {
                    AccountStatus.Active,
                    AccountStatus.Blocked,
                    AccountStatus.Deleted
                };

                await _context
                    .DbContext
                    .Set<AccountStatus>()
                    .AddRangeAsync(statuses, token);

                await _context.SaveChangesAsync(token);
            }
        }
        private async Task SeedChatStatusAsync(CancellationToken token)
        {
            var statuses = await _context
                .DbContext
                .Set<ChatStatus>()
                .ToListAsync(token);

            if (!statuses.Any())
            {
                statuses = new List<ChatStatus>
                {
                    ChatStatus.Active,
                    ChatStatus.Blocked,
                    ChatStatus.Archive
                };

                await _context
                    .DbContext
                    .Set<ChatStatus>()
                    .AddRangeAsync(statuses, token);

                await _context.SaveChangesAsync(token);
            }
        }
        private async Task SeedEntityStatusAsync(CancellationToken token)
        {
            var statuses = await _context
                .DbContext
                .Set<EntityStatus>()
                .ToListAsync(token);

            if (!statuses.Any())
            {
                statuses = new List<EntityStatus>
                {
                    EntityStatus.Active,
                    EntityStatus.Deleted
                };

                await _context
                    .DbContext
                    .Set<EntityStatus>()
                    .AddRangeAsync(statuses, token);

                await _context.SaveChangesAsync(token);
            }
        }
        private async Task SeedGroupTypesAsync(CancellationToken token)
        {
            var statuses = await _context
                .DbContext
                .Set<GroupType>()
                .ToListAsync(token);

            if (!statuses.Any())
            {
                statuses = new List<GroupType>
                {
                    GroupType.System,
                    GroupType.Manual
                };

                await _context
                    .DbContext
                    .Set<GroupType>()
                    .AddRangeAsync(statuses, token);

                await _context.SaveChangesAsync(token);
            }
        }
    }
}