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
    /// AdminLogin.xaml 的交互逻辑
    /// </summary>
    public partial class AdminLogin : Window
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            AdminHome www = new AdminHome();
            www.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            AdminRegister www = new AdminRegister();
            www.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow www = new MainWindow();
            www.Show();
        }
    }
}
