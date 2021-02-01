using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecordShop.Extensions
{
    public class YearRangeAttribute : RangeAttribute
    {
        public YearRangeAttribute(int StartYear) : base(StartYear, DateTime.Today.Year)
        {

        }
    }
}
