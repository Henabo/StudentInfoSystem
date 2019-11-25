using System;
using System.Windows.Forms;
using Bll;
using Model;

namespace UI
{
    public partial class AdminUI : Form
    {
        AdminBll adminBll = new AdminBll();
        public AdminUI()
        {
            InitializeComponent();
        }

        private void adminInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {

            dataGridView1.DataSource = adminBll.SelectAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin ai = new Admin();
            
            ai.admin_name = textBox1.Text;
            ai.password = textBox2.Text;

            if (adminBll.Add(ai))
            {
                LoadList();
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin ai = new Admin();
            ai.password = textBox2.Text;
            ai.admin_name = textBox1.Text;
            if (adminBll.login(ai))
            {
                MessageBox.Show("登陆成功");
            }
            else
            {
                MessageBox.Show("登陆失败");
            }
        }
    }
}
