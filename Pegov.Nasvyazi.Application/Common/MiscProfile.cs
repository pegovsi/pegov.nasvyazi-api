using AutoMapper;
using Pegov.Nasvayzi.Application.Buisness.Accounts.Queries.Models;
using Pegov.Nasvayzi.Application.Buisness.Organization.Queries.Models;
using pegov.nasvayzi.Domains.Entities.Accounts;
using pegov.nasvayzi.Domains.Entities.Organizations;

namespace pegov.nasvayzi.Application.Common
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