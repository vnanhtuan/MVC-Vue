﻿namespace Core.Domain.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string Url { get; set; } = null!;

        public bool IsMain { get; set; }

        public short? DisplayOrder { get; set; }
        public string? PublicId { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
