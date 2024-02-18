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

namespace GroupAssignmentt1
{
    /// <summary>
    /// Interaction logic for Service_Register_Winodw.xaml
    /// </summary>
    public partial class Service_Register_Winodw : Window
    {
        public Service_Register_Winodw(Service_Registration_WindowVm vm)
        {
            InitializeComponent();
            DataContext=vm;
        }
    }
}
