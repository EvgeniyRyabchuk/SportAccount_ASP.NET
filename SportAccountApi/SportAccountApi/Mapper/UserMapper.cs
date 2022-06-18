using SportAccountApi.DTO.User;
using SportAccountApi.Models;
using SportAccountApi.SL;

namespace SportAccountApi.Mapper
{
    public class UserMapper
    {
        public static User FromCreateModel(CreateUserDTO createModel)
        {
            _SL.CreatePasswordHash(createModel.Password, out byte[] passwordHash, out byte[] passwordSalt);
            
            return new User()
            {
                FirstName = createModel.FirstName,
                LastName = createModel.LastName,
                MiddletName = createModel.MiddletName,
                Login = createModel.Login, 
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                BirthDate = createModel.BirthDate,
                RoleId = createModel.RoleId, 
                SpecializationId = createModel.SpecializationId,
                StatusId = createModel.StatusId, 
                SexId = createModel.SexId, 
            }; 
        }
        public static User FromUpdateModel(UpdateUserDTO createModel)
        {
            return new User()
            {
                Id = createModel.Id,
                FirstName = createModel.FirstName,
                LastName = createModel.LastName,
                MiddletName = createModel.MiddletName,
                BirthDate = createModel.BirthDate,
            };
        }
    }
}
