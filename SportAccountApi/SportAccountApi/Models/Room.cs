
using System.ComponentModel.DataAnnotations;
namespace SportAccountApi.Models
{
    public class Room
    {

        [Key]
        public int Id { get; set; }
        public int number { get; set; }
        public string name { get; set; }
        public short areaSize { get; set; }
        public short floor { get; set; }
        
    }
}
