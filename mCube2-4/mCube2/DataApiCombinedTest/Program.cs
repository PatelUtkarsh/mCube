using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using TheMovieDb.BasicEntities.Person;
using mCube.BackEndServices;
using mCube.DataEntities;

namespace DataApiCombinedTest
{
    class Program
    {
        static void Main(string[] args)
        {
			//var manager = new SearchEngine();
			//var input = Console.ReadLine();
			//var movies = manager.SearchStoreReturn(input);

			//foreach (var movie in movies)
			//{
			//    Console.WriteLine(movie.Name + " " + movie.Rating + " " + movie.ImdbId);
			//    Console.WriteLine();
			//}


			var um = new UserManager();
			//Console.WriteLine(um.CreateNewUser("JInal", "kothari", "123", "jinalthecool@gmail.com"));
			//Console.WriteLine(um.CreateNewUser("JInal", "kothari", "123", "jinalthecol@gmail.com"));
			//Console.WriteLine(um.CreateNewUser("JInal", "kothari", "123", "jinalthecl@gmail.com"));
			//Console.WriteLine(um.CreateNewUser("JInal", "kothari", "123", "jinalthel@gmail.com"));
			//Console.WriteLine(um.CreateNewUser("JInal", "kothari", "123", "jinalthecool@gmail.com"));

        	Console.WriteLine(um.CreateVirtualGroup("The Warriors",1));
			Console.WriteLine(um.CreateVirtualGroup("The Warsriors", 1));
			Console.WriteLine(um.CreateVirtualGroup("The Warrfiors", 1));
			Console.WriteLine(um.CreateVirtualGroup("The Warrigors", 1));
			Console.WriteLine();

            Console.WriteLine("Done!!");
            Console.ReadLine();

        }


    }
}
