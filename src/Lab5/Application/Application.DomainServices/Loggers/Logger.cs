using Application.Abstractions.Repositories;

namespace Application.DomainServices.Loggers;

public class Logger : ILogger
{
    private readonly ITransactionsRepo _transactionsRepo;
    public Logger(ITransactionsRepo transactionsRepo)
    {
        _transactionsRepo = transactionsRepo;
    }

    public void Log(Application.DomainModel.Transactions.Transaction transaction)
    {
        _transactionsRepo.Add(transaction);
    }
}