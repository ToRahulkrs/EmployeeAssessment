using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using EmplyeeAssessmentPrj.Commands;
using EmplyeeAssessmentPrj.Models;

namespace EmplyeeAssessmentPrj.VewModels
{
    public class EmployeesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddCommand { get; }
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        EmployeeService objEmployeeService;
        public EmployeesViewModel()
        {
            objEmployeeService = new EmployeeService();
            LoadData();
            DepartmentLoadData();
            SubmitEmployee = new Employees();
            saveCommand = new RelayCommand(Save);
        }


        private ObservableCollection<Employees> employeesList;
        private ObservableCollection<Employees> filteredEmployees;

        public ObservableCollection<Employees> EmployeesList
        {
            get { return employeesList; }
            set { employeesList = value; OnPropertyChanged("EmployeesList"); }
        }
        public ObservableCollection<Employees> FilteredEmployeeList
        {
            get { return filteredEmployees; }
            set { filteredEmployees = value; OnPropertyChanged("FilteredEmployeeList"); }
        }
        private List<Departments> departmentsList;

        public List<Departments> DepartmentsList
        {
            get { return departmentsList; }
            set { departmentsList = value; OnPropertyChanged("DepartmentsList"); }
        }

        private ObservableCollection<string> _departments;
        public ObservableCollection<string> Departments
        {
            get { return new ObservableCollection<string>(DepartmentsList.Select(o => o.DepartmentName).Distinct());
            }
            set { _departments = value; OnPropertyChanged("Departments"); }
            
        }
    


        private Employees employees;

        public Employees Employees
        {
            get { return employees; }
            set { employees = value; OnPropertyChanged("Employees"); }
        }

        private Employees submitEmployee;

        public Employees SubmitEmployee
        {
            get { return submitEmployee; }
            set { submitEmployee = value; OnPropertyChanged("SubmitEmployee"); }
        }

        private string  message;

        public string  Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }


        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
      
        }

        public void Save()
        {
            try
            {
                if(SubmitEmployee.EmployeeId==0 || SubmitEmployee.Name==null || SubmitEmployee.Designation == null
                     || SubmitEmployee.Department == null )
                {
                    Message = "Employee not saved, plese enter data in valid formate";
                }
                else
                {
                    var IsSaved = objEmployeeService.AddEmployee(SubmitEmployee);
                    LoadData();
                    if (IsSaved)
                    {
                        Message = "Employee Saved";
                    }
                    else
                    {
                        Message = "Employee not saved";
                    }
                    SubmitEmployee = new Employees();
                }
        
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }


        private void LoadData()
        {
            employeesList = objEmployeeService.GetAll();
            FilteredEmployeeList = employeesList;
        }

        private void DepartmentLoadData()
        {
            departmentsList = objEmployeeService.GetAllDepartment();
            DepartmentsList = departmentsList;
        }

        private string _error;

        public string Error
        {
            get { return _error; }
            set { _error = value; OnPropertyChanged("Error"); }
        }

    }
}
