using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheMovieDb;
using TheMovieDb.BasicEntities;
using mCube.DataEntities;
using mCube.DataEntities.MetaData;

namespace mCube.BackEndServices
{
    public class SearchEngine //In the service, each call should have a new instance.
    {
        public IEnumerable<Movie> SearchStoreReturn(string query)
        {
        	var resultIds = MetaDataDbBridge.GetMoviesByQuery(query);
        	return resultIds.Select(MetaDataDbBridge.GetMoviesFromDbById).ToList();
        }
    }
}
