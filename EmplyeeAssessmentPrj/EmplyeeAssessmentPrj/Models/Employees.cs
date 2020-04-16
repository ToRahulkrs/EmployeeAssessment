using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmplyeeAssessmentPrj.Models
{
    public class Employees : INotifyPropertyChanged,IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private int? _employeeId;

        public int? EmployeeId
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

        #region IDataErrorInfo Members

        private string _error;

        public string Error
        {
            get => _error;
            set 
            {
                if (_error != value)
                {
                    _error = value;
                   OnPropertyChanged("Error");
                }
            }
        }

        public string this[string columnName]
        {
            get
            {
                return OnValidate(columnName);
            }
        }

        private string OnValidate(string columnName)
        {
            string result = string.Empty;
            if (columnName == "Name")
            {
                if (string.IsNullOrEmpty(Name))
                {
                    result = "Name is mandatory";
                }
                else if (!Regex.IsMatch(Name, @"^[a-zA-Z]+$"))
                {
                    result = "Should enter alphabets only!!!";
                }
            }

            if (columnName == "Designation")
            {
                if (string.IsNullOrEmpty(Designation))
                {
                    result = "Designation Required";
                }
                else if (!Regex.IsMatch(Designation, @"^[a-zA-Z]+$"))
                {
                    result = "Should enter alphabets only!!!";
                }
            }
            
            if (result == null)
            {
                Error = null;
            }
            else
            {
                Error = "Error";
            }
            return result;
        }

        #endregion
    }
}

