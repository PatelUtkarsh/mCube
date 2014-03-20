namespace mCube.DataEntities.MetaData
{
    public class CastMember
    {
        public int ArtistId { get; set; }

        public int MovieId { get; set; }

        public int CastId { get; set; }


        public virtual Artist Artist { get; set; }

        public virtual Movie Movie { get; set; }


        //public string Name { get; set; }

        public string Job { get; set; }

        public string Character { get; set; }

        public string Profile { get; set; }

        public string Department { get; set; }

        public int Order { get; set; }

        
    }
}
