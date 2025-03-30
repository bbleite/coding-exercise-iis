using BankApplicationIIS.Repositories.Enumerations;
using System.Security.Principal;

namespace BankApplicationIIS.Repositories.Entities
{
    public class Account
    {
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public StatusEnumeration Status { get; set; }
        public int AccountTypeId { get; set; }
    }
}
