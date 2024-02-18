using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Collections.ObjectModel;

namespace GroupAssignmentt1
{
    public partial class Doctor_View_vm : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Doctor> doctors;
        public Doctor_View_vm()
        {
            var db = new PatientDataContext();
            var list = db.Doctors.ToList();
            doctors = new ObservableCollection<Doctor>(list);


        }
        [RelayCommand]
        public void EditDoctor(Object obj)
        {
            if (obj is Doctor d)
            {
                doctors.Remove(d);
                var vm = new DoctorRegistrationVM(d);
                var window = new Doctor_Registration_Window(vm);
                window.Show();
                doctors.Add(d);            


                //MessageBox.Show("succesfully Updated");
                //window.Close();
                //Window window3 = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);

                // close the window

                // var window2 = new Doctor_View_Window();
                //window2.Show();
            }

        }
        [RelayCommand]
        public void DeleteDoctor(Object obj)
        {
            if (obj is Doctor d)
            {
                var db = new PatientDataContext();
                Doctor dr=db.Doctors.FirstOrDefault(doc=>doc.DoctorID==d.DoctorID);
                db.Doctors.Remove(dr);
                doctors.Remove(d);

            }

        }
       

    }
}
