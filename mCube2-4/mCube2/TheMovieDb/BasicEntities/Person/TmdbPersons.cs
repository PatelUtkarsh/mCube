using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TheMovieDb.BasicEntities.Person
{
    [CollectionDataContract]
    public class TmdbPersons : List<TmdbPerson>
    {
        public TmdbPersons() { }
        public TmdbPersons(IEnumerable<TmdbPerson> persons) : base(persons) { }
    }
}
