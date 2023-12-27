using Speridian.MMS.DAL;
using Speridian.MMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speridian.MMS.BL
{
    public class ActorsBL
    {
        public static List<Actors> GetActorsLIst()
        {
            var list = ActorsDAL.GetActorsList();
            return list;
        }
        public static bool Add(Actors newActor)
        {
            var isAdded = ActorsDAL.Add(newActor);
            return isAdded;
        }

        public static Actors GetById(int d)
        {
            var act = ActorsDAL.GetById(d);
            return act;
        }
        public static bool Update(Actors actor)
        {
            var isUpdated = ActorsDAL.Update(actor);
            return isUpdated;
        }
    }
}
