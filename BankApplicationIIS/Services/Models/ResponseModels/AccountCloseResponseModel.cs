using BankApplicationIIS.Repositories.Enumerations;
using BankApplicationIIS.Services.Models.AbstractModels;

namespace BankApplicationIIS.Services.Models.ResponseModels
{
    public class AccountCloseResponseModel : AbstractResponseModel
    {
        public int AccountId { get; set; }
    }
}
