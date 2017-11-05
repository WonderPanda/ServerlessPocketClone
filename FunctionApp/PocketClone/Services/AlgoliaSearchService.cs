using Algolia.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketClone.Services
{
    public class AlgoliaSearchService
    {
        private readonly string _appId;
        private readonly string _authKey;
        private readonly string _indexName;

        private readonly AlgoliaClient _client;
        private readonly Index _index;

        public AlgoliaSearchService(string appId, string authKey, string indexName)
        {
            _appId = appId;
            _authKey = authKey;
            _indexName = indexName;
            
            _client = new AlgoliaClient(appId, authKey);
            _index = _client.InitIndex(indexName);
        }
    }
}
