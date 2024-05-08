using System;
using System.Collections.Generic;

namespace MVC_CORE_Ass.Models;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}
