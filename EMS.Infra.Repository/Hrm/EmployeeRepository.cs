using EMS.Core.Domain.Repository;
using EMS.Core.Infra.Data;
using EMS.Domain.Hrm.Entities;
using EMS.Domain.Hrm.Repository;
using EMS.Infra.Repository.NH;

namespace EMS.Infra.Repository.Hrm
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
