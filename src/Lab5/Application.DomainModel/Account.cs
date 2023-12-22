namespace Application.Domain;

public class Account
{
    private int _id;
    private int _balance;

    public Account(int id, int balance)
    {
        _id = id;
        _balance = balance;
    }
}