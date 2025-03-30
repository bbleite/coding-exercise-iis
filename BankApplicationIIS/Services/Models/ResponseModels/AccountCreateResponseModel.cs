using BankApplicationIIS.Services.Models.AbstractModels;

namespace BankApplicationIIS.Services.Models.ResponseModels
{
    public class AccountCreateResponseModel : AbstractResponseModel
    {
        public int AccountId { get; set; }
        public int AccountTypeId { get; set; }
        public decimal Balance { get; set; }
    }
}
