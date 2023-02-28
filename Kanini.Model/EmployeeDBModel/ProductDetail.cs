using System;
using System.Collections.Generic;

#nullable disable

namespace Kanini.Service
{
    public partial class ProductDetail
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public int? ItemsInStock { get; set; }
    }
}
