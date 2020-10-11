using AutoMapper;
using Pegov.Nasvyazi.Domains.Entities.Accounts;
using Pegov.Nasvyazi.Domains.Entities.Organizations;
using Pegov.Nasvyazi.Application.Buisness.Accounts.Queries.Models;
using Pegov.Nasvyazi.Application.Buisness.Organization.Queries.Models;

namespace Pegov.Nasvyazi.Application.Common
{
    public class MiscProfile : Profile
    {
        public MiscProfile()
        {
            CreateMap<Organization, OrganizationDto>();
            CreateMap<Account, AccountDto>();
        }   
    }
}