using System;
using System.Collections.Generic;
using Pegov.Nasvyazi.Domains.Entities.Organizations;
using Pegov.Nasvyazi.Domains.Common;
using Pegov.Nasvyazi.Domains.Entities.Accounts.Notifications;
using Pegov.Nasvyazi.Domains.Entities.Chats;
using Pegov.Nasvyazi.Domains.Entities.Groups;
using Pegov.Nasvyazi.Domains.Entities.Positions;
using Pegov.Nasvyazi.Domains.Enumerations;

namespace Pegov.Nasvyazi.Domains.Entities.Accounts
{
    public class Account : Entity, IAggregateRoot
    {
        #region Constructor

        protected Account()
        {
            Id = Guid.NewGuid();
            _accountStatusId = AccountStatus.Active.Id;
            _accountOrganizations = new List<AccountOrganization>();
            _accountPositions = new List<AccountPosition>();
            _accountChats = new List<AccountChat>();
            _groups = new List<Group>();

            AccountCreated();
        }

        public Account(string firstName, string lastName, string email, string phone)
            :this()
        {
            FirstName = firstName;
            LastName = lastName;
            Email = new EmailValueObject(email);
            Phone = new PhoneValueObject(phone);
        }
        
        #endregion

        #region Property
        
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public EmailValueObject Email { get; protected set; }
        public PhoneValueObject Phone { get; protected set; }

        private int _accountStatusId;
        public AccountStatus AccountStatus { get; protected set; }

        private readonly List<AccountOrganization> _accountOrganizations;
        public IReadOnlyCollection<AccountOrganization> Organization => _accountOrganizations;

        private readonly List<AccountPosition> _accountPositions;
        public IReadOnlyCollection<AccountPosition> Positions => _accountPositions;

        private List<AccountChat> _accountChats;
        public IReadOnlyCollection<AccountChat> Chats => _accountChats;

        private List<Group> _groups;
        public IReadOnlyCollection<Group> Groups => _groups;

        #endregion

        #region Logic

        public void AddOrganization(Guid organizationId)
        {
            var organization = new AccountOrganization
            {
                AccountId = Id,
                OrganizationId = organizationId
            };
            _accountOrganizations.Add(organization);
        }
        public void AddOrganization(IEnumerable<Guid> organizationIds)
        {
            foreach (var organizationId in organizationIds)
            {
                var organization = new AccountOrganization
                {
                    AccountId = Id,
                    OrganizationId = organizationId
                };
                _accountOrganizations.Add(organization);   
            }
        }
        public void AddPosition(Guid positionId)
        {
            var position = new AccountPosition
            {
                AccountId = Id,
                PositionId = positionId
            };
            _accountPositions.Add(position);
        }
        public void AddPosition(IEnumerable<Guid> positionIds)
        {
            foreach (var positionId in positionIds)
            {
                var position = new AccountPosition
                {
                    AccountId = Id,
                    PositionId = positionId
                };
                _accountPositions.Add(position);   
            }
        }
        
        public void Delete()
        {
            _accountStatusId = AccountStatus.Deleted.Id;
        }
        public void Recovery()
        {
            _accountStatusId = AccountStatus.Active.Id;
        }
        public void Block()
        {
            _accountStatusId = AccountStatus.Blocked.Id;
        }
        
        #endregion

        #region Events

        private void AccountCreated()
        {
            var notification = new AccountCreatedDomainEvent(Id);
            base.AddDomainEvent(notification);
        }


        #endregion
    }
}