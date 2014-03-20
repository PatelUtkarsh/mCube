using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using mCube.DataEntities.Torrents;
using mCube.DataEntities.Users;

namespace mCube.DataEntities.MetaData
{
    public class Movie
    {
    	public Movie()
    	{
			Genres = new List<Genre>();
			Studios =new List<Studio>();
    	}

    	[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }

        public bool IsFullInfo { get; set; }

        #region NavigationProperties
		
        public virtual ICollection<MovieImage> MovieImages { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }

        public virtual ICollection<Studio> Studios { get; set; }

        public virtual ICollection<CastMember> Cast { get; set; }



		public virtual ICollection<UserMovieRating> UserMovieRatings { get; set; }

		public virtual ICollection<Torrent> Torrents { get; set; } 

        #endregion




        #region MetaDataPublicProperties

        public string Popularity { get; set; }

        public bool? Translated { get; set; }

        public bool Adult { get; set; }

        public string Language { get; set; }

        public string OriginalName { get; set; }

        public string Name { get; set; }

        public string AlternativeName { get; set; }

        public string Type { get; set; }

        public string ImdbId { get; set; }

        public string Votes { get; set; }

        public string Rating { get; set; }

        public string Status { get; set; }

        public string Tagline { get; set; }

        public string Certification { get; set; }

        public string Overview { get; set; }

        public string Released { get; set; }

        public string Runtime { get; set; }

		public string Revenue { get; set; }

        public string Budget { get; set; }

        public string Homepage { get; set; }

        public string Trailer { get; set; }

        #endregion


        //public List<string> Keywords { get; set; }

        

        //public List<TmdbSpokenLanguage> SpokenLanguages { get; set; }

        //public List<TmdbCountry> Countries { get; set; }

        

        //public int Version { get; set; }

        //public string LastModifiedString
        //{
        //    get
        //    {
        //        return LastModified.HasValue ? LastModified.Value.ToString() : "";
        //    }
        //    set
        //    {
        //        DateTime d;
        //        if (DateTime.TryParse(value, out d))
        //            LastModified = d;
        //        else
        //            LastModified = null;
        //    }
        //}

        //public DateTime? LastModified
        //{
        //    set;
        //    get;
        //}
    }
}
