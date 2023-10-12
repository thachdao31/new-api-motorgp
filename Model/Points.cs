using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace biker.Models
{
    public class Points {
        [Key]
        public int Id { get; set; }
        public int? Point { get; set; }
        public int BikerId { get; set; }
        public Biker Biker {get; set;}
        public int RacesId { get; set; }
        public Races Races {get; set;}
    }
}