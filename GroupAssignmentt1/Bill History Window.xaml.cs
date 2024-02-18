using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace GroupAssignmentt1
{
    /// <summary>
    /// Interaction logic for Bill_History_Window.xaml
    /// </summary>
    public partial class Bill_History_Window : Window
    {
        public Bill_History_Window()
        {
            InitializeComponent();
            DataContext = new Bill_Calculating_windowVM();
        }
    }
}
