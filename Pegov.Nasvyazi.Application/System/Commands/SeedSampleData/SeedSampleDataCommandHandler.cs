using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pegov.Nasvyazi.Application.Common.Interfaces;

namespace Pegov.Nasvyazi.Application.System.Commands.SeedSampleData
{
    public class SeedSampleDataCommand : IRequest {}

    public class SeedSampleDataCommandHandler : IRequestHandler<SeedSampleDataCommand, Unit>
    {
        private readonly IAppDbContext _context;

        public SeedSampleDataCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(SeedSampleDataCommand request, CancellationToken cancellationToken)
        {
            var seeder = new SampleDataSeeder(_context);
            await seeder.SeedAllAsync(cancellationToken);
            return Unit.Value;
        }
    }
}