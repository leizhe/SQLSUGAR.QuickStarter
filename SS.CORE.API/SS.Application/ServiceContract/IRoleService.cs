﻿using SS.Application.Dtos;
using SS.Application.Input;
using SS.Application.Output;

namespace ED.Application.ServiceContract
{
    public interface IRoleService
    {
        GetResults<RoleDto> GetRoles(RoleInput input);

        CreateResult<int> CreateRole(RoleDto role);

        UpdateResult UpdateRole(RoleDto role);

        DeleteResult DeleteRole(int roleId);
    }
}