using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAccountApi.DTO.User
{
    public class CreateUserDTO
    {
        
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddletName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
