using Microsoft.EntityFrameworkCore.Storage;

namespace transactionTest.services.Icountry
{
    public interface ITransactionService
    {
        Task<IDbContextTransaction> GetGeoDbTransaction();
        Task RollBackAsync(IDbContextTransaction transactionName);
        Task CommitAsync(IDbContextTransaction transactionName);
        Task<string> SavepointAsync(IDbContextTransaction transactionName);
        Task RollbackToSavepointAsync(IDbContextTransaction transactionName, string pointName);

    }
}
