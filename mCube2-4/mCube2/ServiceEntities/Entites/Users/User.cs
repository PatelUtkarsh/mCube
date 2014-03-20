using System.Runtime.Serialization;

namespace mCube.Service.Entites.Users
{
	[DataContract]
	public class User
	{
		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public string FirstName { get; set; }
		[DataMember]
		public string LastName { get; set; }

		[DataMember]
		public string Email { get; set; }
	}
}
