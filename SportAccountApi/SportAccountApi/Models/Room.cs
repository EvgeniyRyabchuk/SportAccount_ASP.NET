
using System.ComponentModel.DataAnnotations;
namespace SportAccountApi.Models
{
    public class Room
    {

        [Key]
        public int Id { get; set; } 
        public int Number { get; set; } 
        public string Name { get; set; } 
        public short AreaSize { get; set; }
        public short Floor { get; set; }
        
    }
}
