using BankApplicationIIS.Repositories.Enumerations;
using BankApplicationIIS.Services.Models.AbstractModels;

namespace BankApplicationIIS.Services.Models.RequestModels
{
    public class AccountCloseRequestModel : AbstractRequestModel
    {
        public int AccountId { get; set; }
    }
}
