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
   public partial class VIEW_vm :ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Service> services;
        public VIEW_vm()
        {
            var db = new PatientDataContext();
            var list= db.Services.ToList();
            services = new ObservableCollection<Service>(list);
        }
        [RelayCommand]
        public void EditService(Object obj)
        {
            if (obj is Service s)
            {
                services.Remove(s);

                var vm = new Service_Registration_WindowVm(s);
                var window = new Service_Register_Winodw(vm);
                window.Show();
                services.Add(s);
            }

        }
        [RelayCommand]
        public void DeleteService(Object obj)
        {
            if (obj is Service s)
            {
                var db = new PatientDataContext();
                Service service = db.Services.FirstOrDefault(sa => sa.serviceid == s.serviceid);
                if (service != null)
                {
                    MessageBox.Show("hi");
                    services.Remove(service);
                    db.Remove(service);
                    db.SaveChanges();
                    Window window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);

                    // close the window
                    window.Close();
                    var window2 = new VIEW_Window();
                    window2.Show();
                }
             
            }

        }


    }
}
