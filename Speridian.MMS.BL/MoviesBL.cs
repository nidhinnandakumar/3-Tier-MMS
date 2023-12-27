using Speridian.MMS.DAL;
using Speridian.MMS.Entities;

namespace Speridian.MMS.BL
{
    public class MoviesBL
    {
        public static List<Movies> GetMovieList()
        {
            var list = MoviesDAL.GetActorsList();
            return list;
        }

        public static bool Add(Movies movies)
        {
            var isAdded = MoviesDAL.Add(movies);
            return isAdded;
        }


        public static Movies GetById(int d)

        {

            var emp = MoviesDAL.GetById(d);

            return emp;

        }

        //delete
        public static bool Delete(Movies movies)

        {

            var isDeleted = MoviesDAL.Delete(movies);

            return isDeleted;

        }

        public static bool Update(Movies movies)

        {

            var isUpdated = MoviesDAL.Update(movies);

            return isUpdated;

        }

    }


}