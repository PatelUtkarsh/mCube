using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using mCube.Service.Entites;
using mCube.Service.Entites.MetaData;
using mCube.Service.Entites.Users;


namespace mCube.Service
{
	
	public class mCubeService:ImCubeService
	{
		private int _userId;
		private bool _hasUserSessionBegun;
		

		#region MetaData

		public ContainerResult<Movie> GetMovieInfo(int movieId)
		{
			return new ContainerResult<Movie>(){Result = new Movie()};
		}

		public ContainerResult<List<Movie>> GetMultipleMovieInfo(List<int> movieIds)
		{
			throw new NotImplementedException();
		}

		public ContainerResult<MovieInfo> GetMovieDetailedInfo(int movieId)
		{
			throw new NotImplementedException();
		}

		public ContainerResult<Artist> GetArtistInfo(int artistId)
		{
			throw new NotImplementedException();
		}

		public ContainerResult<List<Artist>> GetMultipleArtistInfo(List<int> artistIds)
		{
			throw new NotImplementedException();
		}

		public ContainerResult<ArtistInfo> GetArtistDetailedInfo(int artistId)
		{
			throw new NotImplementedException();
		}

		public ContainerResult<List<Genre>> GetAllGenres()
		{
			throw new NotImplementedException();
		}

		public ContainerResult<int> MovieSearchQuery(string queryString)
		{
			throw new NotImplementedException();
		}

		public ContainerResult<List<int>> GetRecommendations(bool inMyCollection)
		{
			throw new NotImplementedException();
		} 

		#endregion

		#region VirtualGroup

		public ScalarResult CreateVirtualGroup(string virtualGroupName)
		{
			throw new NotImplementedException();
		}

		public ScalarResult AddMemberToVirtualGroupById(int userId)
		{
			throw new NotImplementedException();
		}

		public ScalarResult AddMemberToVirtualGroupByEmail(string email)
		{
			throw new NotImplementedException();
		}

		public ScalarResult DeleteVirtualGroup(int virtualGroupId)
		{
			throw new NotImplementedException();
		}

		public ContainerResult<List<VirtualGroup>> GetAllVirtualGroups()
		{
			throw new NotImplementedException();
		}

		public ContainerResult<List<MovieFiles>> GetMovieFilesByUserIds(List<int> userIds)
		{
			throw new NotImplementedException();
		} 

		#endregion

		#region UserCollection

		public ContainerResult<int> AddMovieToCollection(MovieFiles movieFiles)
		{
			throw new NotImplementedException();
		}

		public ScalarResult DeleteMovieFromCollection(int movieFileId)
		{
			throw new NotImplementedException();
		} 

		#endregion

		#region Torrent

		public ScalarResult AddTorrent(int movieId, string torrentUri)
		{
			throw new NotImplementedException();
		}

		public ScalarResult TorrentVoteUp(int torrentId)
		{
			throw new NotImplementedException();
		}

		public ScalarResult TorrentVoteDown(int torrentId)
		{
			throw new NotImplementedException();
		}

		public ContainerResult<List<TorrentURI>> GetTorrentForMovie(int movieId)
		{
			throw new NotImplementedException();
		} 

		#endregion

		#region User

		public ContainerResult<int> CreateNewUser(string firstName, string lastName, string password, string email)
		{
			throw new NotImplementedException();
		}

		public ScalarResult NewUserSession(int userId)
		{
			throw new NotImplementedException();
		} 

		#endregion

		private int num;
		public int ZZZZGetNumber()
		{
			return num++;
		}

	}
}
