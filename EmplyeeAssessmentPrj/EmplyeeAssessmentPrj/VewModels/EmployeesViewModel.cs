using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
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

        private ObservableCollection<string> _departments;
        public ObservableCollection<string> Departments
        {
            get { return new ObservableCollection<string>(EmployeesList.Select(o => o.Department).Distinct());
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
                if(SubmitEmployee.EmployeeId==0 && string.IsNullOrWhiteSpace(SubmitEmployee.Name) && 
                    string.IsNullOrWhiteSpace(SubmitEmployee.Designation) && string.IsNullOrWhiteSpace(SubmitEmployee.Department))
                {
                    Message = "Employee not saved, plese enter valid details";
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
    }
}
