using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GroupAssignmentt1
{
    public partial class DoctorRegistrationVM : ObservableObject
    {
        [ObservableProperty]
        public string name;
        [ObservableProperty]
        public string speciality;

        public Doctor doc { get; set; }

        public DoctorRegistrationVM() { 

        }
        public DoctorRegistrationVM(Doctor doctor)
        {
            name = doctor.Name;
            speciality = doctor.Speciality;
            doc = doctor;

        }

        [RelayCommand]
        public void Save()
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("spaces cannot be empty.", "Error");
                return;
            }

            if (!Regex.IsMatch(name, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("First name and last name must contain only letters and spaces.", "Error");
                return;
            }
           
            
            if(doc==null)
            {
                Doctor doc= new Doctor();
                doc.Name = name;
                string[] sp = speciality.Split(": ");
                
               
                doc.Speciality = speciality.Substring(38); 
                var db = new PatientDataContext();
                db.Doctors.Add(doc);
                db.SaveChanges();
                MessageBox.Show("Succesfully Added");


            }
            else
            {
               
                doc.Name = name;
                doc.Speciality = speciality.Substring(38); ;
                var db = new PatientDataContext();
                db.Doctors.Remove(doc);
                db.SaveChanges();
                db.Doctors.Add(doc);
                db.SaveChanges();
                MessageBox.Show("Succesfully Edited");
                



            }

        }




    }
}
