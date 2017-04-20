using EMS.Core.Domain.Entities;
using EMS.Domain.Hrm.Resorces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain.Hrm.Dto
{
    [Serializable()]
    public class EmployeeDto : BaseDto<long>
    {
        public int SalutationId { get; set; }

        [Required(ErrorMessageResourceName = "FirstNameIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessageResourceName = "LastNameIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        public string LastName { get; set; }

        public string NickName { get; set; }

        public string EmpName { get; set; }
    }
}
