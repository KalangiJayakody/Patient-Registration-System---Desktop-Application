using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace GroupAssignmentt1
{
    public partial class Service_Registration_WindowVm : ObservableObject
    {
        [ObservableProperty]
        public string servicename;
        [ObservableProperty]
        public double cost;
        [ObservableProperty]
        public Service ser;
        public Service_Registration_WindowVm() { 

        }
        public Service_Registration_WindowVm(Service service) {
            servicename = service.ServiceName;
            cost = service.cost;
            ser = service;

        
        }

        [RelayCommand]
        public void save()
        {
            
            if(ser == null) { 
                ser = new Service();
                ser.ServiceName = servicename;
                ser.cost = cost;
                var db = new PatientDataContext();
                db.Add(ser);
                db.SaveChanges();
                MessageBox.Show("succesfully Edited");
                Window window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);

                // close the window
                window.Close();
                var window2 = new VIEW_Window();
                window2.Show();
            }
            else
            {
                var db = new PatientDataContext();
                db.Remove(ser);
                db.SaveChanges();
                ser.ServiceName=servicename;
                ser.cost = cost;
                
                db.Add(ser);
                db.SaveChanges();
                MessageBox.Show("succesfully Edited");
                Window window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);

                // close the window
                window.Close();
                var window2 = new VIEW_Window();
                window2.Show();

            }

        }
    }
}
