using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace biker.Models
{
    public class National {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}