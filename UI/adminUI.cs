using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bll;
using Model;

namespace UI
{
    public partial class AdminUI : Form
    {
        AdminBll miBll = new AdminBll();
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

            dataGridView1.DataSource = miBll.SelectAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin ai = new Admin();
            ai.password = textBox2.Text;
            ai.admin_name = textBox1.Text;
            
            if(miBll.Add(ai))
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
            if (miBll.login(ai))
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
