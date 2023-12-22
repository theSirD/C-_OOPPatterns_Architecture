namespace Application.Domain;

public class Transaction
{
    private TypeOfTranscations _operation;
    private int _amountOfMoney;

    public Transaction(TypeOfTranscations operation, int amountOfMoney)
    {
        _operation = operation;
        _amountOfMoney = amountOfMoney;
    }
}