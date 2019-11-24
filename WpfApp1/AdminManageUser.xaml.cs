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
    /// AdminManageUser.xaml 的交互逻辑
    /// </summary>
    public partial class AdminManageUser : Window
    {
        public AdminManageUser()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminAddStudent www = new AdminAddStudent();
            www.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AdminEditStudent www = new AdminEditStudent();
            www.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AdminAddTeacher www = new AdminAddTeacher();
            www.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AdminEditTeather www = new AdminEditTeather();
            www.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            AdminHome www = new AdminHome();
            www.Show();
            this.Close();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            
            AdminHome www = new AdminHome();
            www.Show();
            this.Close();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {

        }
    }
}
