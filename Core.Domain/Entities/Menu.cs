using Core.Domain.Common;

namespace Core.Domain.Entities
{
    public class Menu: BaseEntity
    {
        public string Name { get; set; } = null!;

        public string Url { get; set; } = null!;

        public short DisplayOrder { get; set; }
    }
}
