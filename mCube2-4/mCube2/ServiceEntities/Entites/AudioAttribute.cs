using System.Runtime.Serialization;

namespace mCube.Service.Entites
{
	[DataContract]
	public class AudioAttribute
	{
		[DataMember]
		public string Format { get; set; }
		[DataMember]
		public string Codec { get; set; }
		[DataMember]
		public byte Channels { get; set; }
		[DataMember]
		public string SamplingRate { get; set; }
		[DataMember]
		public string Language { get; set; }
	}
}
