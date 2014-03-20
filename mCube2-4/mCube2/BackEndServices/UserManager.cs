using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using mCube.DataEntities;
using mCube.DataEntities.Users;
using mCube.Service.EntityConvertor;
using SEU = mCube.Service.Entites.Users;
using SE = mCube.Service.Entites;
//using User = mCube.DataEntities.Users.User;
//using VirtualGroup = mCube.DataEntities.Users.VirtualGroup;

namespace mCube.BackEndServices
{
	class DistinctMovieFileComparer:IEqualityComparer<UserCollectionItem>
	{
		#region Implementation of IEqualityComparer<in UserCollectionItem>

		public bool Equals(UserCollectionItem x, UserCollectionItem y)
		{
			return x.VideoFileId == y.VideoFileId;
		}

		public int GetHashCode(UserCollectionItem obj)
		{
			return obj.VideoFileId.GetHashCode();
		}

		#endregion
	}

	class DistinctMovieComparer:IEqualityComparer<UserCollectionItem>
	{
		#region Implementation of IEqualityComparer<in UserCollectionItem>

		public bool Equals(UserCollectionItem x, UserCollectionItem y)
		{
			return x.MovieId == y.MovieId;
		}

		public int GetHashCode(UserCollectionItem obj)
		{
			return obj.MovieId.GetHashCode();
		}

		#endregion
	}

	public class UserManager //Who deos the existance checking? Some is done by the inner scope, some needed outside! Assune User exists.
	{

		public int CreateNewUser(string firstName, string lastName, string password, string email)
		{
			var context = new mCubeDataContext();
			Database.SetInitializer(new mCubeDataContextInitializer());
			if(context.Users.Any(u => u.Email.Equals(email)))
			{
				return -1;
			}
			var newUser = new User() {FirstName = firstName, LastName = lastName, Password = password, Email = email};
			context.Users.Add(newUser);
			context.SaveChanges();
			context.Entry(newUser).Reload();
			return newUser.Id;
		}

		public int CreateVirtualGroup(string virtualGroupName, int userId) //Assume user exists
		{
			var context = new mCubeDataContext();
			var newVirtualGroup = new VirtualGroup() {Name = virtualGroupName};
			context.VirtualGroups.Add(newVirtualGroup);
			context.SaveChanges();
			context.Entry(newVirtualGroup).Reload();
			var newUserVirtualGroup = new UserVirtualGroup()
			                       	{IsUserOwner = true, UserId = userId, VirtualGroupId = newVirtualGroup.Id};
			context.UserVirtualGroups.Add(newUserVirtualGroup);
			context.SaveChanges();

			return newVirtualGroup.Id;
		}

		public bool AddUserToVirtualGroup(int ownerUserId, int virtualGroupId, int newMenberId) //Assume owner user and virtual group exists
		{
			var context = new mCubeDataContext();
			var userVirtualGroup =
				context.UserVirtualGroups.Single(uvg => (uvg.UserId == ownerUserId) && (uvg.VirtualGroupId == virtualGroupId));

			if (!userVirtualGroup.IsUserOwner)
			{
				return false;
			}

			context.UserVirtualGroups.Add(new UserVirtualGroup() {UserId = newMenberId, VirtualGroupId = virtualGroupId});
			context.SaveChanges();
			return true;
		}

		public List<SEU.MovieFiles> GetUsersMovieFile(IEnumerable<int> userIds)//Assume all users exist and their data acces is permisible.
		{
			var context = new mCubeDataContext();
			var collectionItems = context.UserCollection.Where(uc => userIds.Contains(uc.UserId));
			var distinctMovies = collectionItems.Distinct(new DistinctMovieComparer());

			var myMovieFiles = new List<SEU.MovieFiles>();

			foreach (var userCollectionItem in distinctMovies)
			{
				
				var mf = new SEU.MovieFiles() { MovieId = userCollectionItem.MovieId };

				myMovieFiles.Add(mf);
				
				var filesForMovie = collectionItems.Where(ci => ci.MovieId == mf.MovieId).Distinct(new DistinctMovieFileComparer());

				foreach (var fileForMovie in filesForMovie)
				{
					var file = DataToServiceConvertor.ConvertVideoFileToUserVideoFile(fileForMovie.VideoFile);
					mf.Files.Add(file);
					var userWithThisMovieFile =
						collectionItems.Where(ci => (ci.VideoFileId == file.VideoFileId && ci.MovieId == mf.MovieId));
					foreach (var collectionItem in userWithThisMovieFile)
					{
						file.Users.Add(DataToServiceConvertor.ConvertUser(collectionItem.User));
					}
				}
			}

			return myMovieFiles;
		}

		public void AddMovieFileToCollection(SE.VideoFileAttributes movieFileAttributes, int movieId, int userId)
		{
			var context = new mCubeDataContext();
			var existingFile = context.VideoFiles.Where(vf => vf.OpenSubtitlesHash == movieFileAttributes.OpenSubtitlesHash);
			if(!existingFile.Any())
			{
				var newFileInfo = ServiceToDataConvertor.ConvertVideoFile(movieFileAttributes);
				context.VideoFiles.Add(newFileInfo);
				context.SaveChanges();
				context.Entry(newFileInfo).Reload();
				context.UserCollection.Add(new UserCollectionItem() { MovieId = movieId, VideoFileId = newFileInfo.Id, UserId = userId });
			}
			else
			{
				context.UserCollection.Add(new UserCollectionItem() {MovieId = movieId, VideoFileId = existingFile.Single().Id,UserId = userId});
			}
			context.SaveChanges();

		}

	}
}
