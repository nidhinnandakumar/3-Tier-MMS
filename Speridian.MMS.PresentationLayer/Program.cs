using Newtonsoft.Json.Linq;
using Speridian.MMS.BL;
using Speridian.MMS.Entities;
using Speridian.MMS.Exceptions;

namespace Speridian.MMS.PresentationLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("======================================");
                    Console.WriteLine("%%%%%% MOVIE MANAGEMENT SYSTEM %%%%%%");
                    Console.WriteLine("======================================");

                    Console.WriteLine("1  LIST ACTORS ");
                    Console.WriteLine("2  LIST MOVIES");
                    Console.WriteLine("3  ADD ACTORS ");
                    Console.WriteLine("4  UPDATE ACTORS ");
                    Console.WriteLine("5  ADD MOVIES ");
                    Console.WriteLine("6  UPDATE MOVIE ");
                   // Console.WriteLine("7  DELETE ACTOR ");
                    Console.WriteLine("8  DELETE MOVIE ");
                    Console.WriteLine("9 #### EXIT ####");
                    Console.WriteLine("======================================");
                    Console.WriteLine(" !!!! Enter your choice !!!! ");
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out int choice))
                    {
                        Console.WriteLine("INVALID INPUT");
                        return;
                    }
                    switch (choice)
                    {
                        case 1:
                            ListActors();
                            break;
                        case 2:
                            ListMovies();
                            break;
                        case 3:
                            AddActors();
                            break;
                        case 4:
                            UpdateActor();
                            break;
                        case 5:
                            AddMovie();
                            break;
                        case 6:
                            UpdateMovie();
                            break;
                        case 7:
                            //DeleteActor();
                            break;
                        case 8:
                            DeleteMovies();
                            break;
                        case 9:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid Input");
                            break;

                    }

                }
                catch (MMSExceptions ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }
        private static void AddActors()

        {
            Actors act = new Actors();
            Console.WriteLine(" Enter Actor Name");
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid input");
                return;
            }
            act.ActorName = input;
            foreach (var g in Enum.GetNames(typeof(Gender)))
            {
                Console.WriteLine(g);
            }
            Console.WriteLine("Enter Actor Gender:");
            input = Console.ReadLine();
            if (Enum.TryParse(input, out Gender gender))
            {
                act.Gender = gender;
            }
            else
            {
                Console.WriteLine("Invalid input");
                return;
            }
            Console.WriteLine("Enter Actor Date Of Birth");
            input = Console.ReadLine();
            if (!DateOnly.TryParse(input, out DateOnly dob))
            {
                Console.WriteLine("Invalid input");
                return;
            }
            act.DateOfBirth = dob;

            bool isAdded = ActorsBL.Add(act);
            if (isAdded)
            {
                Console.WriteLine("\t\t\t\t\t\tActor added successfully");
            }
            else
            {
                Console.WriteLine("\t\t\t\t\t\tAdd Actor failed");

            }

        }
        static void ListActors()
        {
            var list = ActorsBL.GetActorsLIst();
            foreach (var actor in list)
            {
                Console.WriteLine(actor);
            }
        }


        //update actor
        private static void UpdateActor()
        {
            ListActors();
            Console.WriteLine("enter Actor id to update");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int actId))
            {
                Console.WriteLine("invalid input");
            }
            var act = ActorsBL.GetById(actId);
            if (act == null)
            {
                Console.WriteLine("Actor not exist");
                return;

            }
            Console.WriteLine(" Enter Actor Name");
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid input");
                return;
            }
            act.ActorName = input;

            Console.WriteLine("Enter Actor Gender:");
            foreach (var g in Enum.GetNames(typeof(Gender)))
            {
                Console.WriteLine(g);
            }
            input = Console.ReadLine();
            if (Enum.TryParse(input, out Gender gender))
            {
                act.Gender = gender;
            }
            else
            {
                Console.WriteLine("Invalid input");
                return;
            }
            Console.WriteLine("Enter Actor Date Of Birth");
            input = Console.ReadLine();
            if (!DateOnly.TryParse(input, out DateOnly dob))
            {
                Console.WriteLine("Invalid input");
                return;
            }
            act.DateOfBirth = dob;

            bool isUpdated = ActorsBL.Update(act);
            if (isUpdated)
            {
                Console.WriteLine("Actor Updated successfully");
            }
            else
            {
                Console.WriteLine("Update Actor failed");

            }

        }

        //list movie
        static void ListMovies()
        {
            var list = MoviesBL.GetMovieList();
            foreach (var actor in list)
            {
                Console.WriteLine(actor);
            }
        }

        //Add movies


        private static void AddMovie()
        {
            Movies newMovie = new Movies();



            Console.Write("Enter Movie Name: ");
            if (string.IsNullOrEmpty(newMovie.Name = Console.ReadLine()))
            {
                Console.WriteLine("invalid entry");
                return;
            }
            Console.Write("Enter Director Name: ");
            if (string.IsNullOrEmpty(newMovie.Director = Console.ReadLine()))
            {
                Console.WriteLine("invalid entry");
                return;
            }

            Console.Write("Enter Release Year: ");
            newMovie.ReleaseYear = int.Parse(Console.ReadLine());

            Console.Write("Enter Duration (in hours): ");
            double durationInHours = double.Parse(Console.ReadLine());
            newMovie.Duration = TimeSpan.FromHours(durationInHours);

            Console.Write("Enter Rating: ");
            newMovie.Rating = double.Parse(Console.ReadLine());

            // Collecting actors' names
            newMovie.Actors = new List<Actors>();
            Console.Write("Enter number of Actors: ");
            int numberOfActors = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfActors; i++)
            {
                Console.Write($"Enter Actor {i + 1} Name: ");
                string actorName = Console.ReadLine();
                if (string.IsNullOrEmpty(actorName))
                {
                    Console.WriteLine("invalid entry");
                    return;
                }
                newMovie.Actors.Add(new Actors { ActorName = actorName });
            }

            Console.Write("Enter Genre: ");
            foreach (var g in Enum.GetNames(typeof(Genre)))
            {
                Console.WriteLine(g);

            }

            if (Enum.TryParse(Console.ReadLine(), out Genre genre1))
            {
                newMovie.MovieGenre = genre1;
            }
            else
            {
                Console.WriteLine("Invalid Genre. Genre not added.");
                return;
            }


            Console.Write("Enter Language: ");
            foreach (var g in Enum.GetNames(typeof(Language)))
            {
                Console.WriteLine(g);

            }
            if (Enum.TryParse(Console.ReadLine(), out Language language))
            {
                newMovie.MovieLanguage = language;
            }
            else
            {
                Console.WriteLine("Invalid Language. Language not added.");
                return;
            }

            bool isAdded = MoviesBL.Add(newMovie);

            if (isAdded)
            {
                Console.WriteLine("Movie  Successfully Added");
            }
            else
            {
                Console.WriteLine("Failed to Add Movie");
            }


        }

        //delete movie
        private static void DeleteMovies()
        {
            ListMovies();
            Console.WriteLine("enter Movie id to Delete");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int movid))
            {
                Console.WriteLine("invalid input");
            }
            var mov = MoviesBL.GetById(movid);
            if (mov == null)
            {
                Console.WriteLine("Movie does not exist");
                return;

            }

            bool isDeleted = MoviesBL.Delete(mov);
            if (isDeleted)
            {
                Console.WriteLine("Movie deleted successfully");

            }
            else
            {
                Console.WriteLine("delete Movie failed");
            }
        }

        //update movies

        public static void UpdateMovie()
        {


            ListMovies();
            Console.WriteLine("enter Movie id to update");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int Id))
            {
                Console.WriteLine("invalid input");
            }
            var newMovie = MoviesBL.GetById(Id);
            if (newMovie == null)
            {
                Console.WriteLine("movie not exist");
                return;

            }
            

            Console.Write("Enter Movie Name: ");

            if (string.IsNullOrEmpty(newMovie.Name = Console.ReadLine()))
            {
                Console.WriteLine("invalid entry");
                return;
            }
            Console.Write("Enter Director Name: ");

            if (string.IsNullOrEmpty(newMovie.Director = Console.ReadLine()))
            {
                Console.WriteLine("invalid entry");
                return;
            }

            Console.Write("Enter Release Year: ");
            newMovie.ReleaseYear = int.Parse(Console.ReadLine());

            Console.Write("Enter Duration (in hours): ");
            double durationInHours = double.Parse(Console.ReadLine());
            newMovie.Duration = TimeSpan.FromHours(durationInHours);

            Console.Write("Enter Rating: ");
            newMovie.Rating = double.Parse(Console.ReadLine());

            // Collecting actors' names
            newMovie.Actors = new List<Actors>();
            Console.Write("Enter number of Actors: ");
            int numberOfActors = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfActors; i++)
            {
                Console.Write($"Enter Actor {i + 1} Name: ");
                string actorName = Console.ReadLine();
                if (string.IsNullOrEmpty(actorName))
                {
                    Console.WriteLine("invalid entry");
                    return;
                }
                newMovie.Actors.Add(new Actors { ActorName = actorName });
            }

            Console.Write("Enter Genre: ");

            foreach (var g in Enum.GetNames(typeof(Genre)))
            {
                Console.WriteLine(g);

            }


            if (Enum.TryParse(Console.ReadLine(), out Genre genre1))
            {
                newMovie.MovieGenre = genre1;
            }
            else
            {
                Console.WriteLine("Invalid Genre. Genre not added.");
                return;
            }


            Console.Write("Enter Language: ");
            foreach (var g in Enum.GetNames(typeof(Language)))
            {
                Console.WriteLine(g);

            }
            if (Enum.TryParse(Console.ReadLine(), out Language language))
            {
                newMovie.MovieLanguage = language;
            }
            else
            {
                Console.WriteLine("Invalid Language. Language not added.");
                return;
            }

            bool isUpdate = MoviesBL.Update(newMovie);

            if (isUpdate)
            {
                Console.WriteLine("Movie  Successfully Added");
            }
            else
            {
                Console.WriteLine("Failed to Add Movie");
            }


        }


    }

   
    

}









