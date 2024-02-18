using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace GroupAssignmentt1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        protected override void OnActivated(EventArgs e)
        {
            DatabaseFacade facade = new DatabaseFacade(new PatientDataContext());
            facade.EnsureCreated(); 
        }
    }
}
