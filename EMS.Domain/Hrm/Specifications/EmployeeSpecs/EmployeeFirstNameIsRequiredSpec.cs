using EMS.Core.Domain.Specification;
using EMS.Domain.Hrm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace EMS.Domain.Hrm.Specifications.EmployeeSpecs
{
    public class EmployeeFirstNameIsRequiredSpec : SpecificationBase<Employee>
    {
        public override bool IsSatisfiedBy(Employee obj)
        {
            return obj.FirstName.Trim().Length > 0;
        }
    }
}
