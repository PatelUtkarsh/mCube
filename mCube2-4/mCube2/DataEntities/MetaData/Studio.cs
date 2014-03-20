using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mCube.DataEntities.MetaData
{
    public class Studio
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }


        public virtual ICollection<Movie> Movies { get; set; }


        public string Name { get; set; }

        
    }
}
