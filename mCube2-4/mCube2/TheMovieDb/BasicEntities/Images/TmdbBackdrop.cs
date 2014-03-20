using System.Runtime.Serialization;

namespace TheMovieDb.BasicEntities.Images
{
    [DataContract(Name = "backdrop")]
    public class TmdbBackdrop
    {
        [DataMember(Name = "image")]
        public TmdbImageInfo TmdbImageInfo { get; set; }
    }
}
