using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace biker.Models
{
    public class Points {
        [Key]
        public int Id { get; set; }
        public int? Point { get; set; }
        public int BikerId { get; set; }
        public virtual Biker Biker {get; set;}
        public int RacesId { get; set; }
        public virtual Races Races {get; set;}
    }
}