using System.Runtime.Serialization;

namespace mCube.Service.Entites
{
	[DataContract]
	public class TorrentURI
	{
		[DataMember]
		public int TorrentID { get; set; }
		[DataMember]
		public string TorrentUri { get; set; }
		[DataMember]
		public bool? UserRating { get; set; } //User specific
		[DataMember]
		public int Rating { get; set; }
	}
}
