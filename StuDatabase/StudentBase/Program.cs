using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBase
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlFun sqlFun = new SqlFun();
            Student student = new Student("1", "1", "1", "1", "1", "1");
            sqlFun.Add(student);
            //Student student = new Student();


        }
    }
}
