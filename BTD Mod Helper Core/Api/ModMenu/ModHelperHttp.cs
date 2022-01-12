using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BTD_Mod_Helper.Api.ModMenu
{
    /// <summary>
    /// Http client used by the mod helper
    /// </summary>
    public class ModHelperHttp
    {
        /// <summary>
        /// The HttpClient instance
        /// </summary>
        public static HttpClient Client { get; private set; }

        /// <summary>
        /// Initializes the HttpClient
        /// </summary>
        public static void Init()
        {
            Client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            Client.DefaultRequestHeaders.Add("user-agent",
                " Mozilla/5.0 (Windows NT 6.1; WOW64; rv:25.0) Gecko/20100101 Firefox/25.0");
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        }
    }
}