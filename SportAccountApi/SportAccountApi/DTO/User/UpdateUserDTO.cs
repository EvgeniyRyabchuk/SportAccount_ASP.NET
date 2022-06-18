using System;
using System.ComponentModel.DataAnnotations;

namespace SportAccountApi.DTO.User
{
    public class UpdateUserDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddletName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
    }
}
