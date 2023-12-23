namespace Application.DomainModel;

public class Account
{
    public Account(long id, long userId, int balance)
    {
        Id = id;
        UserId = userId;
        Balance = balance;
    }

    public long Id { get; set; }

    public long UserId { get; set; }

    public int Balance { get; set; }
}
