using SklepServiceConnection;

namespace Sklep.Mobile.Services
{
 
        public class AbstractDataStore
        {
            protected sklepServiceConnectionReference sklepServiceConnectionReference;
            public AbstractDataStore()
            {
                sklepServiceConnectionReference = new sklepServiceConnectionReference("https://localhost:7046", new System.Net.Http.HttpClient());
            }
        }
    }
