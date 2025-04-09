using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionRoss3.Data
{
    public partial class User
    {
        public string FIO
        {
            get
            {
                return Surname + " " +  Name[0] + ". " + LastName[0] + ".";
            }
        }
    }
}
