using System;
using System.Collections.Generic;

namespace MVC_Vue.Databases;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public double Discount { get; set; }

    public int Quantity { get; set; }

    public int CategoryId { get; set; }

    public string? Sku { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
}
