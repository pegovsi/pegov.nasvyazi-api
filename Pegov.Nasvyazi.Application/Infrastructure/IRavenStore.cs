using Raven.Client.Documents;

namespace Pegov.Nasvyazi.Application
{
    public interface IRavenStore
    {
        IDocumentStore Create();
    }
}