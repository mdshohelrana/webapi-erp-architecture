using EMS.Domain.Hrm.Dto;
using EMS.Domain.Hrm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Services.Interfaces
{
    public interface IEmployeeApiController
    {
        HttpResponseMessage GetEmployeeById(long id);
        HttpResponseMessage Delete(long id);
        HttpResponseMessage Post(EmployeeDto employeeDto);
        HttpResponseMessage Put(EmployeeDto employeeDto);
    }
}
