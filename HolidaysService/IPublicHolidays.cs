using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IPublicHolidays
{
    public Task<PublicHoliday> GetPublicHoliday(string CountryCode, DateTime date, bool useProxy = true);
}