using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaysService
{
    public class HolidayDomainObject
    {
        public string? Name { get; protected set; }

        public string? CountryCode { get; protected set; }

        public DateTime Date { get;  protected set; }

        public HolidayDomainObject(string name, string countryCode, DateTime date)
        {
            Name = name;
            CountryCode = countryCode;
            Date = date;
        }
    }
}
