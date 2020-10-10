using System;
using Raven.Client.Documents;

namespace Pegov.Nasvyazi.Persistence
{
    public static class DocumentStoreHolder
    {
        private static readonly Lazy<IDocumentStore> Store 
            = new Lazy<IDocumentStore>(CreateDocumentStore);

        private static IDocumentStore CreateDocumentStore()
        {
            string serverURL = "http://192.168.1.44:8080";
            string databaseName = "TestDB";

            IDocumentStore documentStore = new DocumentStore
            {
                Urls = new[] {serverURL},
                Database = databaseName
            };

            documentStore.Initialize();
            return documentStore;
        }

        public static IDocumentStore DocumentStore => Store.Value;
    }
}