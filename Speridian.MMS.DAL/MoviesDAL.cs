using Speridian.MMS.Entities;
using Speridian.MMS.Exceptions;
using System.Collections.Generic;

namespace Speridian.MMS.DAL
{
    public class MoviesDAL
    {
        static List<Movies> list = new List<Movies>
     {
        new Movies
         {
             Id = 1,
             Name = "Fast and Furious",
             Director = "Riley Cooper",
             ReleaseYear = 2007,
             Duration = TimeSpan.FromHours(2).Add(TimeSpan.FromMinutes(6)), // 02:06:00
             Rating = 8.5,
           Actors = new List<Actors>
             {
                 new Actors { ActorId = 2,ActorName = "Paul",Gender= Gender.Male,DateOfBirth=new DateOnly(1951, 9, 7)},
                 new Actors { ActorName = "vin",Gender= Gender.Male,DateOfBirth=new DateOnly(1961, 7, 16) }
             },
            MovieGenre = Genre.Action,
             MovieLanguage = Language.English
         },
     };
        static int counter = 1;

        public static List<Movies> GetMovies()
        {
            return list;

        }

        public static List<Movies> GetActorsList()
        {
            return list;
        }

        public static bool Add(Movies movies)
        {
            bool isExists = list.Exists(e => e.Name == movies.Name);
            if (isExists)
            {
                throw new MMSExceptions("Movie already Exists");
            }
            movies.Id = ++counter;
            list.Add(movies);
            return true;
        }

        //getbyid

        public static Movies GetById(int id)

        {

            var movies = list.Find(d => d.Id == id);

            return movies;

        }

        //delete
        public static bool Delete(Movies Movies)

        {

            list.Remove(Movies);

            return true;

        }

        //update
        public static bool Update(Movies movie)
        {


            list.Append(movie);
            return true;
        }
    }

    }
