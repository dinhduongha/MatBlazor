using BlazorBoilerplate.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Shared.Services.Contracts
{
    public interface IAuthorizeApi
    {
        Task<UserInfo> Login(LoginParameters loginParameters);
        Task<UserInfo> Register(RegisterParameters registerParameters);
        Task ForgotPassword(ForgotPasswordParameters forgotPasswordParameters);
        Task ResetPassword(ResetPasswordParameters resetPasswordParameters);
        Task Logout();
        Task ConfirmEmail(ConfirmEmailParameters confirmEmailParameters);
        Task<UserInfo> GetUserInfo();
    }
}
