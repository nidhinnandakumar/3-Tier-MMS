using Speridian.MMS.Entities;
using Speridian.MMS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speridian.MMS.DAL
{
    public class ActorsDAL
    {
        static List<Actors> list = new List<Actors>
        {
            new Actors{ActorId=1,ActorName="Tom Cruise",Gender=Gender.Male,DateOfBirth = new DateOnly(1962, 5, 2)},
            new Actors{ActorId=2,ActorName="Rock",Gender=Gender.Male,DateOfBirth = new DateOnly(2000, 7, 3)},
            new Actors{ActorId=3,ActorName="Jack",Gender=Gender.Male,DateOfBirth = new DateOnly(2002, 5, 3)},
        };
        static int counter = 3;
        public static List<Actors> GetActorsList()
        {
            return list;
        }
        public static bool Add(Actors newActor)
        {
            bool isExists = list.Exists(d => d.ActorName == newActor.ActorName);
            if (isExists)
            {
                throw new MMSExceptions("Actor already Exists");
            }
            newActor.ActorId = ++counter;
            list.Add(newActor);
            return true;
        }
        public static Actors GetById(int id)
        {
            var actor = list.Find(d => d.ActorId == id);
            return actor;
        }
        public static bool Update(Actors actor)
        {

            list.Append(actor);
            return true;
        }



    }
}