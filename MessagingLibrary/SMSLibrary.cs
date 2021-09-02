using System.Threading.Tasks;
using System.Net.Http;

namespace MessagingLibraries
{
    public static class MessagingLibrary
    {

        public static async Task<string> SendSMS(string phoneNumber, string message, int languageCode)
        {
            string domainURL = "https://www.kwtsms.com/API/send/?username=routes&password=routes_@!3015";
            var requestURL = $"{domainURL}&sender=Routes&mobile={phoneNumber}&lang={languageCode}&message={message}";

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(requestURL))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return apiResponse;
                }
            }
        }

        public static async Task<string> CheckMessageStatus(string messageId)
        {//https://www.kwtsms.com/API/dlr/?username=myuser&password=mypass&msgid=xxxxxxxxx
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://www.kwtsms.com/API/dlr/?username=routes&password=routes_@!3015&msgid={messageId}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return apiResponse;
                }
            }
        }

        public static async Task<string> CheckBalance()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://www.kwtsms.com/API/balance/?username=routes&password=routes_@!3015"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return apiResponse;
                }
            }
        }


    }
}