using EMS.Domain.Hrm.Entities;
using EMS.Domain.Hrm.Repository;
using EMS.Domain.Services.Common;
using EMS.Domain.Services.Hrm.Interfaces;
using System;

namespace EMS.Domain.Services.Hrm.Implementations
{
    public class EmployeeService : Service<Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        #region Constructor

        public EmployeeService(IEmployeeRepository repository) : base(repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            _employeeRepository = repository;
        }

        #endregion

        #region Read Methods

        #endregion

        #region Write Methods

        #endregion
    }
}
