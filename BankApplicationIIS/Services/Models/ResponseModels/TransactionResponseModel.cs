using BankApplicationIIS.Services.Models.AbstractModels;

namespace BankApplicationIIS.Services.Models.ResponseModels
{
    public class TransactionResponseModel : AbstractResponseModel
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
    }
}
