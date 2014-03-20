using System.Runtime.Serialization;

namespace TheMovieDb.BasicEntities.Images
{
    [DataContract]
    public class TmdbImage
    {
        [DataMember(Name="image")]
        public TmdbImageInfo ImageInfo { get; set; }
    }
}
