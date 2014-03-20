using System.Collections.Generic;
using System.ServiceModel;
using mCube.Service.Entites;
using mCube.Service.Entites.MetaData;
using mCube.Service.Entites.Users;

namespace mCube.Service
{
	[ServiceContract(SessionMode = SessionMode.Required)]
	public interface ImCubeService
	{

		#region TestFunctions

		[OperationContract]
		int ZZZZGetNumber();
		#endregion


		#region MetaData

		[OperationContract]
		ContainerResult<Movie> GetMovieInfo(int movieId);

		[OperationContract]
		ContainerResult<List<Movie>> GetMultipleMovieInfo(List<int> movieIds);

		[OperationContract]
		ContainerResult<MovieInfo> GetMovieDetailedInfo(int movieId);

		[OperationContract]
		ContainerResult<Artist> GetArtistInfo(int artistId);

		[OperationContract]
		ContainerResult<List<Artist>> GetMultipleArtistInfo(List<int> artistIds);

		[OperationContract]
		ContainerResult<ArtistInfo> GetArtistDetailedInfo(int artistId);

		[OperationContract]
		ContainerResult<List<Genre>> GetAllGenres();






		[OperationContract]
		ContainerResult<int> MovieSearchQuery(string queryString);

		[OperationContract]
		ContainerResult<List<int>> GetRecommendations(bool inMyCollection);

		#endregion

		#region VirtualGroups

		[OperationContract]
		ScalarResult CreateVirtualGroup(string virtualGroupName);

		[OperationContract]
		ScalarResult AddMemberToVirtualGroupById(int userId);

		[OperationContract]
		ScalarResult AddMemberToVirtualGroupByEmail(string email);

		[OperationContract]
		ScalarResult DeleteVirtualGroup(int virtualGroupId);

		[OperationContract]
		ContainerResult<List<VirtualGroup>> GetAllVirtualGroups();

		[OperationContract]
		ContainerResult<List<MovieFiles>> GetMovieFilesByUserIds(List<int> userIds);

		#endregion

		#region UserCollection

		[OperationContract]
		ContainerResult<int> AddMovieToCollection(MovieFiles movieFiles); //Return the id of a movie file in db.

		[OperationContract]
		ScalarResult DeleteMovieFromCollection(int movieFileId);

		#endregion

		#region Torrent

		[OperationContract]
		ScalarResult AddTorrent(int movieId, string torrentUri);

		[OperationContract]
		ScalarResult TorrentVoteUp(int torrentId);

		[OperationContract]
		ScalarResult TorrentVoteDown(int torrentId);

		[OperationContract]
		ContainerResult<List<TorrentURI>> GetTorrentForMovie(int movieId);

		#endregion

		#region User

		[OperationContract]
		ContainerResult<int> CreateNewUser(string firstName, string lastName, string password, string email);

		[OperationContract]
		ScalarResult NewUserSession(int userId);

		#endregion

	}
}