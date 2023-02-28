using System;
using System.Collections.Generic;

#nullable disable

namespace Kanini.Service
{
    public partial class ErrorLog1
    {
        public int Id { get; set; }
        public string ErrorMessage { get; set; }
        public int ErrorSeverity { get; set; }
        public int ErrorState { get; set; }
        public int? ErrorLine { get; set; }
        public DateTime ErrorTime { get; set; }
    }
}
