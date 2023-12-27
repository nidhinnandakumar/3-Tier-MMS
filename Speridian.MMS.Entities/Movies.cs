using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text;

namespace Speridian.MMS.Entities
{
    public class Movies
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string Director { get; set; }

        public int ReleaseYear { get; set; }

        public TimeSpan Duration { get; set; }

        public double Rating { get; set; }

        // [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
        public List<Actors> Actors { get; set; }

        public Genre MovieGenre { get; set; }

        public Language MovieLanguage { get; set; }

        //public override string ToString()
        //{
        //   // return JsonConvert.SerializeObject(this);
        //}
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Id: {Id}");
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Director: {Director}");
            sb.AppendLine($"Release Year: {ReleaseYear}");
            sb.AppendLine($"Duration: {Duration}");
            sb.AppendLine($"Rating: {Rating}");

            if (Actors != null && Actors.Count > 0)
            {
                sb.AppendLine("Actors:");
                foreach (var actor in Actors)
                {
                    sb.AppendLine($"  - {actor.ActorName}");
                }
            }

            sb.AppendLine($"Genre: {MovieGenre}");
            sb.AppendLine($"Language: {MovieLanguage}");

            return sb.ToString();
        }

    }
}
