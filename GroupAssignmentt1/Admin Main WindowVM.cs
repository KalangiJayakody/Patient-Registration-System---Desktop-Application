using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GroupAssignmentt1.Migrations;
using Microsoft.EntityFrameworkCore;

namespace GroupAssignmentt1
{
    public partial class Admin_Main_WindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Patient> patients;
        public Admin_Main_WindowVM() {
            var db = new PatientDataContext();
            var list=db.Patients.ToList();
            patients=new ObservableCollection<Patient>(list);
        
        
        }
       

        [RelayCommand]
        public void DoctorRegisterLog()
        {
            var vm=new DoctorRegistrationVM();
            var window = new Doctor_Registration_Window(vm);
            window.Show();

        }
        [RelayCommand]
        public void PatientRegisterLog()
        {
            var vm = new UserRegistrationWindowvm();
            var window = new UserRegistration_Window(vm);
            window.Show();

        }
        [RelayCommand]
        public void ServiceRegisterLog()
        {
            var vm = new Service_Registration_WindowVm();
            var window = new Service_Register_Winodw(vm);
            window.Show();

        }
        [RelayCommand]
        public void ServiceView()
        {
            var window = new VIEW_Window();
            window.Show();

        }
        [RelayCommand]
        public void DoctorView() { 
            var window=new Doctor_View_Window();
            window.Show();
        }
        [RelayCommand]
        public void EditPatient(Object obj)
        {
            if(obj is  Patient p) {
                patients.Remove(p);
                var vm = new UserRegistrationWindowvm(p);
                var window = new UserRegistration_Window(vm);
                window.Show();
                patients.Add(p);
            }

        }
        [RelayCommand]
        public void DeletePatient(Object obj)
        {
            if(obj is Patient p)
            {
                var db = new PatientDataContext();
                Patient pat=db.Patients.FirstOrDefault(px=>px.RegNo == p.RegNo);
                db.Patients.Remove(pat);
                patients.Remove(p);
               
            }

        }
        [RelayCommand]
        public void ReadPatient(Object obj)
        {
            if(obj is Patient patient)
            {
                var vm=new PatientWindowVM(patient);
                var window = new PatientWindow(vm);
                window.Show();
            }
        }
        [RelayCommand]
        public void CalculateBill(Object obj)
        {
            if (obj is Patient patient)
            {
                var vm = new Bill_Calculating_windowVM(patient);
                var window = new Bill_Calculating_Window(vm);
                window.Show();
            }


        }
        [RelayCommand]
        public void BillPage()
        {
            var window = new Bill_History_Window();
            window.Show();
        }


    }
}
