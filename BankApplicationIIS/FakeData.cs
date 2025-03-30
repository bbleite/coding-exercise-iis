using BankApplicationIIS.Repositories.Entities;
using BankApplicationIIS.Repositories.Enumerations;

namespace BankApplicationIIS
{
    //Fake data class to mimic a DbContext calling a database
    public class FakeData
    {
        private readonly List<Account> _accounts;
        private readonly List<Customer> _customers;

        public FakeData()
        {
            _accounts = new List<Account>
            {
                new Account { AccountId = 17, CustomerId = 5, Balance = 2175.13m, Status = StatusEnumeration.OPEN },
                new Account { AccountId = 18, CustomerId = 6, Balance = 2399.13m, Status = StatusEnumeration.OPEN },
                new Account { AccountId = 19, CustomerId = 7, Balance = 0.00m, Status = StatusEnumeration.OPEN },
                new Account { AccountId = 20, CustomerId = 5, Balance = 100.00m, Status = StatusEnumeration.OPEN }
            };

            _customers = new List<Customer>
            {
                new Customer { CustomerId = 5 },
                new Customer { CustomerId = 6 },
                new Customer { CustomerId = 7 },
                new Customer { CustomerId = 8 }
            };
        }

        public List<Account> Accounts
        {
            get { return _accounts; }
        }

        public List<Customer> Customers
        {
            get { return _customers; }
        }
    }
}
