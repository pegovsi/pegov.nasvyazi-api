using pegov.nasvayzi.Domains.Common;

namespace pegov.nasvayzi.Domains.Entities.Organizations
{
    public class Organization : Entity, IAggregateRoot
    {
        protected Organization()
        {
            Id = NewGuidString();
        }

        public Organization(string name, string inn, string kpp)
            :this()
        {
            Name = name;
            Inn = inn;
            Kpp = kpp;
        }


        public override string Id { get; protected set; }
        
        public string Name { get; protected set; }
        public string Inn { get; protected set; }
        public string Kpp { get; protected set; }
        
    }
}