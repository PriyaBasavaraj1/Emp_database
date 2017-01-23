using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Emp_database
{
    public class UpdateEmployeeViewModel
    {
        HttpClient client;
        Emp_db updateEmp;
        public UpdateEmployeeViewModel(HttpClient client, Emp_db SelectedEmployee)
        {
            this.client = client;
            UpdateBtn = new Command(OnUpdateBtn_Click);
            updateEmp = SelectedEmployee;
            FirstName = SelectedEmployee.FirstName;
            LastName = SelectedEmployee.LastName;
            Email = SelectedEmployee.Email;
            ID = SelectedEmployee.ID;

            if (SelectedEmployee.Status == "Activated")
                Activate = true;
            else
                Activate = false;
        }
        private bool _acticvate;
        public bool Activate
        {
            get { return _acticvate; }
            set
            {
                _acticvate = value;
            }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }


        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }



        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _empID;
        public string ID
        {
            get { return _empID; }
            set { _empID = value; }
        }

        public ICommand UpdateBtn
        {

            get; set;
        }
        public async void OnUpdateBtn_Click()
        {
            try
            {
                Verify.verify(FirstName, LastName, Email);
                updateEmp.FirstName = FirstName;
                updateEmp.LastName = LastName;
                updateEmp.Email = Email;
                updateEmp.ID = ID;
                if (Activate)
                    updateEmp.Status = "Activated";
                else
                    updateEmp.Status = "Deactivated";


                var response = await client.PutAsJsonAsync("/api/employee/", updateEmp);
                response.EnsureSuccessStatusCode();
                MessageBox.Show("Employee Updated Successfully", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (InvalidInputException e)
            {
                MessageBox.Show("Error \n" + e);

            }
            catch (Exception)
            {
                MessageBox.Show("Employee not Added ");
            }

        }

    }
}