using System.Collections.Generic;
using System.Runtime.Serialization;

namespace mCube.Service.Entites.MetaData
{
	[DataContract]
	public class Artist
	{
		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public string Name { get; set; }
		[DataMember]
		public List<Image> Images { get; set; }


		#region UnImportantPublicProperties
		[DataMember]
		public string Score { get; set; }
		[DataMember]
		public string Popularity { get; set; }

		#endregion

	}
}
