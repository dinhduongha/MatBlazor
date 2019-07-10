using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

using AbpHelper;
using AbpHelper.Ajax;
using AbpHelper.Ajax.Dto;
using AbpCommon.Dto;

using Bamboo.AbpClient;

namespace AbpClient.Shared.Extensions
{
    public static class AbpExtensionsCurrencyService
    {
        #region Currencry

        public static async Task<CurrencyDto> CurrencyCreateAsync(this AbpCoreService service, CreateCurrencyDto input)
        {   
            try
            {
                var api = service.api;
                var response = await api.Create<CurrencyDto>("/api/QSMS/Currency/Create", input);
                if (response != null)
                {
                    return response;
                }
            }
            catch
            {
            }
            return null;
        }
        public static async Task<List<CurrencyDto>> CurrencyGetAllAsync(this AbpCoreService service )
        {
            try
            {
                var api = service.api;
                var response = await api.Read<PagedResultDto<CurrencyDto>>("/api/QSMS/Currency/GetAll");
                return (List<CurrencyDto>)response.Items;
            }
            catch (Exception e)
            {
                var str = e.Message;
            }
            return null;
        }
        public static async Task<CurrencyDto> CurrencyGetAsync(this AbpCoreService service , long id)
        {
            try
            {
                var api = service.api;
                var response = await api.Read<CurrencyDto>($"/api/QSMS/Currency/Get?Id={id}");
                return response;
            }
            catch
            {
            }
            return null;
        }
        public static async Task<CurrencyDto> CurrencyUpdateAsync(this AbpCoreService service , CurrencyDto obj)
        {            
            try
            {
                var api = service.api;
                var response = await api.Update<CurrencyDto>("/api/QSMS/Currency/Update", obj);
                if (response != null)
                {
                    return response;
                }
            }
            catch
            {
            }
            return null;
        }
        public async static Task<bool> CurrencyDeleteAsync(this AbpCoreService service , long id)
        {
            try
            {
                var api = service.api;
                var response = await api.Delete<bool>($"/api/QSMS/Currency/Delete?Id={id}");
                return response;
            }
            catch
            { }
            return false;
        }

        #endregion
    }
}

