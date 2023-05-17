using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testDB_Dapper
{
    internal interface ICrudOpration
    {
        void Add(Employee employee);
        void Update(int Id,Employee employee);
        void Delete(int Id);
        void Read();
    }
}
