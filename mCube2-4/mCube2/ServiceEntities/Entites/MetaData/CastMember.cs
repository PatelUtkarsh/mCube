using System.Runtime.Serialization;

namespace mCube.Service.Entites.MetaData
{
	[DataContract]
	public class CastMember
	{
		[DataMember]
		public int ArtistId { get; set; }

		[DataMember]
		public int MovieId { get; set; }

		[DataMember]
		public int CastId { get; set; }

		[DataMember]
		public string Name { get; set; } // to be removed??

		[DataMember]
		public string Character { get; set; }

		[DataMember]
		public string Job { get; set; }

		[DataMember]
		public string Profile { get; set; }

		[DataMember]
		public string Department { get; set; }

		[DataMember]
		public int Order { get; set; }

	}
}
