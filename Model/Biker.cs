using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace biker.Models
{
    public class Biker {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int NationalId { get; set; }
        public virtual National National { get; set; }
    }
}