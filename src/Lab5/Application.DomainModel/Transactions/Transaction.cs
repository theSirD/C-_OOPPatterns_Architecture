namespace Application.DomainModel.Transactions;

public class Transaction
{
    public Transaction(long id, long accountId, TypeOfTranscations operation, int amountOfMoney)
    {
        Id = id;
        AccountId = accountId;
        Operation = operation;
        AmountOfMoney = amountOfMoney;
    }

    public long Id { get; set; }

    public long AccountId { get; set; }
    public TypeOfTranscations Operation { get; set; }
    public int AmountOfMoney { get; set; }
}