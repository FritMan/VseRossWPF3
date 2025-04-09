using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionRoss3.Data
{
    public partial class Company
    {
        public string Contacts
        {
            get
            {
                return Email + "," + "\n" + Phone;
            }
        }
    }
}
