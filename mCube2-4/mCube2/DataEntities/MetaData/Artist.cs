using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mCube.DataEntities.MetaData
{
    public class Artist
    {
		[Key]
        public int Id { get; set; }

		public bool IsFull { get; set; }

        public virtual ICollection<ArtistImage> ArtistImages { get; set; }

        public virtual ICollection<CastMember> Roles { get; set; } 


		#region UnImportantPublicProperties

		public string Score { get; set; }

        public string Popularity { get; set; }

        public string Name { get; set; }

        public string Biography { get; set; }

        public int KnownMovies { get; set; }

        public string Birthplace { get; set; }

		#endregion

		//public string BirthdayString { get; set; }

        //public DateTime? Birthday
        //{
        //    get
        //    {
        //        DateTime d;
        //        if (string.IsNullOrEmpty(BirthdayString) || !DateTime.TryParse(BirthdayString, out d))
        //            return null;
        //        else
        //            return d;
        //    }
        //}

       // public List<TmdbPersonFilm> Filmography { get; set; }


    }
}
