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
    /// Interaction logic for UserRegistration_Window.xaml
    /// </summary>
    public partial class UserRegistration_Window : Window
    {
        public UserRegistration_Window(UserRegistrationWindowvm vm)
        {
            InitializeComponent();
            DataContext = vm;

        }
    }
}
