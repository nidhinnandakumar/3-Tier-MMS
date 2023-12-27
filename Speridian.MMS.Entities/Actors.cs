using Newtonsoft.Json;

namespace Speridian.MMS.Entities
{
    public class Actors
    {
        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public Gender Gender { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        public DateOnly DateOfBirth { get; set; }


    }
}