
using SqlSugar;

namespace SS.Domain.Entities
{
    public class BaseEntity
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true,IsNullable = false)]
        public long Id { get; set; }
    }
}