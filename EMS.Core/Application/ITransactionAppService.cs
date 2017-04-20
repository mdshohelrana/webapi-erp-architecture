namespace EMS.Core.Application
{
    public interface ITransactionAppService
    {
        void BeginTransaction();
        void Commit();
    }
}