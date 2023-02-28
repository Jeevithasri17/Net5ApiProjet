using System;
using System.Collections.Generic;

#nullable disable

namespace Kanini.Service
{
    public partial class Folder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
