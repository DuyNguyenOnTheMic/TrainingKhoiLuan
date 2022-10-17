using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingKhoiLuan.Models;

namespace TrainingKhoiLuan.DAL
{
    public interface IEmployeeRepository
    {
        IEnumerable GetEmployees();
        employee GetEmployeeByID(int Id);
        void InsertEmployee(employee emp);
        void DeleteEmployee(int ID);
        void UpdateEmployee(employee emp);
        void Save();
    }
}
