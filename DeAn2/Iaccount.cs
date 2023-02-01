using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace DeAn2
{
    interface Iaccount
    {
        string UserName { get; }
        string PassWord { get; set; }
    }
}
