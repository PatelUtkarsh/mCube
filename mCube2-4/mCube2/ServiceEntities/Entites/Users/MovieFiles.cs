using System.Collections.Generic;
using System.Runtime.Serialization;

namespace mCube.Service.Entites.Users
{
	[DataContract]
	public class MovieFiles
	{
		public MovieFiles()
		{
			Files = new List<UserVideoFileAttributes>();
		}


		[DataMember]
		public int MovieId { get; set; }
		[DataMember]
		public List<UserVideoFileAttributes> Files;
	}


}
