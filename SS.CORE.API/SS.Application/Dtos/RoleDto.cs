using System.Collections.Generic;

namespace SS.Application.Dtos
{
    public class RoleDto : BaseEntityDto
    {
        public List<BaseEntityDto> Permissions { get; set; } 
    }
}