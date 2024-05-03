using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Severis.Shared
{
    public interface ITimeProvider
    {
        DateTime Now { get; }
        string ToShortDateString();
    }

    public class DateTimeProvider : ITimeProvider
    {

        public DateTime Now
        {
            get { return DateTime.Now; }
        }

        public string ToShortDateString()
        {
            return Now.ToShortDateString();
        }
    }

}
