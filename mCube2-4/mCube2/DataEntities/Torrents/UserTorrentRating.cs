using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mCube.DataEntities.Users;

namespace mCube.DataEntities.Torrents
{
	public class UserTorrentRating
	{
		public int UserId { get; set; }

		public int TorrentId { get; set; }


		public bool UpOrDown { get; set; }


		public virtual User User { get; set; }

		public virtual Torrent Torrent { get; set; }
	}
}
