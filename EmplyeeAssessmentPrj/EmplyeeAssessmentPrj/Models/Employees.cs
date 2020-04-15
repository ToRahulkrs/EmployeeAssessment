using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmplyeeAssessmentPrj.Models
{
    public class Employees : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _employeeId;

        public int EmployeeId
        {
            get { return _employeeId; }
            set { 
                _employeeId = value;
                OnPropertyChanged("EmployeeId");
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set {
                _name = value;
                OnPropertyChanged("Name");

            }
        }
        private string _designation;

        public string Designation
        {
            get { return _designation; }
            set { 
                _designation = value;
                OnPropertyChanged("Designation");
            }
        }

        private string _department;

        public string Department
        {
            get { return _department; }
            set { 
                _department = value;
                OnPropertyChanged("Department");
            }
        }





    }
}
