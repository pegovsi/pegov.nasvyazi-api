using Pegov.Nasvyazi.Application;
using Raven.Client.Documents;

namespace Pegov.Nasvyazi.Persistence
{
    public class RavenStore : IRavenStore
    {
        private RavenOptions _options;
        public RavenStore(RavenOptions options)
        {
            _options = options;
        }
        public IDocumentStore Create()
        {
            DocumentStoreHolder.Create(_options.ServerUrl, _options.Database);
            return DocumentStoreHolder.DocumentStore;
        }
    }

    public class RavenOptions
    {
        public string ServerUrl { get; set; }
        public string Database { get; set; }
    }
}