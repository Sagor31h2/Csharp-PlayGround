using Microsoft.EntityFrameworkCore.Storage;
using transactionTest.models;
using transactionTest.services.Icountry;

namespace transactionTest.services
{
    public class TransactionService : ITransactionService
    {
        private readonly GeodbContext _context;

        public TransactionService(GeodbContext Context)
        {
            _context = Context;
        }

        public async Task<IDbContextTransaction> GetGeoDbTransaction()
        {
            IDbContextTransaction dbContextTransaction = await _context.Database.BeginTransactionAsync();
            return dbContextTransaction;
        }

        public async Task RollBackAsync(IDbContextTransaction transactionName)
        {
            await transactionName.RollbackAsync();
        }

        public async Task CommitAsync(IDbContextTransaction transactionName)
        {
            await transactionName.CommitAsync();

        }

        public async Task<string> SavepointAsync(IDbContextTransaction transactionName)
        {
            /*Guid ref https://stackoverflow.com/questions/1700361/how-to-convert-a-guid-to-a-string-in-c */
            string pointName = Guid.NewGuid().ToString("N");

            await transactionName.CreateSavepointAsync(pointName);
            return pointName;
        }

        public async Task RollbackToSavepointAsync(IDbContextTransaction transactionName, string pointName)
        {
            await transactionName.RollbackToSavepointAsync(pointName);
        }







    }
}
