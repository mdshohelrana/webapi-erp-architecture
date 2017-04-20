using EMS.Core.Domain.Repository;
using EMS.Domain.Hrm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain.Hrm.Repository.ReadOnly
{
    public interface IEmployeeReadOnlyRepository : IReadOnlyRepository<Employee>
    {

    }
}
