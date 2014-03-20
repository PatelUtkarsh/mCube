using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using mCube.DataEntities.MetaData;
using mCube.DataEntities.Users;

namespace mCube.DataEntities.Torrents
{
	public class Torrent //Make sure to update both UserTorrentRating and UserGood/Bad Rating. 
	{
		#region Keys

		public int Id { get; set; }

		public int MovieId { get; set; }

		//public int UserId { get; set; } Creater of torrent is not saved as of now. Will implement in next iteration.

		#endregion



		public string Url { get; set; }

		public int UserGoodRatings { get; set; }

		public int UserBadRatings { get; set; }

		[NotMapped]
		public int OverAllUserRating
		{
			get { return UserGoodRatings - UserGoodRatings; }
		}

		

		#region NavigationProperties

		//public virtual User User { get; set; }

		public virtual Movie Movie { get; set; }

		public virtual ICollection<UserTorrentRating> UserTorrentRatings { get; set; }

		#endregion



	}
}
