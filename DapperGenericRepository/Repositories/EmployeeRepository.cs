using DapperGenericRepository.Interface;
using DapperGenericRepository.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperGenericRepository.Repositories
{
    public class EmployeeRepository : BaseRepository<Employees>, IEmployeeRepository
    {
        //write this keyword and using interface method : 'override'

        public int Count(int id)
        {
            throw new NotImplementedException("this $method not implemented");
        }

        public override void Insert(Employees entity)
        {
            base.Insert(entity);
        }
    }
}