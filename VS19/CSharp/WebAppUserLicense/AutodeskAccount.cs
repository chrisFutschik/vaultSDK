using Autodesk.Connectivity.WebServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace WebAppUseUserLicense
{
    public class AutodeskAccount : IAutodeskAccount
    {
        private readonly string m_token;
        private static readonly string FORGE_GET_ME_URL = "https://developer.api.autodesk.com/userprofile/v1/users/@me";
        public string AccountId { get; }

        public string AccountEmail { get; }

        public string AccountDisplayName { get; }

        public bool IsLoggedIn { get; }

        public string GetAccessToken()
        {
            return m_token;
        }
        async public static Task<AutodeskAccount> BuildAccountAsync(string token)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add(/*msg0*/"Authorization", "Bearer " + token);
            HttpResponseMessage response = await client.GetAsync(FORGE_GET_ME_URL).ConfigureAwait(false);
            try
            {
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var payload = JsonConvert.DeserializeObject<ProfilePayload>(responseBody);
                var id = payload.userId;
                var email = payload.emailId;
                var dispName = payload.firstName + " " + payload.lastName;
                return new AutodeskAccount(token, id, email, dispName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private AutodeskAccount(string token, string id, string email, string dispName)
        {
            m_token = token;
            AccountId = id;
            AccountEmail = email;
            AccountDisplayName = dispName;
            IsLoggedIn = true;
        }
            
    }
    class ProfilePayload
    {
        public string userId { get; set; }
        public string userName { get; set; }
        public string emailId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string createdDate { get; set; }
    }
}