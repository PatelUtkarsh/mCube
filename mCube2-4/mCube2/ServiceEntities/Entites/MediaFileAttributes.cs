using System.Runtime.Serialization;

namespace mCube.Service.Entites
{
	[DataContract]
	public abstract class MediaFileAttributes
	{
		[DataMember]
		public float FileSize { get; set; } // in MB s
		[DataMember]
		public string FileName { get; set; }
		[DataMember]
		public string Extension { get; set; }
	}
}
