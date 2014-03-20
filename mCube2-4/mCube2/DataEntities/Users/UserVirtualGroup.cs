using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mCube.DataEntities.Users
{
	public class UserVirtualGroup
	{
		public int UserId { get; set; }

		public int VirtualGroupId { get; set; }

		public bool IsUserOwner { get; set; }

		public virtual User User { get; set; }

		public virtual VirtualGroup VirtualGroup { get; set; }
	}
}
