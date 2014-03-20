using System.Collections.Generic;
using System.Runtime.Serialization;

namespace mCube.Service.Entites.Users
{
	[DataContract]
	public class UserVideoFileAttributes:VideoFileAttributes
	{
		public UserVideoFileAttributes()
		{
			Users = new List<User>();
		}

		[DataMember]
		public int VideoFileId { get; set; }

		[DataMember]
		public List<User> Users { get; set; }
	}
}
