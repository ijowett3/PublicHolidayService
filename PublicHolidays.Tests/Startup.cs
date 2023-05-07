using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PublicHolidays.Tests
{
    public class Startup
    {
        public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddUserSecrets("e3dfcccf-0cb3-423a-b302-e3e92e95c128")
                .AddEnvironmentVariables()
                .Build();
        }

        public static IConfiguration InitConfiguration()
        {
            //https://stackoverflow.com/questions/39791634/read-appsettings-json-values-in-net-core-test-project
            //https://weblog.west-wind.com/posts/2018/Feb/18/Accessing-Configuration-in-NET-Core-Test-Projects
            var config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .AddEnvironmentVariables()
               .Build();
            return config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            IConfiguration config = InitConfiguration();
            services.AddOptions();
            services.AddTransient<IPublicHolidays, PublicHolidaysService>();
        }
    }
}