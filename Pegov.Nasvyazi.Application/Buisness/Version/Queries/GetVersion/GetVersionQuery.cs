using MediatR;

namespace Pegov.Nasvyazi.Application.Buisness.Version.Queries.GetVersion
{
    public class GetVersionQuery : IRequest<string>
    {
        public GetVersionQuery()
        {
        }
        public static GetVersionQuery Create()
        {
            return new GetVersionQuery(); 
        }
    }
}