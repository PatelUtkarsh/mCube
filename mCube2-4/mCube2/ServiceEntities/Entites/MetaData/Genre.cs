using System.Runtime.Serialization;

namespace mCube.Service.Entites.MetaData
{
	[DataContract]
	public class Genre
	{
		[DataMember]
		public int Id { get; set; }

		#region UnImportantPublicProperties

		[DataMember]
		public string Type { get; set; }

		[DataMember]
		public string Name { get; set; }

		#endregion

	}
}
