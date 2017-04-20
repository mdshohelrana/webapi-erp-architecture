using EMS.Core.Application;
using EMS.Core.Domain.Entities;
using EMS.Core.Domain.Validation;
using EMS.Core.Infra.Data;

namespace EMS.Application.Common
{
    public class AppService : ITransactionAppService, IAggregateRoot
    {
        //private IUnitOfWork _uow;

        protected ValidationResult ValidationResult { get; private set; }

        public AppService()
        {
            ValidationResult = new ValidationResult();
            //_uow = uow;
        }

        public void BeginTransaction()
        {
            //_uow = ServiceLocator.Current.GetInstance<IUnitOfWork>();
            //_uow.BeginTransaction();
        }

        public void Commit()
        {
            //_uow.Commit();
        }
    }
}
