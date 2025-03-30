using BankApplicationIIS.Repositories.Entities;
using BankApplicationIIS.Services.Models.RequestModels;
using BankApplicationIIS.Services.Models.ResponseModels;

namespace BankApplicationIIS.Services.Interfaces
{
    public interface IAccountService
    {
        Task<TransactionResponseModel> DepositAsync(TransactionRequestModel request); 
        Task<TransactionResponseModel> WithdrawalAsync(TransactionRequestModel request);
        Task<AccountCloseResponseModel> AccountCloseAsync(AccountCloseRequestModel request);
        Task<AccountCreateResponseModel> AccountCreateAsync(AccountCreateRequestModel request);
        Task<Account> GetAccountAsync(int customerId, int accountId);
        Task<IEnumerable<Account>> GetCustomerAccountsAsync(int customerId);
        Task<Customer?> GetCustomerAsync(int customerId);
    }
}
