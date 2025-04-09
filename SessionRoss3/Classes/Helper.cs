using SessionRoss3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SessionRoss3.Classes
{
    public static class Helper
    {
        public static VseRossDBEntities3 Db = new VseRossDBEntities3();
        public static Expander AuthExp;
    }
}
