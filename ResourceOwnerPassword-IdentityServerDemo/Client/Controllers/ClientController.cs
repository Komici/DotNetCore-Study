using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Controllers
{
    [Route("client")]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5000");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
            }

            // request token
            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,

                ClientId = "client",
                ClientSecret = "secret",
                Scope = "user_detail",

                UserName = "alice",
                Password = "password",
            });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
            }

            // call api
            var client2 = new HttpClient();
            client2.SetBearerToken(tokenResponse.AccessToken);

            var response = await client2.GetAsync("https://localhost:5001/api/identity");
            if (!response.IsSuccessStatusCode)
            {
                return Content(response.StatusCode.ToString());
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                return Content(content);
            }

            return Content(tokenResponse.Json.ToString());
            //Console.WriteLine(tokenResponse.Json);
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}
