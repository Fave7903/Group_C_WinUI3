using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDesktopApp2
{
    public class MatricNumber
    {
        public string Generate(string dept, int num)
        {
            string year = "2023/";
            num++;
            int strNum = Convert.ToInt32(num);
            string last = dept.Substring(0, 3);
            string final = year + strNum + "/" + last;
            return final;
        }
    }
}