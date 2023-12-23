using Application.Contracts.Accounts;
using Application.DomainModel.Transactions;

namespace Application.Contracts.Transactions;

public class GetTransactionResponse
{
    public GetTransactionResponse(AccountOperationsResult response, IEnumerable<Transaction>? transactions)
    {
        Response = response;
        Transactions = transactions;
    }

    public AccountOperationsResult Response { get; set; }
    public IEnumerable<Transaction>? Transactions { get; set; }
}
