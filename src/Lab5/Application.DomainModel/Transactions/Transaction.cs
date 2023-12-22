namespace Application.DomainModel.Transactions;

public class Transaction
{
    public Transaction(long id, TypeOfTranscations operation, int amountOfMoney)
    {
        Id = id;
        Operation = operation;
        AmountOfMoney = amountOfMoney;
    }

    public long Id { get; set; }
    public TypeOfTranscations Operation { get; set; }
    public int AmountOfMoney { get; set; }
}