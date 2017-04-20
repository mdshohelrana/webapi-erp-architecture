using EMS.Core.Domain.Validation;
using EMS.Domain.Hrm.Entities;
using EMS.Domain.Hrm.Resorces;
using EMS.Domain.Hrm.Specifications.EmployeeSpecs;

namespace EMS.Domain.Hrm.Validations
{
    public class EmployeeIsValidValidation : Validation<Employee>
    {
        public EmployeeIsValidValidation()
        {
            base.AddRule(new ValidationRule<Employee>(new EmployeeFirstNameIsRequiredSpec(), ValidationMessages.FirstNameIsRequired));
        }
    }
}