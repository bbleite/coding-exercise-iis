namespace BankApplicationIIS.Services.Models.AbstractModels
{
    public abstract class AbstractResponseModel
    {
        public int CustomerId { get; set; }
        public bool Succeeded { get; set; }
    }
}
