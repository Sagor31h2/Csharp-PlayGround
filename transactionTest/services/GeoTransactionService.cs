using Microsoft.EntityFrameworkCore.Storage;
using transactionTest.models;
using transactionTest.services.Icountry;

namespace transactionTest.services
{
    public class GeoTransactionService : IGeoTransactionService
    {
        private readonly GeodbContext _context;

        private IDbContextTransaction _transaction;

        public GeoTransactionService(GeodbContext context)
        {
            _context = context;

        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task RollBackAsync()
        {
            await _transaction.RollbackAsync();
        }

        public async Task CommitAsync()
        {
            await _transaction.CommitAsync();

        }

        public async Task<string> SavepointAsync()
        {
            /*Guid ref https://stackoverflow.com/questions/1700361/how-to-convert-a-guid-to-a-string-in-c */
            string pointName = Guid.NewGuid().ToString("N");
            await _transaction.CreateSavepointAsync(pointName);
            return pointName;
        }

        public async Task RollbackToSavepointAsync(string pointName)
        {
            await _transaction.RollbackToSavepointAsync(pointName);
        }
    }
}
