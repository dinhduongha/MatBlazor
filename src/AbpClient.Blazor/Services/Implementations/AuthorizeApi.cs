//using Microsoft.AspNetCore.Components;
//using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AbpHelper;
using AbpHelper.Authenticate;
//using System.Text.Json.Serialization;
using Bamboo.AbpClient;
using BlazorBoilerplate.Shared.Services.Contracts;
using BlazorBoilerplate.Shared;
using AbpHelper.Accounts.Dto;

namespace BlazorBoilerplate.Shared.Services.Implementations
{
    public class AuthorizeApi : IAuthorizeApi
    {
        private readonly HttpClient _httpClient;
        private readonly IAbpClient _abpClient;
        private readonly AbpCoreService _abpCoreService;
        private AbpClient.Core.Model.CurrentUserInfo userInfo;
        public AuthorizeApi(IAbpClient abpClient, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _abpClient = abpClient;
        }

        public async Task<UserInfo> Login(LoginParameters loginParameters)
        {
            // Todo Handle StatusCodes??
            //var result = new UserInfo { IsAuthenticated = true, Username = "123" };
            //var result = await _httpClient.PostJsonAsync<UserInfo>("api/Authorize/Login", loginParameters); 
            AuthenticateModel model = new AuthenticateModel {
                UserNameOrEmailAddress = loginParameters.UserName,
                Password = loginParameters.Password,
                RememberClient = loginParameters.RememberMe,
            };
            var user = await _abpClient.Login(model);
            if (user != null)
            {
                userInfo = user;
                return new UserInfo { IsAuthenticated = true, Username = user.Username};
            }
            await Task.CompletedTask;
            return null;
        }

        public async Task Logout()
        {
            userInfo = null;
            //var result = await _httpClient.PostAsync("api/Authorize/Logout", null);
            //result.EnsureSuccessStatusCode();
            await _abpClient.Logout();
            await Task.CompletedTask;
        }

        public async Task<UserInfo> Register(RegisterParameters registerParameters)
        {
            RegisterInput input = new RegisterInput
            {
                UserName = registerParameters.UserName,
                EmailAddress = registerParameters.Email,
                Password = registerParameters.Password,
            };
            await _abpClient.Register(input);
            // Todo Handle StatusCodes??
            //var result = await _httpClient.PostJsonAsync<UserInfo>("api/Authorize/Register", registerParameters);
            //return result;
            return null;
        }

        public async Task<UserInfo> GetUserInfo()
        {
            //var result = await _httpClient.GetJsonAsync<UserInfo>("api/Authorize/UserInfo");
            //return result;
            //var user = _abpClient.
            //_abpCoreService.
            if (userInfo != null)
            {
                return new UserInfo { IsAuthenticated = true, Username = userInfo.Username };
            }
            await Task.CompletedTask;
            return null;
        }
    }
}
