using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Secmark.Models;

namespace Secmark
{
    public partial class Form1 : Form
    {
        DepartmentCrud crud;
            List<Department>list;
        public Form1()
        {
            InitializeComponent();
            crud = new DepartmentCrud();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Department d = new Department();
                d.dept_code = txtCode.Text;
                d.dep_name = txtName.Text;
                int res = crud.Adddept(d);
                if(res > 0)
                {
                    MessageBox.Show("Record inserted..");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DataTable table = crud.GetDepartment();
            dataGridView1.DataSource = table;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Department d = new Department();
                d.dept_code = txtCode.Text;
                d.dep_name = txtName.Text;
                int res = crud.UpdateDepartment(d);
                if(res > 0)
                {
                    MessageBox.Show("Record updated..");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

         private void btnView_Click(object sender, EventArgs e)
        {
            DataTable table = crud.GetDepartment();
            dataGridView1.DataSource = table;
        }
    }
}
