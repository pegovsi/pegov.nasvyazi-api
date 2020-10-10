using Pegov.Nasvyazi.Application;
using Raven.Client.Documents;

namespace Pegov.Nasvyazi.Persistence
{
    public class RavenStore : IRavenStore
    {
        public IDocumentStore Create()
        {
            return DocumentStoreHolder.DocumentStore;
        }
    }
}