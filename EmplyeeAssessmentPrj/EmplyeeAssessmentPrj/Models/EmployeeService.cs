using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmplyeeAssessmentPrj.Models
{
    public class EmployeeService
    {
        private static ObservableCollection<Employees> objEmployeeList;

        private static ObservableCollection<Departments> objDepartmentList;

        public EmployeeService()
        {
            objEmployeeList = new ObservableCollection<Employees>();
            objEmployeeList.Add(new Employees { EmployeeId = 101, Name = "Rahul Kumar", Designation = "Employee", Department = "IT" });
            objEmployeeList.Add(new Employees { EmployeeId = 102, Name = "Pankaj Kumar", Designation = "Employee", Department = "Admin" });
            objEmployeeList.Add(new Employees { EmployeeId = 103, Name = "Aashish Kumar", Designation = "Employee", Department = "HR" });

            objDepartmentList = new ObservableCollection<Departments>();
            objDepartmentList.Add(new Departments { DepartmentId = 1, DepartmentName = "IT" });
            objDepartmentList.Add(new Departments { DepartmentId = 2, DepartmentName = "Admin" });
            objDepartmentList.Add(new Departments { DepartmentId = 3, DepartmentName = "HR" });
            objDepartmentList.Add(new Departments { DepartmentId = 4, DepartmentName = "Account" });

        }

        public List<Departments> GetAllDepartment()
        {
            return objDepartmentList.ToList();
        }
        public ObservableCollection<Employees> GetAll()
        {
            return objEmployeeList;
        }

        public bool AddEmployee(Employees objEmployee)
        {
            objEmployeeList.Add(objEmployee);
            return true;
        }
    }
}
