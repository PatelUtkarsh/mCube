using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using mCube.DataEntities;
using mCube.DataEntities.MetaData;

namespace mCubeEntitiesTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new mCubeDataContext();
            Database.SetInitializer(new mCubeDataContextInitializer());
            var mov = new Movie() { Id = 3, Name = "Terminator" };
            context.Movies.Add(mov);
            context.SaveChanges();
        }
    }
}
