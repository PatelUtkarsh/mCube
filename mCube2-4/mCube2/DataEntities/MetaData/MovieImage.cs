namespace mCube.DataEntities.MetaData
{
    public class MovieImage:Image
    {
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
