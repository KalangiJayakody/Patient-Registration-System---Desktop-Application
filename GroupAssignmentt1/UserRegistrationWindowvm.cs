using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore; 
      

namespace GroupAssignmentt1
{
    public partial class UserRegistrationWindowvm : ObservableObject
    {
        [ObservableProperty]
        public string name;
        [ObservableProperty]
        public int age;

        [ObservableProperty]
        public string gender;
        [ObservableProperty]
        public Patient pa;
        [ObservableProperty]
        public string userName;
        [ObservableProperty]
        public string passWord;
        [ObservableProperty]
        public string date;
        


        public UserRegistrationWindowvm() { }
        public UserRegistrationWindowvm(Patient p) {
            name=p.Name; age=p.Age; gender=p.Gender;
            pa = p; date = p.Date;
        
        
        }
        [RelayCommand]
        public void SavePatient()
        {
            if(pa == null) {
                pa = new Patient();
                pa.Name = name;
                pa.Age = age;
                pa.Gender = gender;
                pa.UserName = userName;
                pa.Password = passWord;
                pa.Date = date;

                var db = new PatientDataContext();
                db.Patients.Add(pa);
                db.SaveChanges();
                MessageBox.Show("succesfully registered");
                Window window3 = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);

                // close the window
                window3.Close();
                var window2 = new Admin_Main_Window();
                window2.Show();
            }
            else
            {
                pa.Name = name;
                pa.Age = age;
                pa.Gender = gender;
                pa.UserName=userName; pa.Password = passWord;
                pa.Date = date;
                var db = new PatientDataContext();
                Patient p=db.Patients.FirstOrDefault(p=>p.RegNo==pa.RegNo);
                if (p != null)
                {
                    db.Patients.Remove(p);
                    db.SaveChanges();
                  
                    pa.Name = name;
                    pa.Age = age;
                    pa.Gender = gender;
                    pa.UserName = userName; pa.Password = passWord;
                    db.Add(pa);

                    db.SaveChanges();
                    MessageBox.Show("succesfully Edited");
                    Window window3 = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);

                    // close the window
                    window3.Close();
                    var window2 = new Admin_Main_Window();
                    window2.Show();

                }

            }
        }
    }
}
