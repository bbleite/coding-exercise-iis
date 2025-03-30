using AutoMapper;
using BankApplicationIIS.Repositories.Entities;
using BankApplicationIIS.Repositories.Enumerations;
using BankApplicationIIS.Repositories.Interfaces;
using BankApplicationIIS.Services.Interfaces;
using BankApplicationIIS.Services.Models.RequestModels;
using BankApplicationIIS.Services.Models.ResponseModels;

namespace BankApplicationIIS.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        #region Deposit
        public async Task<TransactionResponseModel> DepositAsync(TransactionRequestModel request)
        {
            try
            {
                //Check if account exists and belongs to customer
                var account = await GetAccountAsync(request.CustomerId, request.AccountId);

                //Update account balance and account
                account.Balance += request.Amount;

                return await TransactionResponse(account);
            }
            catch (KeyNotFoundException ex)
            {
                throw new InvalidOperationException($"Deposit failed: {ex.Message}");
            }
        }
        #endregion

        #region Withdrawal
        public async Task<TransactionResponseModel> WithdrawalAsync(TransactionRequestModel request)
        {
            if (request.Amount <= 0)
            {
                throw new InvalidOperationException("Please enter an amount greater than 0.");
            }

            try
            {
                //Check if account exists and belongs to customer
                var account = await GetAccountAsync(request.CustomerId, request.AccountId);

                //Update account balance and account
                account.Balance -= request.Amount;

                if (account.Balance < 0)
                {
                    throw new InvalidOperationException("This withdrawal will bring the balance below 0. Transaction cancelled.");
                }

                return await TransactionResponse(account);
            }
            catch (KeyNotFoundException ex)
            {
                throw new InvalidOperationException($"Withdrawal failed: {ex.Message}");
            }
        }
        #endregion

        #region Close account
        public async Task<AccountCloseResponseModel> AccountCloseAsync(AccountCloseRequestModel request)
        {
            try
            {
                //Get account
                var account = await GetAccountAsync(request.CustomerId, request.AccountId);

                //Close account only if balance = 0
                if (account.Balance == 0)
                {
                    account.Status = StatusEnumeration.CLOSED;
                    var accountClosed = await _accountRepository.UpdateAccountAsync(account);
                    var response = _mapper.Map<AccountCloseResponseModel>(account);
                    response.Succeeded = accountClosed;

                    return response;
                }
                else
                {
                    throw new InvalidOperationException("Account balance is not 0. Can't close account");
                }
            }
            catch (KeyNotFoundException ex)
            {
                throw new InvalidOperationException($"Account closure failed: {ex.Message}");
            }
        }
        #endregion

        #region Open account
        public async Task<AccountCreateResponseModel> AccountCreateAsync(AccountCreateRequestModel request)
        {
            if (request.InitialDeposit < 100)
            {
                throw new InvalidOperationException("Initial deposit must be at least $100.");
            }
            try
            {
                //Check if customer exists
                var customer = await GetCustomerAsync(request.CustomerId);

                var randomAccountId = new Random();
                int randomInt = randomAccountId.Next(30, 100);

                var account = new Account()
                {
                    CustomerId = request.CustomerId,
                    AccountId = randomInt,
                    Balance = request.InitialDeposit,
                    Status = StatusEnumeration.OPEN,
                    AccountTypeId = request.AccountTypeId,
                };

                //Check if this is user's first account and set correct account type
                var accounts = await GetCustomerAccountsAsync(request.CustomerId);
                if (!accounts.Any())
                {
                    account.AccountTypeId = 2; //First account should be of type Savings                   
                }

                var accountCreated = await _accountRepository.CreateAccountAsync(account);
                var response = _mapper.Map<AccountCreateResponseModel>(account);
                response.Succeeded = accountCreated;

                return response;

            }
            catch (KeyNotFoundException ex)
            {
                throw new InvalidOperationException($"Account creation failed: {ex.Message}");
            }
        }
        #endregion

        public async Task<Account> GetAccountAsync(int customerId, int accountId)
        {
            try
            {
                return await _accountRepository.GetAccountAsync(customerId, accountId);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException($"{ex.Message}");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Account>> GetCustomerAccountsAsync(int customerId)
        {
            return await _accountRepository.GetCustomerAccounts(customerId);
        }

        public async Task<Customer?> GetCustomerAsync(int customerId)
        {
            var customer = await _accountRepository.GetCustomer(customerId);

            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {customerId} does not exist.");
            }

            return customer;
        }

        private async Task<TransactionResponseModel> TransactionResponse(Account account)
        {
            var accountUpdated = await _accountRepository.UpdateAccountAsync(account);
            var response = _mapper.Map<TransactionResponseModel>(account);
            response.Succeeded = accountUpdated;

            return response;
        }
    }
}
