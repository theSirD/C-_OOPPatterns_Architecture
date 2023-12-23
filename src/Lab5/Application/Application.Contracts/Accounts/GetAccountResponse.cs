using Application.DomainModel;

namespace Application.Contracts.Accounts;

public class GetAccountResponse
{
    public GetAccountResponse(AccountOperationsResult response, IEnumerable<Account>? account)
    {
        Response = response;
        Account = account;
    }

    public AccountOperationsResult Response { get; set; }
    public IEnumerable<Account>? Account { get; set; }
}