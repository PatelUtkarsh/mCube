using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SE = mCube.Service.Entites;
using SEM = mCube.Service.Entites.MetaData;
using DE = mCube.DataEntities;
using DEM = mCube.DataEntities.MetaData;

namespace mCube.Service.EntityConvertor
{
	public static class DataToServiceConvertor //Carefull, the parameters are attached to a context.
	{
		public static SEM.Movie ConvertMovie(DEM.Movie dataMovie, SEM.Movie serviceMovie = null)
		{

			if(serviceMovie == null)
			{
				serviceMovie = new SEM.Movie();
			}
			serviceMovie.Certification = dataMovie.Certification;
			serviceMovie.Id = dataMovie.Id;
			serviceMovie.Name = dataMovie.Name;
			serviceMovie.Popularity = dataMovie.Popularity;
			serviceMovie.Rating = dataMovie.Rating;
			serviceMovie.Tagline = dataMovie.Tagline;
			serviceMovie.Type = dataMovie.Type;

			//serviceMovie.UserRating  ????

			foreach (var genre in dataMovie.Genres)
			{
				serviceMovie.Genres.Add(ConvertGenre(genre));
			}

			foreach (var movieImage in dataMovie.MovieImages)
			{
				serviceMovie.Images.Add(ConvertImage(movieImage));
			}

			return serviceMovie;

		}

		public static SEM.MovieInfo ConvertMovieInfo(DEM.Movie dataMovie)
		{
			var serviceMovieInfo = new SEM.MovieInfo();
			ConvertMovie(dataMovie, serviceMovieInfo);

			serviceMovieInfo.Adult = dataMovie.Adult;
			serviceMovieInfo.AlternativeName = dataMovie.AlternativeName;
			serviceMovieInfo.Budget = dataMovie.Budget;
			serviceMovieInfo.Homepage = dataMovie.Homepage;
			serviceMovieInfo.ImdbId = dataMovie.ImdbId;
			serviceMovieInfo.Language = dataMovie.Language;
			serviceMovieInfo.OriginalName = dataMovie.OriginalName;
			serviceMovieInfo.Overview = dataMovie.Overview;
			serviceMovieInfo.Released = dataMovie.Released;
			serviceMovieInfo.Revenue = dataMovie.Revenue;
			serviceMovieInfo.Runtime = dataMovie.Runtime;
			serviceMovieInfo.Status = dataMovie.Status;
			serviceMovieInfo.Trailer = dataMovie.Trailer;
			serviceMovieInfo.Translated = dataMovie.Translated;


			//serviceMovieInfo.Votes = dataMovie.Votes; ??

			foreach (var studio in dataMovie.Studios)
			{
				serviceMovieInfo.Studios.Add(ConvertStudio(studio));
			}

			foreach (var castMember in dataMovie.Cast)
			{
				serviceMovieInfo.Cast.Add(ConvertCastMember(castMember));
			}

			return serviceMovieInfo;

		}

		private static SEM.Genre ConvertGenre(DEM.Genre dataGenre)
		{
			var serviceGenre = new SEM.Genre();

			serviceGenre.Id = dataGenre.Id;
			serviceGenre.Name = dataGenre.Name;
			serviceGenre.Type = dataGenre.Type;

			return serviceGenre;
		}

		private static SEM.CastMember ConvertCastMember(DEM.CastMember dataCastMember)
		{
			var serviceCastMember = new SEM.CastMember();

			serviceCastMember.ArtistId = dataCastMember.ArtistId;
			serviceCastMember.CastId = dataCastMember.CastId;
			serviceCastMember.Character = dataCastMember.Character;
			serviceCastMember.Department = dataCastMember.Department;
			serviceCastMember.Job = dataCastMember.Job;
			serviceCastMember.MovieId = dataCastMember.MovieId;
			serviceCastMember.Order = dataCastMember.Order;
			serviceCastMember.Profile = dataCastMember.Profile;

			//serviceCastMember.Name ??

			return serviceCastMember;
		}

		private static SEM.Studio ConvertStudio(DEM.Studio dataStudio)
		{
			var serviceStudio = new SEM.Studio();

			serviceStudio.Id = dataStudio.Id;
			serviceStudio.Name = dataStudio.Name;

			return serviceStudio;
		}

		private static SEM.Image ConvertImage(DEM.Image dataImage)
		{
			var serviceImage = new SEM.Image();

			serviceImage.Height = dataImage.Height;
			serviceImage.Width = dataImage.Width;
			serviceImage.Id = dataImage.TmdbId;
			serviceImage.Size = dataImage.Size;
			serviceImage.Type = dataImage.Type;
			serviceImage.Url = dataImage.Url;

			return serviceImage;
		}


		public static SE.Users.UserVideoFileAttributes ConvertVideoFileToUserVideoFile(DE.Files.VideoFile dataVideoFile)
		{
			var serviceUserVideoFileAttributes = new SE.Users.UserVideoFileAttributes();
			ConvertVideoFileAttributes(dataVideoFile, serviceUserVideoFileAttributes);
			return serviceUserVideoFileAttributes;
		}

		private static SE.VideoFileAttributes ConvertVideoFileAttributes(DE.Files.VideoFile dataVideoFile, SE.VideoFileAttributes serviceVideoFile=null)
		{
			if (serviceVideoFile==null)
			{
				serviceVideoFile = new SE.VideoFileAttributes(); 
			}

			serviceVideoFile.AudioCount = dataVideoFile.AudioCount;
			serviceVideoFile.Duration = dataVideoFile.Duration;
			serviceVideoFile.Extension = dataVideoFile.Extension;
			serviceVideoFile.FileName = dataVideoFile.FileName;
			serviceVideoFile.Format = dataVideoFile.Format;
			serviceVideoFile.OpenSubtitlesHash = dataVideoFile.OpenSubtitlesHash;
			serviceVideoFile.OverallBitrate = dataVideoFile.OverallBitrate;
			serviceVideoFile.VideoCount = dataVideoFile.VideoCount;

			foreach (var audioAttributese in dataVideoFile.AudioAttributes)
			{
				serviceVideoFile.AudioAttributes.Add(ConvertAudioAttributes(audioAttributese));
			}

			foreach (var videoAttributese in dataVideoFile.VideoAttributes)
			{
				serviceVideoFile.VideoAttributes.Add(ConvertVideoAttributes(videoAttributese));
			}

			return serviceVideoFile;
		}

		private static SE.AudioAttribute ConvertAudioAttributes(DE.Files.AudioAttributes dataAudioAttributes)
		{
			var serviceAudioAttribute = new SE.AudioAttribute();

			serviceAudioAttribute.Channels = dataAudioAttributes.Channels;
			serviceAudioAttribute.Codec = dataAudioAttributes.Codec;
			serviceAudioAttribute.Format = dataAudioAttributes.Format;
			serviceAudioAttribute.Language = dataAudioAttributes.Language;
			serviceAudioAttribute.SamplingRate = dataAudioAttributes.SamplingRate;

			return serviceAudioAttribute;
		}

		private static SE.VideoAttribute ConvertVideoAttributes(DE.Files.VideoAttributes dataVideoAttributes)
		{
			var serviceVideoAttribute = new SE.VideoAttribute();

			serviceVideoAttribute.BitRate = dataVideoAttributes.BitRate;
			serviceVideoAttribute.CodecId = dataVideoAttributes.CodecId;
			serviceVideoAttribute.Format = dataVideoAttributes.Format;
			serviceVideoAttribute.Fps = dataVideoAttributes.Fps;
			serviceVideoAttribute.Height = dataVideoAttributes.Height;
			serviceVideoAttribute.Widht = dataVideoAttributes.Widht;

			return serviceVideoAttribute;
		}

		public static SE.Users.User ConvertUser(DE.Users.User dataUser)
		{
			var serviceUser = new SE.Users.User();

			serviceUser.FirstName = dataUser.FirstName;
			serviceUser.LastName = dataUser.LastName;
			serviceUser.Id = dataUser.Id;

			serviceUser.Email = dataUser.Email;

			return serviceUser;
		}
	}
}
