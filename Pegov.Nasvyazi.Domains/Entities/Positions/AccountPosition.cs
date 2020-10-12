using System;
using Pegov.Nasvyazi.Domains.Entities.Accounts;

namespace Pegov.Nasvyazi.Domains.Entities.Positions
{
    public class AccountPosition
    {
        public Guid AccountId { get; set; }
        public Account Account { get; set; }

        public Guid PositionId { get; set; }
        public Position Position { get; set; }
    }
}