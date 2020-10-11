using System;
using Raven.Client.Documents;

namespace Pegov.Nasvyazi.Persistence
{
    public static class DocumentStoreHolder
    {
        private static string _serverUrl = string.Empty;
        private static string _databaseName = string.Empty;

        public static void Create(string serverUrl, string databaseName)
        {
            if(string.IsNullOrEmpty(serverUrl))
                throw new ArgumentNullException(nameof(serverUrl));
            
            if(string.IsNullOrEmpty(databaseName))
                throw new ArgumentNullException(nameof(databaseName));
            
            _serverUrl = serverUrl;
            _databaseName = databaseName;
        }

        private static readonly Lazy<IDocumentStore> Store 
            = new Lazy<IDocumentStore>(CreateDocumentStore);

        private static IDocumentStore CreateDocumentStore()
        {
            IDocumentStore documentStore = new DocumentStore
            {
                Urls = new[] { _serverUrl },
                Database = _databaseName
            };

            documentStore.Initialize();
            return documentStore;
        }

        public static IDocumentStore DocumentStore => Store.Value;
    }
}