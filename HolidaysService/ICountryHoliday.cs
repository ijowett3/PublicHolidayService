using HolidaysService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ICountryHoliday
{
    public Task<IEnumerable<HolidayDomainObject>> GetHoliday(string CountryCode, DateTime date, bool useProxy = true);
}