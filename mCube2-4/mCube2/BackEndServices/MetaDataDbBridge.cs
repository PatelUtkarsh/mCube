using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TheMovieDb;
using TheMovieDb.BasicEntities;
using TheMovieDb.BasicEntities.Images;
using TheMovieDb.BasicEntities.Person;
using mCube.DataEntities;
using mCube.DataEntities.MetaData;


namespace mCube.BackEndServices
{
    public struct IdContainer
    {
        public int Id;
        public bool IsFull;
        public bool IsExist;
    }

    public static class MetaDataDbBridge
    {
		/// <summary>
		/// Gets all movies from tmdb matching query, gets detailed information of movies(from the result) whose information is not in db; and saves the details 
		/// </summary>
		/// <param name="query"></param>
		/// <returns>List of movie ids from the result sent by tmdb</returns>
		public static IEnumerable<int> GetMoviesByQuery(string query)
		{
			var api = new TmdbApi("f414ec82be0a907e822c488499df7f4a");
			Database.SetInitializer(new mCubeDataContextInitializer());
			int[] resultMovieTmdbIds;

			try
			{
				var tmdbMovies = api.MovieSearch(query);
				if (tmdbMovies == null)
				{
					throw new Exception();
				}
				resultMovieTmdbIds = (from tmdbMovie in tmdbMovies select tmdbMovie.Id).ToArray();
			}
			catch (Exception exception)
			{
				throw;
			}
			return ProcessMovieList(resultMovieTmdbIds);
			 
		}

		/// <summary>
		///	Returns Movie object (only if it exists. Exception will be thrown other wise)
		/// </summary>
		/// <param name="id">Id of the movie</param>
		/// <returns></returns>
		public static Movie GetMoviesFromDbById(int id) //To be removed??
		{
			var context = new mCubeDataContext();

			Movie movie;
			movie = context.Movies.Find(id);
			context.Entry(movie).State = EntityState.Detached;
			return movie;
		}



		private static IEnumerable<int> ProcessMovieList(IEnumerable<int> resultMovieTmdbIds)
		{
			var movies = new List<int>();
			var moviesIdReport = MovieExistanceReport(resultMovieTmdbIds);
			var api = new TmdbApi("f414ec82be0a907e822c488499df7f4a");

			foreach (var movieIdReport in moviesIdReport)
			{
				try
				{
					if (movieIdReport.IsExist)
					{
						if (movieIdReport.IsFull)
						{
							movies.Add(movieIdReport.Id);
						}
						else
						{
							StoreMovie(api.GetMovieInfo(movieIdReport.Id), true);
							movies.Add(movieIdReport.Id);
						}
					}
					else
					{
						StoreMovie(api.GetMovieInfo(movieIdReport.Id), false);
						movies.Add(movieIdReport.Id);
					}

				}
				catch (Exception)
				{
					throw;
				}
			}

			return movies;
		}

        private static IEnumerable<IdContainer> ArtistsExistanceReport(IEnumerable<int> ids)
        {
            var context = new mCubeDataContext();

            var result = new List<IdContainer>();

            foreach (var id in ids)
            {
                var artist = context.Artists.Find(id);
                if (artist == null)
                {
                    result.Add(new IdContainer() { Id = id, IsExist = false, IsFull = false });
                }
                else
                {
                    result.Add(new IdContainer() { Id = id, IsExist = true, IsFull = true });
                }

            }

            return result;
        }

    	private static IEnumerable<IdContainer> MovieExistanceReport(IEnumerable<int> ids)
        {
            var context = new mCubeDataContext();

            var result = new List<IdContainer>();

            foreach (var id in ids)
            {
                var movie = context.Movies.Find(id);
                if(movie == null)
                {
                    result.Add(new IdContainer(){Id=id,IsExist=false,IsFull=false});
                }
                else
                {
                    result.Add(new IdContainer() { Id = id, IsExist = true, IsFull = movie.IsFullInfo });
                }

            }

            return result;
        }
        
       
        
		

		private static void StoreMovie(TmdbMovie tmdbMovie, bool isStub) //Better implementation possible using isStub
		{
			var context = new mCubeDataContext();
			Debug.WriteLine("Storing movie :" + tmdbMovie.Name);
			var movie = context.Movies.Find(tmdbMovie.Id);

			if (movie == null)
			{
				movie = MovieConvertor(tmdbMovie,context.Movies.Create(), isStub);
				context.Movies.Add(movie);
			}
			else if (movie.IsFullInfo)
			{
				return;
			}
			else
			{
				MovieConvertor(tmdbMovie, movie, isStub);
			}

			foreach (var tmdbImage in tmdbMovie.Posters)
			{
				var image = new MovieImage();
				ImageConvertor(tmdbImage, image);
				image.MovieId = movie.Id;
				context.MovieImages.Add(image);
			}
			
			StoreCast(tmdbMovie.Cast, tmdbMovie.Id,context);
			StoreGenres(tmdbMovie.Genres, movie, context);
			StoreStudio(tmdbMovie.Studios, movie, context);

			try
			{
				
				context.SaveChanges();
				Debug.WriteLine("Finished storing movie :" + tmdbMovie.Name);
			}
			catch (DbEntityValidationException dbEx)
			{
				foreach (var validationErrors in dbEx.EntityValidationErrors)
				{
					foreach (var validationError in validationErrors.ValidationErrors)
					{
						Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
						Console.WriteLine();
					}
				}
			}

		}

		private static void GetStoreArtist(int id, mCubeDataContext context = null)
		{

			bool wasContextNull = false;
			if (context == null)
			{
				context = new mCubeDataContext();
				wasContextNull = true;
			}


			var artist = context.Artists.Find(id);
			if (artist != null)
			{
				return;

			}

			var api = new TmdbApi("f414ec82be0a907e822c488499df7f4a");
			var tmdbPerson = api.GetPersonInfo(id);
			context.Artists.Add(ArtistConvertor(tmdbPerson));


			foreach (var tmdbImage in tmdbPerson.Images)
			{
				var image = new ArtistImage();
				ImageConvertor(tmdbImage, image);
				image.ArtistId = id;
				context.ArtistImages.Add(image);
			}


			Debug.WriteLine("    Stored artist " + tmdbPerson.Name);
			if (wasContextNull)
			{
				context.SaveChanges();
			}



		}

		private static void StoreCast(IEnumerable<TmdbCastPerson> cast, int movieId, mCubeDataContext context)
		{

			foreach (var tmdbCastPerson in cast)
			{
				Debug.WriteLine("  Storing castmember " + tmdbCastPerson.Name + " as " + tmdbCastPerson.Character + " " + tmdbCastPerson.Job);
				var castMember = context.CastMembers.Find(tmdbCastPerson.Id, movieId, tmdbCastPerson.CastId);
				if (castMember != null)
				{
					continue;
				}
				var artist = context.Artists.Find(tmdbCastPerson.Id);
				if (artist == null)
				{
					GetStoreArtist(tmdbCastPerson.Id);
				}

				context.CastMembers.Add(CastMemberConvertor(tmdbCastPerson, movieId));
				Debug.WriteLine("  Done storing castmember ");
			}
		}



    	private static void StoreStudio(IEnumerable<TmdbStudio> studios, Movie movie, mCubeDataContext context)
    	{
    		foreach (var tmdbStudio in studios)
    		{
    			var studio = context.Studios.Find(tmdbStudio.Id);
				if(studio==null)
				{
					studio = new Studio() {Id = tmdbStudio.Id, Name = tmdbStudio.Name};
				}
				movie.Studios.Add(studio);
    		}
    	}

    	private static void StoreGenres(IEnumerable<TmdbGenre> tmdbGenres, Movie movie, mCubeDataContext context)
    	{
    		foreach (var tmdbGenre in tmdbGenres)
    		{
    			var genre = context.Genres.Find(tmdbGenre.Id);
    			if (genre==null)
    			{
					genre = new Genre() { Id = tmdbGenre.Id, Name = tmdbGenre.Name, Type = tmdbGenre.Type };
    			}
    			movie.Genres.Add(genre);
    		}
    	}



		private static Artist ArtistConvertor(TmdbPerson tmdbPerson)  //Converts only the basic info
		{
			var artist = new Artist();

			artist.Id = tmdbPerson.Id;
			artist.Biography = tmdbPerson.Biography;
			artist.Birthplace = tmdbPerson.Birthplace;
			artist.IsFull = true;
			artist.KnownMovies = tmdbPerson.KnownMovies;
			artist.Name = tmdbPerson.Name;
			artist.Popularity = tmdbPerson.Popularity;
			artist.Score = tmdbPerson.Score;

			return artist;
		}

		private static Image ImageConvertor(TmdbImage tmdbImage,Image image)
		{

			image.TmdbId = tmdbImage.ImageInfo.Id;
			image.Height = tmdbImage.ImageInfo.Height;
			image.Size = tmdbImage.ImageInfo.Size;
			image.Type = tmdbImage.ImageInfo.Type;
			image.Url = tmdbImage.ImageInfo.Url;
			image.Width = tmdbImage.ImageInfo.Width;

			return image;
		}

		private static Movie MovieConvertor(TmdbMovie tmdbMovie,Movie movie,bool isStub) //Converts only the basic info
		{

			if (!isStub)
			{
				movie.Id = tmdbMovie.Id;
			}

			movie.IsFullInfo = true;
			movie.Name = tmdbMovie.Name;
			movie.Adult = tmdbMovie.Adult;
			movie.AlternativeName = tmdbMovie.AlternativeName;
			movie.Budget = tmdbMovie.Budget;
			movie.Certification = tmdbMovie.Certification;
			movie.Homepage = tmdbMovie.Homepage;
			movie.ImdbId = tmdbMovie.ImdbId;
			movie.Language = tmdbMovie.Language;
			movie.OriginalName = tmdbMovie.OriginalName;
			movie.Overview = tmdbMovie.Overview;
			movie.Popularity = tmdbMovie.Popularity;
			movie.Rating = tmdbMovie.Rating;
			movie.Released = tmdbMovie.Released;
			movie.Runtime = tmdbMovie.Runtime;
			movie.Revenue = tmdbMovie.Revenue;
			movie.Status = tmdbMovie.Status;
			movie.Tagline = tmdbMovie.Tagline;
			movie.Trailer = tmdbMovie.Trailer;
			movie.Type = tmdbMovie.Type;
			movie.Votes = tmdbMovie.Votes;

			return movie;
		}

		private static CastMember CastMemberConvertor(TmdbCastPerson tmdbCastPerson,int movieId) //Assumes Artist and Movie exist
		{
			var member = new CastMember();

			member.ArtistId = tmdbCastPerson.Id;
			member.CastId = tmdbCastPerson.CastId;
			member.MovieId = movieId;
			member.Character = tmdbCastPerson.Character;
			member.Department = tmdbCastPerson.Department;
			member.Profile = tmdbCastPerson.Profile;
			member.Job = tmdbCastPerson.Job;
			member.Order = tmdbCastPerson.Order;

			return member;
		}
    }
}
