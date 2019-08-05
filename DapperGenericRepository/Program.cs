using System;
using DapperGenericRepository.Interface;
using DapperGenericRepository.Model;
using DapperGenericRepository.Repositories;

namespace DapperGenericRepository
{
    class Program
    {
        static void Main(string[] args)
        {
            // repository instance
            IEmployeeRepository repository = new EmployeeRepository();

            // employeeModel
            var model = new Employees() { FirstName = "ONURCAN", LastName = "YILMAZ", HireDate = DateTime.MaxValue, Title = "Repository" };
            repository.Insert(model);

            //repository.Update(model);

            // your query
            var q = repository.Query("");

            Console.ReadLine();
        }
    }
}
