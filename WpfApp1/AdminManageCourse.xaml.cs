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

namespace WpfApp1
{
    /// <summary>
    /// AdminManageCourse.xaml 的交互逻辑
    /// </summary>
    public partial class AdminManageCourse : Window
    {
        public AdminManageCourse()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            AdminAddCourse www = new AdminAddCourse();
            www.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            AdminEditCourse www = new AdminEditCourse();
            www.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
            AdminHome www = new AdminHome();
            www.Show();
            this.Close();
        }



        

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            AdminLogin www = new AdminLogin();
            www.Show();
            this.Close();
        }
    }
}
