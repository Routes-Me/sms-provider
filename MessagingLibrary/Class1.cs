using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace MessagingLibraries
{
    public static class MessagingLibrary
    {
        static HttpClient client = new HttpClient();

        public static bool StartsWithUpper(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;

            char ch = str[0];
            return char.IsUpper(ch);
        }

        public static async Task<string> SendSMS(string phoneNumber, string message, int languageCode)
        {
            string domainURL = "https://www.kwtsms.com/API/send/?username=routes&password=routes_@!3015";
            var requestURL = $"{domainURL}&sender=Routes&mobile={phoneNumber}&lang={message}&message={languageCode}";
            HttpResponseMessage response = await client.GetAsync(requestURL);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<string>();
                return result;
            }
            return "Message delivery failed!!";
        }

        public static async Task<string> CheckBalance(this string str)
        {
            string requestURL = "https://www.kwtsms.com/API/balance/?username=routes&password=routes_@!3015";
            HttpResponseMessage response = await client.GetAsync(requestURL);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<string>();
            }
            return "Message delivery failed!!";
        }


    }
}