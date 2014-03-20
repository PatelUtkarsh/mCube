namespace mCube.DataEntities.MetaData
{
    public class ArtistImage : Image
    {
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
