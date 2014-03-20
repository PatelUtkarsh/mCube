using System.Runtime.Serialization;

namespace TheMovieDb.BasicEntities.Images
{
    [DataContract(Name = "poster")]
    public class TmdbPoster
    {
        [DataMember(Name = "image")]
        public TmdbImageInfo TmdbImageInfo { get; set; }
    }
}
