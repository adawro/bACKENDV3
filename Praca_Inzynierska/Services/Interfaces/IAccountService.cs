using System.Threading.Tasks;
using Praca_Inzynierska.DTO;
using Praca_Inzynierska.Services.Communication;

namespace Praca_Inzynierska.Services.Interfaces
{
    public interface IAccountService
    {
        Task<AccountResponse> RegisterAccountAsync(RegisterAccountDto model);
        Task<AccountResponse> LoginAccountAsync(LoginAccountDto model);
        AccountResponse EditNameSurname(AccountEditNameSurnameDto model);
        AccountResponse EditUserName(AccountUserNameEditDto model);
        Task<AccountResponse> ChangePassword(AccountEditPasswordDto passwordDto);
        Task<AccountResponse> EditEmail(AccountEditEmailDto emailDto);
    }
}
