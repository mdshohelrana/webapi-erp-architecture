using EMS.Application.Common;
using EMS.Application.Hrm.Interfaces;
using System;
using System.Collections.Generic;
using EMS.Core.Domain.Specification;
using EMS.Core.Domain.Validation;
using EMS.Domain.Hrm.Entities;
using EMS.Domain.Services.Hrm.Interfaces;
using EMS.Domain.Hrm.Dto;
using AutoMapper;

namespace EMS.Application.Hrm.Implementations
{
    public class EmployeeAppService : AppService, IEmployeeAppService
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        #region Constructor

        public EmployeeAppService(IEmployeeService employeeService, IMapper mapper)
        {
            if (employeeService == null)
                throw new ArgumentNullException("employeeService");

            if (mapper == null)
                throw new ArgumentNullException("mapper");

            _employeeService = employeeService;
            _mapper = mapper;
        }

        #endregion

        #region Read Methods

        public EmployeeDto GetById(object id, bool @readonly)
        {
            Employee employee = _employeeService.GetById(id);
            var employeeDtos = _mapper.Map<EmployeeDto>(employee);
            return employeeDtos;
        }

        //public EmployeeDto FindBy(ISpecification<EmployeeDto> spec, bool @readonly = false)
        //{
        //    throw new NotImplementedException();
        //    //return _employeeService.FindBy(spec, @readonly);
        //}

        //public IEnumerable<EmployeeDto> FilterBy(ISpecification<EmployeeDto> spec, bool @readonly = false)
        //{
        //    throw new NotImplementedException();
        //    //return _employeeService.FilterBy(spec, @readonly);
        //}

        //public IEnumerable<EmployeeDto> GetAll(bool @readonly = false)
        //{
        //    throw new NotImplementedException();
        //    //return _employeeService.GetAll(@readonly);
        //}

        //public EmployeeDto GetById(object id, bool @readonly = false)
        //{
        //    throw new NotImplementedException();
        //    //return _employeeService.GetById(id, @readonly);
        //}

        #endregion

        #region Operations

        public ValidationResult Create(EmployeeDto entity)
        {
            //BeginTransaction();
            //ValidationResult.Add(_service.Add(employee));
            if (ValidationResult.IsValid)
            {
                //Commit();
            }

            return ValidationResult;
        }

        public ValidationResult Create(IEnumerable<EmployeeDto> entities)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Update(EmployeeDto entity)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Update(IEnumerable<EmployeeDto> entities)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Remove(EmployeeDto employeeDto)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Remove(IEnumerable<EmployeeDto> entities)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
        }

        ~EmployeeAppService()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }

        public Employee FindBy(ISpecification<Employee> spec, bool @readonly = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> FilterBy(ISpecification<Employee> spec, bool @readonly = false)
        {
            throw new NotImplementedException();
        }

        //IEnumerable<Employee> IAppService<Employee>.GetAll(bool @readonly)
        //{
        //    throw new NotImplementedException();
        //}

        public ValidationResult Create(Employee entity)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Create(IEnumerable<Employee> entities)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Update(Employee entity)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Update(IEnumerable<Employee> entities)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Remove(object id)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Remove(IEnumerable<Employee> entities)
        {
            throw new NotImplementedException();
        }

        public EmployeeDto FindBy(ISpecification<EmployeeDto> spec, bool @readonly = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeDto> FilterBy(ISpecification<EmployeeDto> spec, bool @readonly = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeDto> GetAll(bool @readonly = false)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
