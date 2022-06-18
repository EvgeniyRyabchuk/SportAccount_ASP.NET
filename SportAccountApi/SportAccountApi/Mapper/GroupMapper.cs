using SportAccountApi.DTO.Group;
using System.Text.RegularExpressions;

namespace SportAccountApi.Mapper
{
    public class GroupMapper
    {
        public static Models.Group FromCreateModel(CreateGroupDTO createModel)
        {
            return new Models.Group()
            {
                Name = createModel.Name, 
            };
        }
       
    }
}
