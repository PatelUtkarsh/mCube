using System.Runtime.Serialization;

namespace mCube.Service.Entites
{
	[DataContract]
	public class VideoAttribute
	{
		[DataMember]
		public string CodecId { get; set; }
		[DataMember]
		public string Format { get; set; }
		[DataMember]
		public ushort BitRate { get; set; } // in Kbps
		[DataMember]
		public ushort Height { get; set; }
		[DataMember]
		public ushort Widht { get; set; }
		[DataMember]
		public float Fps { get; set; }
	}
}
