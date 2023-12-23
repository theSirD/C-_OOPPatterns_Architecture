namespace Application.DomainServices.Loggers;

public interface ILogger
{
    public void Log(Application.DomainModel.Transactions.Transaction transaction);
}