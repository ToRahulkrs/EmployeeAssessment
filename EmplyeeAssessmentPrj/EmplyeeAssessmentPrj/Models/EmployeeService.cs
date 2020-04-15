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

        public EmployeeService()
        {
            objEmployeeList = new ObservableCollection<Employees>();
            objEmployeeList.Add(new Employees { EmployeeId = 101, Name = "Rahul Kumar", Designation = "Employee", Department = "IT" });
            objEmployeeList.Add(new Employees { EmployeeId = 102, Name = "Pankaj Kumar", Designation = "Employee", Department = "Admin" });
            objEmployeeList.Add(new Employees { EmployeeId = 103, Name = "Aashish Kumar", Designation = "Employee", Department = "HR" });

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
