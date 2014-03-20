using System.Collections.Generic;
using System.Runtime.Serialization;

namespace mCube.Service.Entites.MetaData
{
	[DataContract]
	public class MovieInfo:Movie
	{
		#region MetaDataPublicProperties

		public MovieInfo()
		{
			Studios = new List<Studio>();
			Cast = new List<CastMember>();
		}

		[DataMember]
		public bool? Translated { get; set; }
		[DataMember]
		public bool Adult { get; set; }
		[DataMember]
		public string Language { get; set; }
		[DataMember]
		public string OriginalName { get; set; }
		[DataMember]
		public string AlternativeName { get; set; }
		[DataMember]
		public string ImdbId { get; set; }
		[DataMember]
		public string Votes { get; set; }
		[DataMember]
		public string Status { get; set; }
		[DataMember]
		public string Overview { get; set; }
		[DataMember]
		public string Released { get; set; }
		[DataMember]
		public string Runtime { get; set; }
		[DataMember]
		public string Budget { get; set; }
		[DataMember]
		public string Revenue { get; set; }
		[DataMember]
		public string Homepage { get; set; }
		[DataMember]
		public string Trailer { get; set; }

		#endregion

		[DataMember]
		public List<Studio> Studios { get; set; }
		[DataMember]
		public List<CastMember> Cast { get; set; }
	}
}
