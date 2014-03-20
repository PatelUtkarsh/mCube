using System.Collections.Generic;
using System.Runtime.Serialization;

namespace mCube.Service.Entites.Users
{
	[DataContract]
	public class VirtualGroup
	{
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public virtual List<User> Users { get; set; }

		[DataMember]
		public bool IsUserOwner { get; set; }
	}
}
