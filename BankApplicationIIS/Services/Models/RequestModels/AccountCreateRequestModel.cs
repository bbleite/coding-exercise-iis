using BankApplicationIIS.Services.Models.AbstractModels;

namespace BankApplicationIIS.Services.Models.RequestModels
{
    public class AccountCreateRequestModel : AbstractRequestModel
    {
        public decimal InitialDeposit { get; set; }
        public int AccountTypeId { get; set; }
    }
}
