using Microsoft.Extensions.Configuration;

namespace PublicHolidays.Tests
{
    public class PublicHolidaysTest
    {
        IPublicHolidays _publicHolidays;

        public PublicHolidaysTest(IConfiguration config, IPublicHolidays publicHolidays)
        {
            _publicHolidays = publicHolidays;
        }

        [Theory]
        [InlineData("5/8/2023", "Coronation Bank Holiday", "GB")]
        public async void TestHolidaysServices(DateTime date, string LocalName, string CountryCode)
        {
            var p = await _publicHolidays.GetPublicHoliday(CountryCode, date, true);

            Assert.NotNull(p);
            Assert.Equal(CountryCode, p.CountryCode);
            Assert.Equal(date, p.Date);
            Assert.Equal(LocalName, p.LocalName);
        }
    }
}