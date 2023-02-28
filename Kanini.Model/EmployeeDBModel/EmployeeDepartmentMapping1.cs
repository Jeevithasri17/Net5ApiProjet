using System;
using System.Collections.Generic;

#nullable disable

namespace Kanini.Service
{
    public partial class EmployeeDepartmentMapping1
    {
        public Guid? EmpId { get; set; }
        public Guid? DeptId { get; set; }

        public virtual Department1 Dept { get; set; }
        public virtual Employee1 Emp { get; set; }
    }
}
