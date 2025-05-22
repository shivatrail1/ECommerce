﻿using System;
using System.Collections.Generic;

namespace ECommerce.Service.Models;

public partial class ProductImage
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public string? ImageUrl { get; set; }

    public bool? IsPrimary { get; set; }

    public virtual Product? Product { get; set; }
}
