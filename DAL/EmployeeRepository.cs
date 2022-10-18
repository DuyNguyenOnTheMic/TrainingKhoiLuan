﻿using System;
using System.Collections;
using System.Data.Entity;
using System.Linq;
using TrainingKhoiLuan.Models;

namespace TrainingKhoiLuan.DAL
{

    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {
        private readonly DBModel dBModel;

        public EmployeeRepository(DBModel dBModel)
        {
            this.dBModel = dBModel;
        }
        public IEnumerable GetEmployees()
        {

            //List<employee> employees = dBModel.employees.ToList<employee>();
            //return employees;
            //return dBModel.employees.ToList();
            return dBModel.employees.Select(emp => new
            {
                emp.employee_id,
                emp.employee_name,
                emp.birth_place,
                emp.birth_date,
                emp.age
            }).ToList();
        }
        public void DeleteEmployee(int ID)
        {
            employee emp = dBModel.employees.Find(ID);
            dBModel.employees.Remove(emp);
        }

        public employee GetEmployeeByID(int Id)
        {
            return dBModel.employees.Find(Id);
        }



        public void InsertEmployee(employee emp)
        {
            dBModel.employees.Add(emp);
        }

        public void Save()
        {
            dBModel.SaveChanges();
        }

        public void UpdateEmployee(employee emp)
        {
            dBModel.Entry(emp).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dBModel.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}