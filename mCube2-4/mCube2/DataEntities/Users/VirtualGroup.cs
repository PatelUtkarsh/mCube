using System.Collections.Generic;

namespace mCube.DataEntities.Users
{
	public class VirtualGroup
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public virtual ICollection<UserVirtualGroup> UserVirtualGroups { get; set; }
	}
}
