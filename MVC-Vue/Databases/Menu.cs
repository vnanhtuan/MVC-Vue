using System;
using System.Collections.Generic;

namespace MVC_Vue.Databases;

public partial class Menu
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Url { get; set; } = null!;

    public short DisplayOrder { get; set; }
}
