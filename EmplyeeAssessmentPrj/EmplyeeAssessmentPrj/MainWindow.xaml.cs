using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EmplyeeAssessmentPrj.Models;
using EmplyeeAssessmentPrj.VewModels;
using System.Collections.ObjectModel;
using EmplyeeAssessmentPrj.Views;

namespace EmplyeeAssessmentPrj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeesViewModel ViewModel;
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new EmployeesViewModel();
            this.DataContext = ViewModel;
        }

        private void FinishDropdown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var selectedDept = (string)((ComboBox)sender).SelectedValue;
            var selectedDept = ((EmplyeeAssessmentPrj.Models.Employees)((ComboBox)sender).SelectedValue).Department;
            ViewModel.FilteredEmployeeList = new ObservableCollection<Employees>(ViewModel.EmployeesList.Where(emp => emp.Department.Contains(selectedDept))); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // TextBoxID.Text = TextBoxName.Text = TextBoxDesignation.Text = TextBoxDepartment.Text = "";
        }
    }
}
