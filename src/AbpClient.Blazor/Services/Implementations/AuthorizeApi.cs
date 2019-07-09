﻿using BlazorBoilerplate.Client.Services.Contracts;
using BlazorBoilerplate.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace BlazorBoilerplate.Client.Services.Implementations
{
    public class AuthorizeApi : IAuthorizeApi
    {
        private readonly HttpClient _httpClient;

        public AuthorizeApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserInfo> Login(LoginParameters loginParameters)
        {
            // Todo Handle StatusCodes??
            var result = new UserInfo { IsAuthenticated = true, Username = "123" };
            //var result = await _httpClient.PostJsonAsync<UserInfo>("api/Authorize/Login", loginParameters);            
            await Task.CompletedTask;
            return result;
        }

        public async Task Logout()
        {
            var result = await _httpClient.PostAsync("api/Authorize/Logout", null);
            result.EnsureSuccessStatusCode();
        }

        public async Task<UserInfo> Register(RegisterParameters registerParameters)
        {
            // Todo Handle StatusCodes??
            var result = await _httpClient.PostJsonAsync<UserInfo>("api/Authorize/Register", registerParameters);
            return result;
        }

        public async Task<UserInfo> GetUserInfo()
        {
            var result = await _httpClient.GetJsonAsync<UserInfo>("api/Authorize/UserInfo");
            return result;
        }
    }
}
