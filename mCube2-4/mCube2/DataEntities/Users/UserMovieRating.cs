using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mCube.DataEntities.MetaData;

namespace mCube.DataEntities.Users
{
	public class UserMovieRating
	{
		public int UserId { get; set; }

		public int MovieId { get; set; }


		public ushort Rating { get; set; }


		public virtual User User { get; set; }

		public virtual Movie Movie { get; set; }

	}
}
