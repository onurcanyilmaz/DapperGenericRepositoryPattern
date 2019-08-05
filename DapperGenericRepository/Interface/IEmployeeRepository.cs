using DapperGenericRepository.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperGenericRepository.Interface
{
    public interface IEmployeeRepository
    {
        void Insert(Employees entity);
        void Delete(Employees entity);
        void Update(Employees entity);
        IEnumerable<Employees> Query(string where = null);

        int Count(int id);
    }
}
