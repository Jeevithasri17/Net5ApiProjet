using System;
using System.Collections.Generic;

#nullable disable

namespace Kanini.Service
{
    public partial class EmployeeDepartmentMapping
    {
        public Guid? EmpId { get; set; }
        public Guid? DeptId { get; set; }

        public virtual Department Dept { get; set; }
        public virtual Employee Emp { get; set; }
    }
}
