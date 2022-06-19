using JwtWebApiTutorial;
using SportAccountApi.Models;

namespace SportAccountApi.Mapper
{
    public class RefreshTokenMapper
    {
        public static _RefreshToken FromRefreshTokenClass(RefreshToken createModel, User user) 
        {
            return new _RefreshToken()
            {
                RefreshToken = createModel.Token,
                Expired_At = createModel.Expires,
                Created_At = createModel.Created,
                UserId = user.Id,
            };
        }
    }
}
