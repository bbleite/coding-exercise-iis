using BankApplicationIIS.Repositories.Entities;

namespace BankApplicationIIS.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> GetAccountAsync(int customerId, int accountId);
        Task<bool> UpdateAccountAsync(Account account);
        Task<bool> CreateAccountAsync(Account account);
        Task<Customer?> GetCustomer(int customerId);
        Task<IEnumerable<Account>> GetCustomerAccounts(int customerId);
    }
}
