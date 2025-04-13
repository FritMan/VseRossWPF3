using System;
using System.Collections.Generic;
using System.IO;
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
                return Surname + " " + Name[0] + ". " + LastName[0] + ".";
            }
        }

        public byte[] ImgSource { get
            {
                if (Photo == null)
                {
                    return File.ReadAllBytes("C:\\Users\\Ансар\\source\\repos\\SessionRoss3\\SessionRoss3\\Assets\\square_13481846.png");
                }
                else
                {
                    return Photo;
                }
            }
        }
    }
}
