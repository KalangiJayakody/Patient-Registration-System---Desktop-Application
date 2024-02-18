using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GroupAssignmentt1.Migrations;
using Microsoft.EntityFrameworkCore;

namespace GroupAssignmentt1
{
    public partial class PatientWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string userName;

        [ObservableProperty]
        public string password;

        [ObservableProperty]
        public string name;

        [ObservableProperty]
        public ObservableCollection<Service> services;

        [ObservableProperty]
        public int age;

        [ObservableProperty]

        public double amount;

        public PatientWindowVM()
        {

        }
        public PatientWindowVM(Patient patient)
        {
            var db = new PatientDataContext();
            userName = patient.UserName;
            password = patient.Password;
            name = patient.Name;
            age = patient.Age;
            amount = patient.amount;
          

        }


    }
}
