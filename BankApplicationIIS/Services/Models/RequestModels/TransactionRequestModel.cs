using BankApplicationIIS.Services.Models.AbstractModels;

namespace BankApplicationIIS.Services.Models.RequestModels
{
    public class TransactionRequestModel : AbstractRequestModel
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
