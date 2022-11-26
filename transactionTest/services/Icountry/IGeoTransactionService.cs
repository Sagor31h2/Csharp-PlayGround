namespace transactionTest.services.Icountry
{
    public interface IGeoTransactionService
    {
        Task BeginTransactionAsync();
        Task RollBackAsync();
        Task CommitAsync();
        Task<string> SavepointAsync();
        Task RollbackToSavepointAsync(string pointName);
    }
}
