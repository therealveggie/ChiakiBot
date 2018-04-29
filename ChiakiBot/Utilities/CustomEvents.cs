using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiakiBot.Utilities
{
    class CustomEvents
    {
        public string DueDateTime;
        public string EventDescription;
        public string EventTitle;

        public CustomEvents(string duedate, string eventTitle, string eventdescription)
        {
            this.DueDateTime = duedate;
            this.EventDescription = eventdescription;
            this.EventTitle = eventTitle;
        }

        public string toString()
        {
            return DueDateTime + " " + EventTitle + " " + EventDescription;
        }
    }
}
