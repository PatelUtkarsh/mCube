using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using mCube.DataEntities.Torrents;

namespace mCube.DataEntities.Users
{
    public class User
    {
		[Key]
    	public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Password { get; set; }

		public string Email { get; set; }

		public virtual ICollection<UserMovieRating> UserMovieRatings { get; set; }

		public virtual ICollection<UserVirtualGroup> UserVirtualGroups { get; set;}

		//public virtual ICollection<Torrent> TorrentsCreated { get; set; } 

		//public virtual ICollection<VirtualGroup> VirtualGroupsCreated { get; set; } 
    }
}
