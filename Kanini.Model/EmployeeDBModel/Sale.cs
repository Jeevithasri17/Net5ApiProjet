using System;
using System.Collections.Generic;

#nullable disable

namespace Kanini.Service
{
    public partial class Sale
    {
        public int Id { get; set; }
        public string Salesperson { get; set; }
        public decimal? SaleAmount { get; set; }
        public DateTime? SaleDate { get; set; }
    }
}
