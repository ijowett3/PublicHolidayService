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
        [InlineData("11/30/2023", "Saint Andrew's Day", "GB")]
        [InlineData("7/4/2023", "Independence Day", "US")]
        public async void TestHolidaysServices(DateTime date, string LocalName, string CountryCode)
        {
            var p = (await _publicHolidays.GetPublicHoliday(CountryCode, date, true)).FirstOrDefault();

            Assert.NotNull(p);
            Assert.Equal(CountryCode, p.CountryCode);
            Assert.Equal(date, p.Date);
            Assert.Equal(LocalName, p.Name);
        }

        [Theory]
        [InlineData("3/2/2023", "US")]
        public async void TestNotHoliday(DateTime date, string CountryCode)
        {
            var p = (await _publicHolidays.GetPublicHoliday(CountryCode, date, true)).FirstOrDefault();

            Assert.Null(p);
        }
    }
}