using BankApplicationIIS.Repositories.Entities;
using BankApplicationIIS.Repositories.Interfaces;

namespace BankApplicationIIS.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly FakeData _fakeData;
        public AccountRepository(FakeData fakeData)
        {
            _fakeData = fakeData;
        }

        public Task<Account> GetAccountAsync(int customerId, int accountId)
        {
            var account = GetAccount(customerId, accountId);

            return account == null
                ? throw new KeyNotFoundException($"Account with ID {accountId} for customer {customerId} was not found.")
                : Task.FromResult(account);
        }

        public async Task<bool> UpdateAccountAsync(Account account)
        {
            var existingAccount = GetAccount(account.CustomerId, account.AccountId);
            if (existingAccount != null)
            {
                existingAccount.Balance = account.Balance;
                existingAccount.Status = account.Status;

                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> CreateAccountAsync(Account account)
        {
            _fakeData.Accounts.Add(account);
            return await Task.FromResult(_fakeData.Accounts.Contains(account));
        }

        public Task<Customer?> GetCustomer(int customerId)
        {
            var customer = _fakeData.Customers.FirstOrDefault(c => c.CustomerId == customerId);

            return Task.FromResult(customer);
        }

        public Task<IEnumerable<Account>> GetCustomerAccounts(int customerId)
        {
            var accounts = _fakeData.Accounts.Where(c => c.CustomerId == customerId);

            return Task.FromResult(accounts);
        }

        private Account? GetAccount(int customerId, int accountId)
        {
            return _fakeData.Accounts.FirstOrDefault(a => a.CustomerId == customerId && a.AccountId == accountId);
        }
    }
}
