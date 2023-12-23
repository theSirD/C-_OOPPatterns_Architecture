using Application.DomainModel.Transactions;

namespace Application.Abstractions.Repositories;

public interface ITransactionsRepo
{
    public void Add(Transaction transaction);

    public IEnumerable<Transaction> GetAllTransactionsByUserId(long userId);
}