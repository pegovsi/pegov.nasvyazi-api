namespace Pegov.Nasvayzi.Common
{
    public interface ICurrentUserService
    {
        ICurrentUser GetCurrentUser();
        ICurrentUser CreateUserByToken(string jwt);
    }
    public interface ICurrentUser
    {
        string Login { get; }
        string FirstName { get; }
        string LastName { get; }
        string MiddleName { get; }
        long Id { get; }
        long? OrganizationId { get; }
        string SecurityToken { get; }
        string[] Roles { get; }
    }
    public class CurrentUser : ICurrentUser
    {
        public string Login { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string MiddleName { get; private set; }
        public long Id { get; private set; }
        public long? OrganizationId { get; private set; }
        public string SecurityToken { get; private set; }
        public string[] Roles { get; private set; }

        public CurrentUser(string login, string firstName, string lastName, string middleName, long id, long? organizationId, string securityToken, string[] roles)
        {
            Login = login;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Id = id;
            OrganizationId = organizationId;
            SecurityToken = securityToken;
            Roles = roles;
        }

        public static CurrentUser Create(string login, string firstName, string lastName, string middleName, long id, long? organizationId, string securityToken, string[] roles)
            => new CurrentUser(login, firstName, lastName, middleName, id, organizationId, securityToken, roles);
    }
}