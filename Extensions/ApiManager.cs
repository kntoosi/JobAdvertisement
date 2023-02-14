using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrouseServiceAdvertisement.Extensions
{
    public class ApiManager
    {
        private string ApiUrl;
        private string AccessToken;

        public ApiManager(string apiUrl, string accessToken = "")
        {
            this.ApiUrl = apiUrl;
            this.AccessToken = accessToken;
        }

        /// <summary>
        /// call API function.
        /// </summary>
        /// <remarks>
        /// this function call API and send input parameter as json and recieve json result. then convert recieved json to TRes output.
        /// </remarks>
        /// <typeparam name="TReq">Request type</typeparam>
        /// <typeparam name="TRes">Response type</typeparam>
        /// <param name="address">API address. for example: "/Auth/GetVendorInfo"</param>
        /// <param name="input">API input parameter. this parameter converted to json and sended to API.</param>
        /// <returns>API response</returns>
        public async Task<TRes> Call<TReq, TRes>(string address, TReq input)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    if (string.IsNullOrWhiteSpace(AccessToken) == false) httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccessToken);

                    StringContent content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
                    var response = httpClient.PostAsync(ApiUrl + address, content).Result;
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        TRes result = JsonConvert.DeserializeObject<TRes>(apiResponse);
                        return result;
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadGateway)
                    {
                        throw new Exception("ارتباط با سرور برقرار نمی باشد");
                    }
                    else
                    {
                        ValidationProblemDetails data = JsonConvert.DeserializeObject<ValidationProblemDetails>(apiResponse);
                        string _error = data.Title + (String.IsNullOrWhiteSpace(data.Detail) ? "" : "(" + data.Detail + ")");
                        throw new Exception(_error);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "ارتباط با سرور برقرار نمی باشد")
                    throw new Exception("ارتباط با سرور برقرار نمی باشد");
                else
                    throw; //new Exception("خطای نامشخص رخ داده است");
            }
        }

        /// <summary>
        /// call API function.
        /// </summary>
        /// <remarks>
        /// this function call API and send input parameter as json and recieve json result. then convert recieved json to TRes output.
        /// </remarks>
        /// <typeparam name="TReq">Request type</typeparam>
        /// <typeparam name="TRes">Response type</typeparam>
        /// <param name="address">API address. for example: "/Auth/GetVendorInfo"</param>
        /// <param name="input">API input parameter. this parameter converted to json and sended to API.</param>
        /// <returns>API response</returns>
        public async Task Call<TReq>(string address, TReq input)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccessToken);

                    StringContent content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(ApiUrl + address, content);
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        //JsonConvert.DeserializeObject(apiResponse);
                        // return;
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadGateway)
                    {
                        throw new Exception("ارتباط با سرور برقرار نمی باشد");
                    }
                    else
                    {
                        ValidationProblemDetails data = JsonConvert.DeserializeObject<ValidationProblemDetails>(apiResponse);
                        string _error = data.Title + (String.IsNullOrWhiteSpace(data.Detail) ? "" : "(" + data.Detail + ")");
                        throw new Exception(_error);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "ارتباط با سرور برقرار نمی باشد")
                    throw new Exception("ارتباط با سرور برقرار نمی باشد");
                else
                    throw; //new Exception("خطای نامشخص رخ داده است");
            }
        }

        public async Task<TRes> Call<TRes>(string address, string input)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccessToken);

                    StringContent content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(ApiUrl + address, content);
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        TRes result = JsonConvert.DeserializeObject<TRes>(apiResponse);
                        return result;
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadGateway)
                    {
                        throw new Exception("ارتباط با سرور برقرار نمی باشد");
                    }
                    else
                    {
                        ValidationProblemDetails data = JsonConvert.DeserializeObject<ValidationProblemDetails>(apiResponse);
                        string _error = data.Title + (String.IsNullOrWhiteSpace(data.Detail) ? "" : "(" + data.Detail + ")");
                        throw new Exception(_error);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "ارتباط با سرور برقرار نمی باشد")
                    throw new Exception("ارتباط با سرور برقرار نمی باشد");
                else
                    throw; //new Exception("خطای نامشخص رخ داده است");
            }
        }


        public async Task<string> Call(string address, string input)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccessToken);

                    StringContent content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(ApiUrl + address, content);
                    var apiResponse = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        return result;
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadGateway)
                    {
                        throw new Exception("ارتباط با سرور برقرار نمی باشد");
                    }
                    else
                    {
                        ValidationProblemDetails data = JsonConvert.DeserializeObject<ValidationProblemDetails>(apiResponse);
                        string _error = data.Title + (String.IsNullOrWhiteSpace(data.Detail) ? "" : "(" + data.Detail + ")");
                        throw new Exception(_error);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "ارتباط با سرور برقرار نمی باشد")
                    throw new Exception("ارتباط با سرور برقرار نمی باشد");
                else
                    throw; //new Exception("خطای نامشخص رخ داده است");
            }
        }

        public async Task<string> CallString<TReq>(string address, TReq input)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccessToken);

                    StringContent content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
                    var response = httpClient.PostAsync(ApiUrl + address, content).Result;
                    var apiResponse = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        return result;
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadGateway)
                    {
                        throw new Exception("ارتباط با سرور برقرار نمی باشد");
                    }
                    else
                    {
                        ValidationProblemDetails data = JsonConvert.DeserializeObject<ValidationProblemDetails>(apiResponse);
                        string _error = data.Title + (String.IsNullOrWhiteSpace(data.Detail) ? "" : "(" + data.Detail + ")");
                        throw new Exception(_error);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "ارتباط با سرور برقرار نمی باشد")
                    throw new Exception("ارتباط با سرور برقرار نمی باشد");
                else
                    throw; //new Exception("خطای نامشخص رخ داده است");
            }
        }

        public async Task CallGetWihthoutReturn(string address, string input)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccessToken);

                    var response = httpClient.GetAsync(ApiUrl + address + "?" + input).Result;

                    string apiResponse = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        //  return result;
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadGateway)
                    {
                        throw new Exception("ارتباط با سرور برقرار نمی باشد");
                    }
                    else
                    {
                        ValidationProblemDetails data = JsonConvert.DeserializeObject<ValidationProblemDetails>(apiResponse);
                        string _error = data.Title + (String.IsNullOrWhiteSpace(data.Detail) ? "" : "(" + data.Detail + ")");
                        throw new Exception(_error);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "ارتباط با سرور برقرار نمی باشد")
                    throw new Exception("ارتباط با سرور برقرار نمی باشد");
                else
                    throw; //new Exception("خطای نامشخص رخ داده است");
            }
        }

        public async Task<string> CallGetStringReturn(string address, string input)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccessToken);

                    var response = httpClient.GetAsync(ApiUrl + address + "?" + input).Result;

                    string apiResponse = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        return result;
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadGateway)
                    {
                        throw new Exception("ارتباط با سرور برقرار نمی باشد");
                    }
                    else
                    {
                        ValidationProblemDetails data = JsonConvert.DeserializeObject<ValidationProblemDetails>(apiResponse);
                        string _error = data.Title + (String.IsNullOrWhiteSpace(data.Detail) ? "" : "(" + data.Detail + ")");
                        throw new Exception(_error);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "ارتباط با سرور برقرار نمی باشد")
                    throw new Exception("ارتباط با سرور برقرار نمی باشد");
                else
                    throw; //new Exception("خطای نامشخص رخ داده است");
            }
        }


        public async Task<TRes> CallGetAsync<TRes>(string address, string input)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccessToken);

                    var response = httpClient.GetAsync(ApiUrl + address + "?" + input).Result;

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        TRes result = JsonConvert.DeserializeObject<TRes>(apiResponse);
                        return result;
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadGateway)
                    {
                        throw new Exception("ارتباط با سرور برقرار نمی باشد");
                    }
                    else
                    {
                        ValidationProblemDetails data = JsonConvert.DeserializeObject<ValidationProblemDetails>(apiResponse);
                        string _error = data.Title + (String.IsNullOrWhiteSpace(data.Detail) ? "" : "(" + data.Detail + ")");
                        throw new Exception(_error);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "ارتباط با سرور برقرار نمی باشد")
                    throw new Exception("ارتباط با سرور برقرار نمی باشد");
                else
                    throw; //new Exception("خطای نامشخص رخ داده است");
            }
        }

        public async Task<List<string>> CallGetListAsync<TRes>(string address)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccessToken);

                    var response = httpClient.GetAsync(ApiUrl + address).Result;
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        List<string> result = JsonConvert.DeserializeObject<List<string>>(apiResponse);
                        return result;
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadGateway)
                    {
                        throw new Exception("ارتباط با سرور برقرار نمی باشد");
                    }
                    else
                    {
                        ValidationProblemDetails data = JsonConvert.DeserializeObject<ValidationProblemDetails>(apiResponse);
                        string _error = data.Title + (String.IsNullOrWhiteSpace(data.Detail) ? "" : "(" + data.Detail + ")");
                        throw new Exception(_error);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "ارتباط با سرور برقرار نمی باشد")
                    throw new Exception("ارتباط با سرور برقرار نمی باشد");
                else
                    throw; //new Exception("خطای نامشخص رخ داده است");
            }
        }


        public async Task<TRes> CallGetAsync<TRes>(string address)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccessToken);

                    var response = httpClient.GetAsync(ApiUrl + address).Result;
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        TRes result = JsonConvert.DeserializeObject<TRes>(apiResponse);
                        return result;
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadGateway)
                    {
                        throw new Exception("ارتباط با سرور برقرار نمی باشد");
                    }
                    else
                    {
                        ValidationProblemDetails data = JsonConvert.DeserializeObject<ValidationProblemDetails>(apiResponse);
                        string _error = data.Title + (String.IsNullOrWhiteSpace(data.Detail) ? "" : "(" + data.Detail + ")");
                        throw new Exception(_error);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "ارتباط با سرور برقرار نمی باشد")
                    throw new Exception("ارتباط با سرور برقرار نمی باشد");
                else
                    throw; //new Exception("خطای نامشخص رخ داده است");
            }
        }

        public async Task<string> CallGetNoneInput(string address)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccessToken);

                    var response = httpClient.GetAsync(ApiUrl + address).Result;
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        return result;
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadGateway)
                    {
                        throw new Exception("ارتباط با سرور برقرار نمی باشد");
                    }
                    else
                    {
                        ValidationProblemDetails data = JsonConvert.DeserializeObject<ValidationProblemDetails>(apiResponse);
                        string _error = data.Title + (String.IsNullOrWhiteSpace(data.Detail) ? "" : "(" + data.Detail + ")");
                        throw new Exception(_error);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "ارتباط با سرور برقرار نمی باشد")
                    throw new Exception("ارتباط با سرور برقرار نمی باشد");
                else
                    throw; //new Exception("خطای نامشخص رخ داده است");
            }
        }


    }
}
