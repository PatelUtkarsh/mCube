using System.Collections.Generic;
using System.Runtime.Serialization;

namespace mCube.Service.Entites.MetaData
{
	[DataContract]
	public class Movie 
	{
		public Movie()
		{
			Images = new List<Image>();
			Genres = new List<Genre>();
		}

		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public string Name { get; set; }
		[DataMember]
		public int UserRating { get; set; } //User specific

		#region MetaDataPublicProperties
		[DataMember]
		public string Popularity { get; set; }
		[DataMember]
		public string Type { get; set; }
		[DataMember]
		public string Rating { get; set; }
		[DataMember]
		public string Tagline { get; set; }
		[DataMember]
		public string Certification { get; set; }

		#endregion

		[DataMember]
		public List<Image> Images { get; set; }
		[DataMember]
		public List<Genre> Genres { get; set; }
	}
}
