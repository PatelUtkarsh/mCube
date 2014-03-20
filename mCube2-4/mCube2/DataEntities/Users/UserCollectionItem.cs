using mCube.DataEntities.Files;
using mCube.DataEntities.MetaData;

namespace mCube.DataEntities.Users
{
	public class UserCollectionItem
	{
		public int UserId { get; set; }
		public int VideoFileId { get; set; }
		public int MovieId { get; set; }

		public virtual User User { get; set; }
		public virtual VideoFile VideoFile { get; set; }
		public virtual Movie Movie { get; set; } 
		
	}
}
