using System;
using System.Text.Json;
using System.Net;


public class PublicHolidaysService : IPublicHolidays
{

    public PublicHolidaysService() 
    { 
        
    }

    public async Task<PublicHoliday> GetPublicHoliday(string CountryCode, DateTime date, bool useProxy = true)
    {
        var jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        HttpClientHandler handler = new HttpClientHandler();
        if (useProxy)
        {
            IWebProxy proxy = WebRequest.GetSystemWebProxy();
            proxy.Credentials = CredentialCache.DefaultCredentials;
            handler.UseDefaultCredentials = true;
            handler.Proxy = proxy;
        }

        using var httpClient = new HttpClient(handler);
        using var response = await httpClient.GetAsync("https://date.nager.at/api/v3/publicholidays/2022/US");
        if (response.IsSuccessStatusCode)
        {
            using var jsonStream = await response.Content.ReadAsStreamAsync();
            var publicHolidays = JsonSerializer.Deserialize<PublicHoliday[]>(jsonStream, jsonSerializerOptions);

            if (publicHolidays != null)
                return publicHolidays.Where(x => x.Date == date).FirstOrDefault();
        }

        return null;
    }
}