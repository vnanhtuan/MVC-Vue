﻿using System;
using System.Collections.Generic;

namespace MVC_Vue.Databases;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
