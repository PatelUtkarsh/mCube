using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheMovieDb;

namespace TmdbApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var tmdb = new TmdbApi("f414ec82be0a907e822c488499df7f4a");



            //var genres = tmdb.GetGenres();
            //foreach (var tmdbGenre in genres)
            //{
            //    Console.WriteLine("Name : " + tmdbGenre.Name);
            //    Console.WriteLine("Type : " + tmdbGenre.Type);
            //    Console.WriteLine();
            //}

            var mov = tmdb.GetMovieInfo(500);

            Console.WriteLine("Posters");
            foreach (var tmdbImage in mov.Posters)
            {
                Console.WriteLine(tmdbImage.ImageInfo.Id);
                Console.WriteLine(tmdbImage.ImageInfo.Type);
                //Console.WriteLine(tmdbImage.ImageInfo.Url);
            }
            Console.ReadLine();


            Console.WriteLine("BackDrop");
            foreach (var tmdbImage in mov.Backdrops)
            {
                Console.WriteLine(tmdbImage.ImageInfo.Id);
                Console.WriteLine(tmdbImage.ImageInfo.Type);
                //Console.WriteLine(tmdbImage.ImageInfo.Url);
            }
            Console.ReadLine();



            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}
