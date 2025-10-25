using System;
using System.Collections.Generic;

namespace MVC_Vue.Databases;

public partial class ProductImage
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string Url { get; set; } = null!;

    public bool IsMain { get; set; }

    public short? DisplayOrder { get; set; }

    public virtual Product Product { get; set; } = null!;
}
