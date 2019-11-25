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
    /// AdminVerify.xaml 的交互逻辑
    /// </summary>
    public partial class AdminVerify : Window
    {
        public AdminVerify()
        {
            InitializeComponent();
        }

        private void btn_code_click(object sender, RoutedEventArgs e)
        {
//            if (adminCode.Text.Equals("123456"))
//            {
//                
//                AdminLogin www = new AdminLogin();
//                www.Show();
//                this.Close();
//            }
//            else
//                MessageBox.Show("验证码错误");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            MainWindow www = new MainWindow();
            www.Show();
            this.Close();
        }
    }
}
