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
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Runtime.Serialization;

namespace GroupAssignmentt1
{
    public partial class Bill_Calculating_windowVM : ObservableObject
    {
        [ObservableProperty]
        public int id;
        [ObservableProperty]
        public string name;
        [ObservableProperty]
        public ObservableCollection<Service> services;
        [ObservableProperty]
        public ObservableCollection<Service> billservices;
        [ObservableProperty]
        public ObservableCollection<Patient> patients;
        [ObservableProperty]
        public ObservableCollection<Bill> bills;

        [ObservableProperty]
        public int quantity;

        [ObservableProperty]
        public double totalbill;

        [ObservableProperty]
        public Service selectedService;
        [ObservableProperty]
        public Patient pa;




        public Bill_Calculating_windowVM()
        {
            billservices = new ObservableCollection<Service>();
            

            var db = new PatientDataContext();
            var list02 = db.Patients.ToList();
            patients = new ObservableCollection<Patient>(list02);
            var list03 = db.Bills.ToList();
            bills = new ObservableCollection<Bill>(list03);




        }
        public Bill_Calculating_windowVM(Patient p)
        {
            id = p.RegNo;
            name=p.Name;
          
           
            billservices = new ObservableCollection<Service>();
            var db = new PatientDataContext();
            var list=db.Services.ToList();
            var list02=db.Patients.ToList();
            patients=new ObservableCollection<Patient>(list02);
            services = new ObservableCollection<Service>(list);
            pa = p;
          
        }
        [RelayCommand]
        public void AddtoBill()
        {
            if(selectedService != null )
            {
                
               
                selectedService.quantity = quantity;
                billservices.Add(selectedService);
                
            }

           


           
        }
        
        [RelayCommand]
        public void CalBill()
        {
            var db = new PatientDataContext();

            double total = 0;
            foreach(Service service in billservices)
            {
                
                
                total =total+ (service.cost);
                
            }

            pa.amount = total;
            MessageBox.Show(pa.amount.ToString());
            totalbill=pa.amount;

            var dbnew=new PatientDataContext();
            Patient p=db.Patients.FirstOrDefault(pat=>pat.RegNo==id);
            if (p != null)
            {
                db.Patients.Remove(p);
                
                p.amount= totalbill;
                db.Patients.Add(p);
                dbnew.SaveChanges();
            }
            Bill bill = new Bill();
          
            bill.Date = pa.Date;
            bill.Amount = pa.amount;
            dbnew.Bills.Add(bill);
            dbnew.SaveChanges();



           
        }
        [RelayCommand]
        public void RemoveItemFromTheBill(object obj)
        {
            if(obj is Service s)
            {
                billservices.Remove(s);

            }
        }
     
        [RelayCommand]
        public void removeBill()
        {
            var db=new PatientDataContext();
            Bill b=db.Bills.FirstOrDefault(bil=>bil.Date==pa.Date);
            if (b != null)
            {
                db.Bills.Remove(b);
                MessageBox.Show("Completely Deleted");
                db.SaveChanges();
            }

        }
        [RelayCommand]
        public void showbills()
        {
            var db = new PatientDataContext();
            var list=db.Bills.ToList();
            bills = new ObservableCollection<Bill>(list);

        }
       
        
    }

}
