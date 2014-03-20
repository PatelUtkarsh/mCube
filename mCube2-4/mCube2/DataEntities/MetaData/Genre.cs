using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mCube.DataEntities.MetaData
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }

        #region UnImportantPublicProperties

        public string Type { get; set; }

        public string Name { get; set; }

        #endregion
    }
}
