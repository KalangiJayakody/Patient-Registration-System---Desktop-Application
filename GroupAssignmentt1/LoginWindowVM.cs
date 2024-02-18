using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace GroupAssignmentt1
{
    public partial class LoginWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string userName;

        [ObservableProperty]
        public string password;
        [ObservableProperty]
        public Patient p;
        [RelayCommand]
        public void AdminLog()
        {
            bool fine=false;
            var db = new PatientDataContext();

            foreach(Admin admin in db.Admins)
            {
                
                if(admin.UserName == userName && admin.Password == password)
                {
                    fine=true;
                }
            }
            if(fine)
            {
                var window=new Admin_Main_Window();
                window.Show();

            }
            else
            {
                MessageBox.Show("Invalid Login");
            }
        }

        [RelayCommand]
        public void PatientLog()
        {
            bool fine = false;
            var db = new PatientDataContext();

            foreach (Patient patient in db.Patients)
            {

                if (patient.UserName == userName && patient.Password == password)
                {
                    fine = true;
                    p= patient;
                }
            }
            if (fine)
            {
                var vm=new PatientWindowVM(p);
                var window = new PatientWindow(vm);
                window.Show();

            }
            else
            {
                MessageBox.Show("Invalid Login");
            }
        }
        [RelayCommand]
        public void Welcome()
        {
            var window=new LoginWindow();
            window.Show();

        }

    }
}
