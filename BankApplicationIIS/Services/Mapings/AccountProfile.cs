using AutoMapper;
using BankApplicationIIS.Repositories.Entities;
using BankApplicationIIS.Services.Models.RequestModels;
using BankApplicationIIS.Services.Models.ResponseModels;

namespace BankApplicationIIS.Services.Mapings
{
    public class AccountProfile : Profile
    {
        public AccountProfile() 
        {
            CreateMap<TransactionRequestModel, Account>()
                .ForMember(dest => dest.Balance, opt => opt.Ignore());
            CreateMap<Account, TransactionResponseModel>();
            CreateMap<AccountCloseRequestModel, Account>();
            CreateMap<Account,  AccountCloseResponseModel>();
            CreateMap<AccountCreateRequestModel, Account>();
            CreateMap<Account, AccountCreateResponseModel>();
        }
    }
}
