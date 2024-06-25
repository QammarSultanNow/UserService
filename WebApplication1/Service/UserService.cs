using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using System.Text.Json;
using WebApplication1.Interface;
using WebApplication1.ServiceUrl;
using Microsoft.Extensions.Options;

namespace WebApplication1.Repository
{
    public class UserService :  IUserService
    {
        static readonly HttpClient client = new HttpClient();

        private readonly ServiceUrl.ServiceUrl _options;

        public UserService(IOptions<ServiceUrl.ServiceUrl> options)
        {
            _options = options.Value;
        }

       

        public async Task<IEnumerable<User>> GetUserInformation()
        {
            try
            {

                using HttpResponseMessage response = await client.GetAsync(_options.Url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();


                var result = JsonSerializer.Deserialize<IEnumerable<User>>(responseBody);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }


        public async Task<string> DownloadAvatar(string avatarUrl)
        {
            var path = "wwwroot\\";
           // var path = "C:\\Users\\Admin\\source\\repos\\WebApplication1\\WebApplication1\\wwwroot\\";
            var imgName = Guid.NewGuid().ToString() +".png";

            var fullPath = path + imgName;  
            using (WebClient client = new WebClient())
            {
               client.DownloadFile(avatarUrl, fullPath);
            }

            return imgName;
        }



    }
}
