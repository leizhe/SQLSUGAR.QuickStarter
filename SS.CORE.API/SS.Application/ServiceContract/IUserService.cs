using SS.Application.Dtos;
using SS.Application.Input;
using SS.Application.Output;

namespace SS.Application.ServiceContract
{
    public interface IUserService
    {
        GetResult<UserDto> GetUser(int userId);
        GetResults<UserDto> GetUsers(PageInput input);

        UpdateResult UpdateUser(UserDto user);

        CreateResult<long> AddUser(UserDto user);

        DeleteResult DeleteUser(int userId);

        UpdateResult UpdatePwd(UserDto user);



        UpdateResult UpdateRoles(UserDto user);

        DeleteResult DeleteRole(int userId, int roleId);

        bool Exist(string username, string password);
    }
}