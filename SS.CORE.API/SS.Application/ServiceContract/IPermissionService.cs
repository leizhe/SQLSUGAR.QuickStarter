using SS.Application.Dtos;
using SS.Application.Input;
using SS.Application.Output;

namespace ED.Application.ServiceContract
{
    public interface IPermissionService
    {
        GetResults<BaseEntityDto> GetPermissions(PageInput input);

        UpdateResult UpdatePermission(BaseEntityDto action);

        CreateResult<int> CreatePermission(BaseEntityDto action);

        DeleteResult DeletePermission(int actionId);
    }
}