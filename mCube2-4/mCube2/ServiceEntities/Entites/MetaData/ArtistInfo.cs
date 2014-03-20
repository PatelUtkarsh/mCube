using System.Collections.Generic;
using System.Runtime.Serialization;

namespace mCube.Service.Entites.MetaData
{
	[DataContract]
	public class ArtistInfo:Artist
	{
		[DataMember]
		public string Biography { get; set; }
		[DataMember]
		public int KnownMovies { get; set; }
		[DataMember]
		public string Birthplace { get; set; }
		[DataMember]
		public List<CastMember> MoviesByThis { get; set; } //int represents the movie Id
	}
}
