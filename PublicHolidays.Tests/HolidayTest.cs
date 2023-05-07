using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace PublicHolidays.Tests
{
    public class HolidayTest
    {
        ICountryHoliday _publicHolidays;

        public HolidayTest(IConfiguration config, ICountryHoliday publicHolidays)
        {
            _publicHolidays = publicHolidays;
        }

        [Theory]
        [InlineData("2023-01-02", "New Year's Day", "GB")]
        public async void TestMultipleHolidaysSameDay(DateTime date, string Name, string CountryCode)
        {
            var list = (await _publicHolidays.GetHoliday(CountryCode, date, true));

            Assert.NotNull(list);
            Assert.Equal(2, list.Count());
            foreach (var p in list)
            {
                Assert.Equal(CountryCode, p.CountryCode);
                Assert.Equal(date, p.Date);
                Assert.Equal(Name, p.Name);
            }
        }

        [Theory]
        [InlineData("5/8/2023", "Coronation Bank Holiday", "GB")]
        [InlineData("11/30/2023", "Saint Andrew's Day", "GB")]
        [InlineData("7/4/2023", "Independence Day", "US")]
        [InlineData("10/3/2023", "German Unity Day", "DE")]
        public async void TestHolidaysServices(DateTime date, string Name, string CountryCode)
        {
            var p = (await _publicHolidays.GetHoliday(CountryCode, date, true)).FirstOrDefault();

            Assert.NotNull(p);
            Assert.Equal(CountryCode, p.CountryCode);
            Assert.Equal(date, p.Date);
            Assert.Equal(Name, p.Name);
        }

        [Theory]
        [InlineData("3/2/2023", "US")]
        public async void TestNotHoliday(DateTime date, string CountryCode)
        {
            var p = (await _publicHolidays.GetHoliday(CountryCode, date, true)).FirstOrDefault();

            Assert.Null(p);
        }
    }
}