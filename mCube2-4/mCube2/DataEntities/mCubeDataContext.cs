using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using mCube.DataEntities.Files;
using mCube.DataEntities.MetaData;
using mCube.DataEntities.Torrents;
using mCube.DataEntities.Users;


namespace mCube.DataEntities
{
    public class mCubeDataContext : DbContext 
    {
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<MovieImage> MovieImages { get; set; }

        public DbSet<ArtistImage> ArtistImages { get; set; }

		public DbSet<Artist> Artists { get; set; }

		public DbSet<Studio> Studios { get; set; }

        public DbSet<CastMember> CastMembers { get; set; }

		public DbSet<VirtualGroup> VirtualGroups { get; set; }

		public DbSet<UserVirtualGroup> UserVirtualGroups { get; set; }

		public DbSet<User> Users { get; set; }

    	public DbSet<VideoFile> VideoFiles { get; set; }

    	public DbSet<UserCollectionItem> UserCollection { get; set; }

		public DbSet<Torrent> Torrents { get; set; }

		public DbSet<UserTorrentRating> UserTorrentRatings { get; set; }

		public DbSet<UserMovieRating> UserMovieRatings { get; set; }

		

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        	modelBuilder.Entity<Artist>().Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<CastMember>().HasKey(c => new {c.ArtistId, c.MovieId, c.CastId});

            modelBuilder.Entity<CastMember>().Property(c => c.CastId).HasDatabaseGeneratedOption(
                DatabaseGeneratedOption.None);

        	modelBuilder.Entity<UserCollectionItem>().HasKey(uc => new {uc.UserId, MovieFileId = uc.VideoFileId , uc.MovieId});

        	modelBuilder.Entity<UserTorrentRating>().HasKey(utr => new {utr.TorrentId, utr.UserId});

        	modelBuilder.Entity<UserMovieRating>().HasKey(umr => new {umr.MovieId, umr.UserId});

        	modelBuilder.Entity<UserVirtualGroup>().HasKey(uvg => new {uvg.UserId, uvg.VirtualGroupId});

        }

    }

    public class mCubeDataContextInitializer : DropCreateDatabaseIfModelChanges<mCubeDataContext>
    {
        
    }
}
