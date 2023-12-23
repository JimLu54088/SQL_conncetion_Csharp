using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mysql_exercise
{
    public class Dto
    {
        private int sid;
        private string sname;

        public int Sid { get => sid; set => sid = value; }
        public string Sname { get => sname; set => sname = value; }
    }
}
