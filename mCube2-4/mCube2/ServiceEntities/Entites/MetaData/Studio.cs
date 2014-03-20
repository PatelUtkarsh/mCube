using System.Runtime.Serialization;

namespace mCube.Service.Entites.MetaData
{
	[DataContract]
	public class Studio
	{
		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public string Name { get; set; }

	}
}
