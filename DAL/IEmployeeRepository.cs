using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using TrainingKhoiLuan.Models;
using System.Collections;

namespace TrainingKhoiLuan.DAL
{
    public interface IEmployeeRepository : IDisposable
    {
        IEnumerable GetEmployees();
        employee GetEmployeeByID(int Id);
        void InsertEmployee(employee emp);
        void DeleteEmployee(int ID);
        void UpdateEmployee(employee emp);
        void Save();
    }
}
