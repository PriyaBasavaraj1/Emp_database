using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Emp_database
{
    public class LauncherWindowViewModel : INotifyPropertyChanged
    {
        HttpClient client = new HttpClient();

        public event PropertyChangedEventHandler PropertyChanged;

        public LauncherWindowViewModel()
        {
            client.BaseAddress = new Uri("http://localhost:1428");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            AddEmployeeBtn = new Command(OnAddEmployeeBtn_Click);
            UpdateEmployeeBtn = new Command(OnUpdateEmployeeBtn_Click);
            DeleteEmployeeBtn = new Command(OnDeleteEmployeeBtn_Click);
            ViewEmployeeBtn = new Command(OnViewEmployeeBtn_Click);

        }

        private List<Emp_db> employeeList;

        public List<Emp_db> EmployeeList
        {
            get { return employeeList; }
            set
            {

                if (value != employeeList)
                {
                    employeeList = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("EmployeeList"));
                    }
                }
            }

        }


        public ICommand ViewEmployeeBtn
        {
            get; set;
        }

        public ICommand AddEmployeeBtn
        {
            get; set;
        }

        public ICommand UpdateEmployeeBtn
        {
            get; set;
        }

        public ICommand DeleteEmployeeBtn
        {
            get; set;
        }

        public async void OnViewEmployeeBtn_Click()
        {
            HttpResponseMessage response = await client.GetAsync("/api/employee");
            response.EnsureSuccessStatusCode();
            var employees = await response.Content.ReadAsAsync<IEnumerable<Emp_db>>();
            EmployeeList = employees.ToList();

        }
        private Emp_db _selectedEmployee;
        public Emp_db SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {

                if (value != _selectedEmployee)
                {
                    _selectedEmployee = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("SelectedEmployee"));
                    }
                }

            }
        }


        public async void OnAddEmployeeBtn_Click()
        {
            AddEmployee addEmployee = new AddEmployee(client);
            addEmployee.ShowDialog();
            HttpResponseMessage response = await client.GetAsync("/api/employee");
            response.EnsureSuccessStatusCode();
            var employees = await response.Content.ReadAsAsync<IEnumerable<Emp_db>>();
            EmployeeList = employees.ToList();
        }

        public async void OnUpdateEmployeeBtn_Click()
        {
            if (SelectedEmployee == null)
            {
                MessageBox.Show("You must select a employee");
            }
            else
            {
                UpdateEmployee updateEmployee = new UpdateEmployee(SelectedEmployee, client);
                updateEmployee.ShowDialog();
                HttpResponseMessage response = await client.GetAsync("/api/employee");
                response.EnsureSuccessStatusCode();
                var employees = await response.Content.ReadAsAsync<IEnumerable<Emp_db>>();
                EmployeeList = employees.ToList();
            }

        }

        public async void OnDeleteEmployeeBtn_Click()
        {

            try
            {
                HttpResponseMessage response = await client.DeleteAsync("/api/employee/" + SelectedEmployee.ID);
                response.EnsureSuccessStatusCode();
                MessageBox.Show("Employee Successfully Deleted");
                HttpResponseMessage responses = await client.GetAsync("/api/employee");
                responses.EnsureSuccessStatusCode();
                var employees = await responses.Content.ReadAsAsync<IEnumerable<Emp_db>>();
                EmployeeList = employees.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Employee Deletion Unsuccessful");
            }
        }

    }

}