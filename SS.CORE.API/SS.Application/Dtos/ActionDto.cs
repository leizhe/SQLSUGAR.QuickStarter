using System.Collections.Generic;

namespace SS.Application.Dtos
{
    public class ActionDto : BaseEntityDto
    {
        public List<BaseEntityDto> Roles { get; set; }

        public List<BaseEntityDto> Users { get; set; }
    }
}